using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_child_attack : MonoBehaviour
{
    public GameObject slash1;
    public GameObject slash2;
    public GameObject enemy;
    private GameObject audio;//�I�[�f�B�I�R���g���[���[�̃I�u�W�F�N�g

    void Start()
    {
        //Audio�R���g���[���[���擾
        audio = GameObject.FindWithTag("Audio");
    }

    public void Slash1()//������
    {
        GameObject attack = (GameObject)Instantiate(slash1, transform.position, enemy.transform.rotation);//��������
        Rigidbody attackRigidbody = attack.GetComponent<Rigidbody>();//������Rigidbody�擾
        attackRigidbody.AddForce(transform.forward * -430);  //����
        //�a����
        audio.GetComponent<audio_con>().Se_Start(10);
    }

    public void Slash2()//�c����
    {
        GameObject attack = (GameObject)Instantiate(slash2, transform.position, enemy.transform.rotation);//��������
        Rigidbody attackRigidbody = attack.GetComponent<Rigidbody>();//������Rigidbody�擾
        attackRigidbody.AddForce(transform.forward * -430);  //����
        //�a����
        audio.GetComponent<audio_con>().Se_Start(10);
    }

}
