using UnityEngine;

public class enemy2 : MonoBehaviour
{
    /// <summary> 左の終端のオブジェクト </summary>
    [SerializeField] private Transform _LeftEdge;
    /// <summary> 右の終端のオブジェクト </summary>
    [SerializeField] private Transform _RightEdge;
    /// <summary> 移動スピード </summary>
    private float MoveSpeed = 3.0f;
    /// <summary> 右に行くか左に行くかのスイッチ </summary>
    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collisionData)
    {
        if (collisionData.gameObject.CompareTag("magic"))
        {
            Destroy(gameObject);
        }
    }

    //一定時間ごとに発動
    void FixedUpdate()
    {
        if (transform.position.x >= _RightEdge.position.x)
        {
            direction = -1;
        }

        if (transform.position.x <= _LeftEdge.position.x)
        {
            direction = 1;
        }

        transform.position = new Vector3(transform.position.x + MoveSpeed * Time.fixedDeltaTime * direction, 0, 0);
    }

}
