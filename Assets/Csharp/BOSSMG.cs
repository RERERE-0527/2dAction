using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class BOSSMG : MonoBehaviour
{
    [SerializeField] private int HP = 10;
    private SpriteRenderer renderer;
    [SerializeField] GameObject PL;

    [SerializeField] BoxCollider2D BoxCollider2D;
    [SerializeField] BoxCollider2D BoxCollider2D2;
    //[SerializeField] GameObject kabe;
    //Vector3 PLpos;
    float time;
    Vector2 _PLpos;
    Rigidbody2D rb;

    BossTrigger BossTrigger;
    float startTime;

    [SerializeField] AudioClip yarareta;
    [SerializeField] AudioClip damageSound;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        GameObject Bosstrigger = GameObject.Find("Bosstrigger");
        BossTrigger = Bosstrigger.GetComponent<BossTrigger>();
        rb = GetComponent<Rigidbody2D>();
        time = 2;
        BoxCollider2D.enabled = true;
        BoxCollider2D2.enabled = true;
    }

    private void Update()
    {
        _PLpos = PL.transform.position;

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
        if (HP < 1)
        {
            rb.AddTorque(300);
            StartCoroutine(Destoloy());
            AudioSource.PlayClipAtPoint(yarareta, transform.position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(damageSound, transform.position);
        }
    }
    private IEnumerator Destoloy()
    {
        BoxCollider2D.enabled = false;
        BoxCollider2D2.enabled = false;
        renderer.material.color = Color.blue;
        yield return new WaitForSeconds(1);
        
        SceneManager.LoadScene("ResultScene");
        
    }
    //移動処理
    private void BossMove()
    {
        time += Time.deltaTime;

        if (time > 3 && !(HP < 1))
        {
            Debug.Log("A");

            transform.DOMove(new Vector2(_PLpos.x, 25),0.2f);
            time = 0;
        }
    }
}
//プレイヤーに対してのみistrrigerにしたい。
//動きを追加したい
//飛び上がって踏みつぶす　BOSS transform.position=PL.transform.potision.x,5 0.5f秒かけてそこへ移動し落下
//保留　地面から触手が生える

