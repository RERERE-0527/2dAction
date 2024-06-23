using UnityEngine;

public class enemy1 : MonoBehaviour
{
    /// <summary> Rigidbody2D�i�[�p </summary>
    private Rigidbody2D rb;

    /// <summary> �W�����v���ɗ^����͂̑傫����ݒ� </summary>
    public float jumpStrength = 30f;

    [SerializeField] BoxCollider2D BoxCollider2D;
    [SerializeField] BoxCollider2D BoxCollider2D2;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2D�i�[
        rb = GetComponent<Rigidbody2D>();
        BoxCollider2D.enabled = true;
        BoxCollider2D2.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -30)
        {
            Destroy(this.gameObject);
        }
    }

    //�R���C�_�[���m���Փ˂����Ƃ��ɔ���
    private void OnCollisionEnter2D(Collision2D collisionData)
    {
        //�Փ˂����I�u�W�F�N�g��Ground�Ƃ����^�O�����Ă������ɔ���
        if (collisionData.gameObject.CompareTag("Ground"))
        {
            //������ɗ͂�������
            rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
        }
    }

    //�R���C�_�[���m���N�������Ƃ��ɔ���
    private void OnTriggerEnter2D(Collider2D collisionData)
    {
        //�N�������I�u�W�F�N�g��magic�̃^�O�����Ă������ɔ���
        if (collisionData.gameObject.CompareTag("magic"))
        {
            rb.velocity = new Vector2(2, 5);
            rb.AddTorque(500);
            BoxCollider2D.enabled = false;
            BoxCollider2D2.enabled = false;
        }
    }

}
