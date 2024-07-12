using UnityEngine;

public class enemy3 : MonoBehaviour
{
    /// <summary> 拡大するか縮小するかの判定用 </summary>
    private bool Scaling = true;
    /// <summary> Gameオブジェクト格納 </summary>
    [SerializeField] GameObject Enemy3;
    /// <summary> 変動するスケールの値 </summary>
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
        //ここ関数グラフでできそう。
        if (transform.position.y < -30)
        {
            Destroy(this.gameObject);
        }
        // Enemy3のスケールを(1,1,1)*iにする
        Enemy3.transform.localScale = Vector3.one * (1 + i);

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
            AudioSource.PlayClipAtPoint(yarareta, transform.position);
        }
    }
}
