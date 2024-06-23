using UnityEngine;

public class enemy1 : MonoBehaviour
{
    /// <summary> Rigidbody2D格納用 </summary>
    private Rigidbody2D rb;

    /// <summary> ジャンプ時に与える力の大きさを設定 </summary>
    public float jumpStrength = 30f;

    [SerializeField] BoxCollider2D BoxCollider2D;
    [SerializeField] BoxCollider2D BoxCollider2D2;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2D格納
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

    //コライダー同士が衝突したときに発動
    private void OnCollisionEnter2D(Collision2D collisionData)
    {
        //衝突したオブジェクトにGroundというタグがついていた時に発動
        if (collisionData.gameObject.CompareTag("Ground"))
        {
            //上方向に力を加える
            rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
        }
    }

    //コライダー同士が侵入したときに発動
    private void OnTriggerEnter2D(Collider2D collisionData)
    {
        //侵入したオブジェクトにmagicのタグがついていた時に発動
        if (collisionData.gameObject.CompareTag("magic"))
        {
            rb.velocity = new Vector2(2, 5);
            rb.AddTorque(500);
            BoxCollider2D.enabled = false;
            BoxCollider2D2.enabled = false;
        }
    }

}
