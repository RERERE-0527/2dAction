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

    float _x;//�ڐG�����̂��ǂ��n�ʂ����肷�邽�߂Ɏg�����
    float _wallTouch;

    public Vector3 _scale;//

    [SerializeField] float _maxSpeed = 10.0f;//���x����ݒ�
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
        horizontal = Input.GetAxisRaw("Horizontal");//���E���͌��m
        _scale = transform.localScale;//�I�u�W�F�N�g��scale���i�[
        _x = Input.GetAxisRaw("Horizontal");//���s���͌��m
        float y = Input.GetAxis("Vertical");//�㉺���͌��m
        Debug.Log(_canJump);


        //canJump��turu����(W)�܂���(Space)�������ꂽ�Ƃ��W�����v
        if (_canJump && (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.Space)))
        {
            rb.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);//������Ɉړ��l�����Z
            _canJump = false;//�Ȃ񂩒��n���m�ɂ�����H
        }

       �@//�����ɂ���ăI�u�W�F�N�g�̌����ڂ�ύX
        if (_x == 1)
        {
            _scale.x = 0.5f;
        }
        else if (_x == -1)
        {
            _scale.x = -0.5f;
        }

        //scale�̕ύX��K�p
        transform.localScale = _scale;

        //HP��0�ɂȂ�����Q�[���I�[�o�[�V�[���Ɉړ�
        if (_hp <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    //�ړ��̌v�Z
    private void FixedUpdate()
    {

        if (_wallTouch == 0 || _wallTouch == horizontal)
        {
            rb.velocity = new Vector2(horizontal * _speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }

    }

    //�ڐG�����Ƃ��̃_���[�W����
    private void OnTriggerEnter2D(Collider2D collisionData)
    {
        if (collisionData.gameObject.CompareTag("Enemy"))//�ڐG�����I�u�W�F�N�g�̃^�O��"Enemy"�Ȃ�
        {
            _hp--;//HP���P���炷
            HPBar.fillAmount = _hp / _maxHP;//HPbar��HP/MaxHP�ɑ傫����ύX
        }
    }

    //�ڐG�����I�u�W�F�N�g���n�ʂ����肵�W�����v�\�ɂ���B
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))//�`�F�b�Nground���ǂ��ɂ��Ȃ��Ă邩�ڐG�����I�u�W�F�N�g�^�O��ground�Ȃ��
        {
            _canJump = true;//canJump��true�ɂ���B
        }

    }

    //�ڐG�����R���C�_�[�ɑ΂���@���x�N�g�����擾���ǂ��ǂ�������
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
