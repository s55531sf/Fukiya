using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_attack : MonoBehaviour
{
    public GameObject slash1;
    public GameObject slash2;
    public GameObject wave;
    public GameObject enemy;
    public audio_con audio_con;

    private Vector3 pos;
    private int flag;
    private int speed;//���ˑ��x

    void Start()
    {
        flag = select_cmp.dif_flag;
        if (flag == 0)//��Փx�~
        {
            speed = 400;

        }else if(flag == 1)//��Փx�|
        {
            speed = 500;

        }else if (flag == 2)//��Փx��
        {
            speed = 600;
        }
    }

    public void Slash1()//������
    {
        GameObject attack = (GameObject)Instantiate(slash1, transform.position, enemy.transform.rotation);//��������
        Rigidbody attackRigidbody = attack.GetComponent<Rigidbody>();//������Rigidbody�擾
        attackRigidbody.AddForce(transform.forward *-speed);  //����(���x��speed*4�ˑ�)
        audio_con.Se_Start(10);
    }

    public void Slash2()//�c����
    {
        GameObject attack = (GameObject)Instantiate(slash2, transform.position, enemy.transform.rotation);//��������
        Rigidbody attackRigidbody = attack.GetComponent<Rigidbody>();//������Rigidbody�擾
        attackRigidbody.AddForce(transform.forward * -speed);  //����(���x��speed*4�ˑ�)
        audio_con.Se_Start(10);
    }

    public void Wave()//�Ռ��g
    {
        pos = transform.position;
        pos.y -= 0.5f;
        GameObject attack = (GameObject)Instantiate(wave, pos, transform.rotation);//�Ռ��g����
        attack.transform.eulerAngles = new Vector3(90, 0, 0);//�Ռ��g��x���𒆐S��90�x��]
    }
}
