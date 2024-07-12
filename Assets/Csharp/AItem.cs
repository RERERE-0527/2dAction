using UnityEngine;

public class AItem : ItemBase2D
{
    /// <summary>�摜��ύX����X�v���C�g�I�u�W�F�N�g�B</summary>
    [SerializeField] private GameObject TargetSprite;

    /// <summary>�ύX��̉摜�����X�v���C�g�B</summary>
    [SerializeField] private Sprite NextSprite;


    public override void Activate()
    {
        var spriteRenderer = TargetSprite.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = NextSprite;
    }
}
