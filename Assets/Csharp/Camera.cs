using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject _PL;

    [SerializeField] Vector3 _offset;  // プレイヤーとカメラの相対位置 = 中心に映したいときは使わない
    [SerializeField] float _smoothTime = 0.3f;  // カメラがプレイヤーを追跡する際のスムーズさの調整用パラメータ
    private Vector3 velocity = Vector3.zero;  // カメラ移動時の速度ベクトル
    // プレイヤー移動後にカメラ移動をさせたいので、LateUpdateを使う
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
//[SerializeField] Transform _player;  // プレイヤーのTransform
//[SerializeField] Vector3 _offset;  // プレイヤーとカメラの相対位置 = 中心に映したいときは使わない
//[SerializeField] float _smoothTime = 0.3f;  // カメラがプレイヤーを追跡する際のスムーズさの調整用パラメータ
//private Vector3 velocity = Vector3.zero;  // カメラ移動時の速度ベクトル
//                                          // プレイヤー移動後にカメラ移動をさせたいので、LateUpdateを使う
//void LateUpdate()
//{
//    // プレイヤーの位置にカメラを追従させる
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