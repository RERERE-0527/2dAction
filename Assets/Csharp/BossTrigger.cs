using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] GameObject _kabe;
    public bool _Bosstrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        _kabe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collisionData)
    {
        if (collisionData.gameObject.CompareTag("Player"))
        {
            _kabe.SetActive(true);
            this.gameObject.SetActive(false);
            _Bosstrigger = true;
        }
    }
}
