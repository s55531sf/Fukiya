using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave_hit : MonoBehaviour
{
    public GameObject attack_effect;//�G�t�F�N�g�̃Q�[���I�u�W�F�N�g
    public int damage=10;//�U����
    bool attacked = false;//�U������

    void Start()
    {
        //0.2�b��ɍU��������폜
        Invoke("Attack_end", 0.5f);
        //2�b��ɃG�t�F�N�g���폜
        Invoke("Effect_destroy", 2.0f);
    }

    //��������̃I�u�W�F�N�g���ђʂ����Ƃ��ɌĂяo�����
    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);
        //�ђʂ����I�u�W�F�N�g�̃^�O���v���C���[���������@���@�U�����肪����Ƃ�
        if (!attacked && col.gameObject.tag=="Player")
        {
           // Debug.Log("���傤����");
            //�v���C���[�փ_���[�W����
            col.gameObject.GetComponent<player_hp>().player_damage(damage);
            attacked = false;
        }
    }

    void Attack_end()
    {
        //�U������폜
        attacked = true;
    }

    void Effect_destroy()
    {
        //�G�t�F�N�g������
        Destroy(attack_effect);
    }
    

}
