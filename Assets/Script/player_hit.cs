using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_hit : MonoBehaviour
{
    public GameObject attack_effect;
    public int damage=10;
    private bool attacked = false;

    void Start()
    {
        //5�b��ɃG�t�F�N�g���폜
        Invoke("Effect_destroy", 5.0f);
    }

    //���̃I�u�W�F�N�g���ђʂ����Ƃ��ɌĂяo�����
    void OnTriggerEnter(Collider col)
    {
        //�ђʂ����I�u�W�F�N�g��Enemy�Ȃ�
        if (col.CompareTag("Player"))
        {
            //���̃G�t�F�N�g���U���ς݂łȂ��̂Ȃ�
            if (!attacked)
            {
                Debug.Log("�U���I�I�I");
                //�_���[�W����
                col.gameObject.GetComponent<player_hp>().player_damage(damage);
                //���̃G�t�F�N�g���U���ς݂ɂ���
                attacked = true;
            }
        }
    }

    void Effect_destroy()
    {
        //���̃G�t�F�N�g������
        Destroy(attack_effect);
    }
}
