using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BOSSMG : MonoBehaviour
{
    [SerializeField] private int HP = 10;
    private SpriteRenderer renderer;
    [SerializeField] GameObject PL;
    [SerializeField] GameObject kabe;
    //Vector3 PLpos;
    float time;
    Vector2 _PLpos;
    Rigidbody2D rb;

    BossTrigger BossTrigger;
    float startTime;

    Vector2 _Pos;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        GameObject Bosstrigger = GameObject.Find("Bosstrigger");
        BossTrigger = Bosstrigger.GetComponent<BossTrigger>();
        rb = GetComponent<Rigidbody2D>();
        _Pos = transform.position;


    }

    private void Update()
    {
        _PLpos = PL.transform.position;
        _Pos = transform.position;

        if (BossTrigger._Bosstrigger == true)
        {
            BossMove();
        }



    }

    private void OnTriggerEnter2D(Collider2D collisionData)
    {
        if (collisionData.gameObject.CompareTag("magic"))
        {
            StartCoroutine(collar());
            damage();
        }
    }

    //色を変える
    private IEnumerator collar()
    {
        renderer.material.color = Color.blue;
        yield return new WaitForSeconds(0.1f);
        renderer.material.color = Color.white;
    }

    //HPを減らす
    private void damage()
    {
        HP--;
        Debug.Log(HP);
        if (HP < 0)
        {
            rb.AddTorque(300);
            SceneManager.LoadScene("ResultScene");
            Destroy(gameObject);

        }
    }

    //移動処理
    private void BossMove()
    {
        time += Time.deltaTime;

        if (time > 3)
        {
            //Debug.Log("A");


            _Pos = Vector2.Lerp(new Vector2(1, 1), new Vector2(1, 10), Time.deltaTime);
            time = 0;
        }
    }
}
//プレイヤーに対してのみistrrigerにしたい。
//動きを追加したい
//飛び上がって踏みつぶす　BOSS transform.position=PL.transform.potision.x,5 0.5f秒かけてそこへ移動し落下
//保留　地面から触手が生える

