using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PleyerMG : MonoBehaviour
{
    Rigidbody2D rb;//Rigidbody2D格納箱
    [SerializeField] int _speed = 10;//速度変数

    [SerializeField] float _jumpStrength = 100f;//ジャンプの力
    bool _checkGround = true;//地面との設置判定に使うやつ？
    bool _canJump = true;//ジャンプが可能かどうかの判定に使うやつ？

    float _hp = 5;//プレイヤーのHP
    float _maxHP;//プレイヤーのHP上限
    Image HPBar;//HPbarの画像を格納する箱

    float _x;
    float _wallTouch;

    public Vector3 _scale;//transformの

    [SerializeField] float _maxSpeed = 10.0f;
    float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//Rigidbody2D格納
        HPBar = GameObject.Find("HPbar").GetComponent<Image>();//画像格納
        _maxHP = _hp;//HPの上限設定　代入
    }
    // Update is called once per frame

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        _scale = transform.localScale;
        _x = Input.GetAxisRaw("Horizontal");//平行入力検知
        float y = Input.GetAxis("Vertical");//上下入力検知

        if (_canJump && Input.GetKeyDown(KeyCode.W))//canJumpがturuかつ(W)が押されたとき
        {
            rb.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);//上方向に移動値を加算
            _canJump = !_checkGround;//なんか着地検知につかうやつ？
        }

        if (_x == 1)
        {
            _scale.x = 0.5f;
        }
        else if (_x == -1)
        {
            _scale.x = -0.5f;
        }

        transform.localScale = _scale;
        if (_hp <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(speed * _x, rb.velocity.y);

        //if (rb.velocity.x > _maxSpeed && 0 < _x)
        //{
        //    rb.velocity = new Vector2(_maxSpeed, rb.velocity.y);

        //}
        //else if (rb.velocity.x < _maxSpeed * -1 && _x < 0)
        //{
        //    rb.velocity = new Vector2(_maxSpeed * -1, rb.velocity.y);

        //}
        if (_wallTouch == 0 || _wallTouch == horizontal)
        {
            rb.velocity = new Vector2(horizontal * _speed, rb.velocity.y);
        }

    }
    private void OnTriggerEnter2D(Collider2D collisionData)
    {
        if (collisionData.gameObject.CompareTag("Enemy"))//接触したオブジェクトのタグが"Enemy"なら
        {
            _hp--;//HPを１減らす
            HPBar.fillAmount = _hp / _maxHP;//HPbarをHP/MaxHPに大きさを変更
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_checkGround && collision.gameObject.CompareTag("Ground"))//チェックgroundがどうにかなってるかつ接触したオブジェクトタグがgroundならば
        {      
            _canJump = true;//canJumpをtrueにする。
        }
        
    }
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
//やることリスト

//マップをもっと広く複雑に移動する床とかアスレチック要素付け足したい
//*** BOSSの動き追加 動き案一飛び上がって踏みつける
//*** ボス戦時に空中に足場を作る。
//壁のぼり防止（保留）
//射撃に角度つけたい

//BGM追加したい。タイトル、クリア、ゲームオーバー、ゲーム画面
//SE 攻撃　ボタン入力　撃破

//タイトル画面とか背景の草とか軽くアニメーションさせたい

//プレイヤーをアニメーションさせたい！素材も技術も足りない！ボーンを使ったアニメーションは技術的にムズイ間に合わない
//よってパラパラ漫画方式で描画したい。最低でも走っている絵と止まっている絵を作りたい。欲を言えば攻撃モーションも作りたい

//プレイヤーと地面は反発させたい、敵と地面は反発させたい。プレイヤーと敵は通り抜けてほしい、けど接触の判定のみ欲しい
