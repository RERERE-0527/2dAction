using UnityEngine;
using UnityEngine.UI;

public class hpbar : MonoBehaviour
{
    float _hp = 5;//プレイヤーのHP
    float _maxHP;//プレイヤーのHP上限
    Image HPBar;//HPbarの画像を格納する箱
    
    void Start()
    {
        //画像格納
        HPBar = GameObject.Find("HPのイメージの名前").GetComponent<Image>();
        _maxHP = _hp;//HPの上限設定　代入
    }

    //コライダー同士が接触したときに発動
    private void OnTriggerEnter2D(Collider2D collisionData)
    {
        //接触したオブジェクトのタグが"Enemy"なら
        if (collisionData.gameObject.CompareTag("Enemy"))
        {
            //HPを１減らす
            _hp--;
            //HPbarを（HP/MaxHP）に大きさを変更
            HPBar.fillAmount = _hp / _maxHP;
        }
    }
}
