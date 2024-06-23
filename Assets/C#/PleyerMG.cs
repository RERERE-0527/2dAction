using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PleyerMG : MonoBehaviour
{
    Rigidbody2D rb;//Rigidbody2D�i�[��
    [SerializeField] int _speed = 10;//���x�ϐ�

    [SerializeField] float _jumpStrength = 100f;//�W�����v�̗�
    bool _checkGround = true;//�n�ʂƂ̐ݒu����Ɏg����H
    bool _canJump = true;//�W�����v���\���ǂ����̔���Ɏg����H

    float _hp = 5;//�v���C���[��HP
    float _maxHP;//�v���C���[��HP���
    Image HPBar;//HPbar�̉摜���i�[���锠

    float _x;
    float _wallTouch;

    public Vector3 _scale;//transform��

    [SerializeField] float _maxSpeed = 10.0f;
    float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//Rigidbody2D�i�[
        HPBar = GameObject.Find("HPbar").GetComponent<Image>();//�摜�i�[
        _maxHP = _hp;//HP�̏���ݒ�@���
    }
    // Update is called once per frame

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        _scale = transform.localScale;
        _x = Input.GetAxisRaw("Horizontal");//���s���͌��m
        float y = Input.GetAxis("Vertical");//�㉺���͌��m

        if (_canJump && Input.GetKeyDown(KeyCode.W))//canJump��turu����(W)�������ꂽ�Ƃ�
        {
            rb.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);//������Ɉړ��l�����Z
            _canJump = !_checkGround;//�Ȃ񂩒��n���m�ɂ�����H
        }

        if (_x == 1)
        {
            _scale.x = 0.5f;
        }
        else if (_x == -1)
        {
            _scale.x = -0.5f;
        }

        transform.localScale = _scale;
        if (_hp <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(speed * _x, rb.velocity.y);

        //if (rb.velocity.x > _maxSpeed && 0 < _x)
        //{
        //    rb.velocity = new Vector2(_maxSpeed, rb.velocity.y);

        //}
        //else if (rb.velocity.x < _maxSpeed * -1 && _x < 0)
        //{
        //    rb.velocity = new Vector2(_maxSpeed * -1, rb.velocity.y);

        //}
        if (_wallTouch == 0 || _wallTouch == horizontal)
        {
            rb.velocity = new Vector2(horizontal * _speed, rb.velocity.y);
        }

    }
    private void OnTriggerEnter2D(Collider2D collisionData)
    {
        if (collisionData.gameObject.CompareTag("Enemy"))//�ڐG�����I�u�W�F�N�g�̃^�O��"Enemy"�Ȃ�
        {
            _hp--;//HP���P���炷
            HPBar.fillAmount = _hp / _maxHP;//HPbar��HP/MaxHP�ɑ傫����ύX
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_checkGround && collision.gameObject.CompareTag("Ground"))//�`�F�b�Nground���ǂ��ɂ��Ȃ��Ă邩�ڐG�����I�u�W�F�N�g�^�O��ground�Ȃ��
        {      
            _canJump = true;//canJump��true�ɂ���B
        }
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Mathf.Abs(collision.contacts[0].normal.x) > 0.8f)
        {
            _wallTouch = Mathf.Sign(collision.contacts[0].normal.x);
        }
        else
        {
            _wallTouch = 0;
        }
    }

}
//��邱�ƃ��X�g

//�}�b�v�������ƍL�����G�Ɉړ����鏰�Ƃ��A�X���`�b�N�v�f�t����������
//*** BOSS�̓����ǉ� �����Ĉ��яオ���ē��݂���
//*** �{�X�펞�ɋ󒆂ɑ�������B
//�ǂ̂ڂ�h�~�i�ۗ��j
//�ˌ��Ɋp�x������

//BGM�ǉ��������B�^�C�g���A�N���A�A�Q�[���I�[�o�[�A�Q�[�����
//SE �U���@�{�^�����́@���j

//�^�C�g����ʂƂ��w�i�̑��Ƃ��y���A�j���[�V������������

//�v���C���[���A�j���[�V�������������I�f�ނ��Z�p������Ȃ��I�{�[�����g�����A�j���[�V�����͋Z�p�I�Ƀ��Y�C�Ԃɍ���Ȃ�
//����ăp���p����������ŕ`�悵�����B�Œ�ł������Ă���G�Ǝ~�܂��Ă���G����肽���B�~�������΍U�����[�V��������肽��

//�v���C���[�ƒn�ʂ͔������������A�G�ƒn�ʂ͔������������B�v���C���[�ƓG�͒ʂ蔲���Ăق����A���ǐڐG�̔���̂ݗ~����
