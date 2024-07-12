using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject _PL;

    [SerializeField] Vector3 _offset;  // �v���C���[�ƃJ�����̑��Έʒu = ���S�ɉf�������Ƃ��͎g��Ȃ�
    [SerializeField] float _smoothTime = 0.3f;  // �J�������v���C���[��ǐՂ���ۂ̃X���[�Y���̒����p�p�����[�^
    private Vector3 velocity = Vector3.zero;  // �J�����ړ����̑��x�x�N�g��
    // �v���C���[�ړ���ɃJ�����ړ������������̂ŁALateUpdate���g��
    Vector3 _PLpos;

 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        _PLpos = _PL.transform.position;
    }
    void LateUpdate()
    {
        Vector3 targetPosition = _PLpos + _offset;
        targetPosition.z = transform.position.z;
        this.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, _smoothTime);


        if (_PLpos == null)
        {
            this.gameObject.transform.parent = null;
        }
    }
}
//[SerializeField] Transform _player;  // �v���C���[��Transform
//[SerializeField] Vector3 _offset;  // �v���C���[�ƃJ�����̑��Έʒu = ���S�ɉf�������Ƃ��͎g��Ȃ�
//[SerializeField] float _smoothTime = 0.3f;  // �J�������v���C���[��ǐՂ���ۂ̃X���[�Y���̒����p�p�����[�^
//private Vector3 velocity = Vector3.zero;  // �J�����ړ����̑��x�x�N�g��
//                                          // �v���C���[�ړ���ɃJ�����ړ������������̂ŁALateUpdate���g��
//void LateUpdate()
//{
//    // �v���C���[�̈ʒu�ɃJ������Ǐ]������
//    if (_player != null)
//    {
//        Vector3 targetPosition = _player.position + _offset;
//        targetPosition.z = transform.position.z;
//        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, _smoothTime);
//    }

//    if (_player == null)
//    {
//        this.gameObject.transform.parent = null;
//    }
//}