using UnityEngine;

public class TanukiItem : ItemBase2D
{
    /// <summary>画像を変更するスプライトオブジェクト。</summary>
    [SerializeField] private GameObject TargetSprite;

    /// <summary>変更後の画像を持つスプライト。</summary>
    [SerializeField] private Sprite NextSprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Activate()
    {
        var spriteRenderer = TargetSprite.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = NextSprite;
    }
}
