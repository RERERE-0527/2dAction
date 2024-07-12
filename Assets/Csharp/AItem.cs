using UnityEngine;

public class AItem : ItemBase2D
{
    /// <summary>画像を変更するスプライトオブジェクト。</summary>
    [SerializeField] private GameObject TargetSprite;

    /// <summary>変更後の画像を持つスプライト。</summary>
    [SerializeField] private Sprite NextSprite;


    public override void Activate()
    {
        var spriteRenderer = TargetSprite.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = NextSprite;
    }
}
