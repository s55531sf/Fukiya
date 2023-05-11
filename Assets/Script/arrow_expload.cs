using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_expload : MonoBehaviour
{
    public GameObject damageUI;
    public GameObject exp_effect;
    private float dis;
    private int damage;
    private GameObject audio;//�I�[�f�B�I�R���g���[���[�̃I�u�W�F�N�g

    void Start()
    {
        //Audio�R���g���[���[���擾
        audio = GameObject.FindWithTag("Audio");
    }

    void OnTriggerEnter(Collider col) //�����̃I�u�W�F�N�g�ɓ���������
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy"); // �V�[����ɂ��邷�ׂĂ̓G��z��ɂ����
        Vector3 center = transform.position; //��̈ʒu
        GameObject effect = Instantiate(exp_effect, center, Quaternion.identity);
        Invoke("effect_destroy", 1.0f);
        //������
        audio.GetComponent<audio_con>().Se_Start(8);
        Debug.Log("����");
        Debug.Log(enemys.Length);

        if (enemys.Length != 0)//�G������Ȃ�
        {
            foreach (GameObject enemy in enemys)//�G�����鐔�����J��Ԃ�
            {
                dis = Vector3.Distance(enemy.transform.position, center); //��ƓG�̋���
                Debug.Log(dis);
                if (dis < 1)    //������1�ȓ��Ȃ�200�_���[�W
                {
                    damage = 200;
                }
                else if(dis<3)//1�ȏ㗣���ƃ_���[�W��������A3�ȏ㗣���ƃ_���[�W0
                {
                    damage = (int)(200-200*((dis-1)/2));
                }
                //Debug.Log(damage);
                if (dis < 3)
                {
                  //�_���[�W�e�L�X�g����
                  GameObject obj = Instantiate<GameObject>(damageUI,enemy.transform.position-Camera.main.transform.forward * 0.5f, Quaternion.identity);
                  obj.GetComponent<UI_damage>().SetDamage(damage); //UI�Ƀ_���[�W�ʂ𑗐M
                  enemy.GetComponent<enemy_hp>().TakeDamage(damage);//�G�̃_���[�W����
                }
            }
        
        }
        

        //���̃I�u�W�F�N�g��j�󂷂�
        Destroy(this.gameObject);
    }
   
}