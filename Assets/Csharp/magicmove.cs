using UnityEngine;

public class magicmove : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 20.0f;
    [SerializeField] float _lifeTime = 3;
    Rigidbody2D rb;
    PleyerMG PleyerMG;
    Vector3 _scaleM;
    float _time = 0;

    // Start is called before the first frame update
    void Start()
    {
        _scaleM = transform.localScale;
        GameObject Verniko = GameObject.Find("Verniko");
        PleyerMG = Verniko.GetComponent<PleyerMG>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.right * PleyerMG._scale.x * _moveSpeed, ForceMode2D.Impulse);
        _scaleM = PleyerMG._scale;
        transform.localScale = _scaleM;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _lifeTime)
        {
            Destroy(this.gameObject);
        }
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            Debug.Log("‰æ–ÊŠO");
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collisionData)
    {
        Destroy(this.gameObject);
    }
}
