using UnityEngine;
using UnityEngine.UI;

public class hpbar : MonoBehaviour
{
    float _hp = 5;//�v���C���[��HP
    float _maxHP;//�v���C���[��HP���
    Image HPBar;//HPbar�̉摜���i�[���锠
    
    void Start()
    {
        //�摜�i�[
        HPBar = GameObject.Find("HP�̃C���[�W�̖��O").GetComponent<Image>();
        _maxHP = _hp;//HP�̏���ݒ�@���
    }

    //�R���C�_�[���m���ڐG�����Ƃ��ɔ���
    private void OnTriggerEnter2D(Collider2D collisionData)
    {
        //�ڐG�����I�u�W�F�N�g�̃^�O��"Enemy"�Ȃ�
        if (collisionData.gameObject.CompareTag("Enemy"))
        {
            //HP���P���炷
            _hp--;
            //HPbar���iHP/MaxHP�j�ɑ傫����ύX
            HPBar.fillAmount = _hp / _maxHP;
        }
    }
}
