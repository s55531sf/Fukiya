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
    private int speed;//­Λ¬x

    void Start()
    {
        flag = select_cmp.dif_flag;
        if (flag == 0)//οΥx~
        {
            speed = 400;

        }else if(flag == 1)//οΥx|
        {
            speed = 500;

        }else if (flag == 2)//οΥxΌ
        {
            speed = 600;
        }
    }

    public void Slash1()//‘
    {
        GameObject attack = (GameObject)Instantiate(slash1, transform.position, enemy.transform.rotation);//Ά¬
        Rigidbody attackRigidbody = attack.GetComponent<Rigidbody>();//ΜRigidbodyζΎ
        attackRigidbody.AddForce(transform.forward *-speed);  //­Λ(¬xΝspeed*4ΛΆ)
        audio_con.Se_Start(10);
    }

    public void Slash2()//c
    {
        GameObject attack = (GameObject)Instantiate(slash2, transform.position, enemy.transform.rotation);//Ά¬
        Rigidbody attackRigidbody = attack.GetComponent<Rigidbody>();//ΜRigidbodyζΎ
        attackRigidbody.AddForce(transform.forward * -speed);  //­Λ(¬xΝspeed*4ΛΆ)
        audio_con.Se_Start(10);
    }

    public void Wave()//Υg
    {
        pos = transform.position;
        pos.y -= 0.5f;
        GameObject attack = (GameObject)Instantiate(wave, pos, transform.rotation);//ΥgΆ¬
        attack.transform.eulerAngles = new Vector3(90, 0, 0);//Υgπx²πSΙ90xρ]
    }
}
