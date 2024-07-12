using UnityEngine;

public class ATK : MonoBehaviour
{
    [SerializeField] GameObject magic;//オブジェクト指定用の入れ物
    [SerializeField] GameObject hassya;//オブジェクト指定用の入れ物
    [SerializeField] GameObject PL;//オブジェクト指定用の入れ物
    [SerializeField] float m_timer = 1;
    float m_interval;

    // Start is called before the first frame update
    void Start()
    {
        m_interval = m_timer;
    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        Vector2 pos = hassya.transform.position;
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return)) && m_timer > m_interval)
        {
            Instantiate(magic, pos, PL.transform.rotation);
            m_timer = 0;
        }
    }
}
