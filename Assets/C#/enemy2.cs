using UnityEngine;

public class enemy2 : MonoBehaviour
{
    /// <summary> ���̏I�[�̃I�u�W�F�N�g </summary>
    [SerializeField] private Transform _LeftEdge;
    /// <summary> �E�̏I�[�̃I�u�W�F�N�g </summary>
    [SerializeField] private Transform _RightEdge;
    /// <summary> �ړ��X�s�[�h </summary>
    private float MoveSpeed = 3.0f;
    /// <summary> �E�ɍs�������ɍs�����̃X�C�b�` </summary>
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

    //��莞�Ԃ��Ƃɔ���
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
