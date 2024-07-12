using UnityEngine;

public class enemy3 : MonoBehaviour
{
    /// <summary> �g�傷�邩�k�����邩�̔���p </summary>
    private bool Scaling = true;
    /// <summary> Game�I�u�W�F�N�g�i�[ </summary>
    [SerializeField] GameObject Enemy3;
    /// <summary> �ϓ�����X�P�[���̒l </summary>
    float i = 1;
    float n = 1;
    float theta = 0;

    [SerializeField] BoxCollider2D BoxCollider2D;
    [SerializeField] BoxCollider2D BoxCollider2D2;

    private Rigidbody2D rb;

    [SerializeField] AudioClip yarareta;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D.enabled = true;
        BoxCollider2D2.enabled = true;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        theta += (2 * Mathf.PI / 360);
        i = Mathf.Abs(Mathf.Sin(theta));
        //�����֐��O���t�łł������B
        if (transform.position.y < -30)
        {
            Destroy(this.gameObject);
        }
        // Enemy3�̃X�P�[����(1,1,1)*i�ɂ���
        Enemy3.transform.localScale = Vector3.one * (1 + i);

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
            AudioSource.PlayClipAtPoint(yarareta, transform.position);
        }
    }
}
