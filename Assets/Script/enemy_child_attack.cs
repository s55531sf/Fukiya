using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_child_attack : MonoBehaviour
{
    public GameObject slash1;
    public GameObject slash2;
    public GameObject enemy;
    private GameObject audio;//I[fBIRg[[ΜIuWFNg

    void Start()
    {
        //AudioRg[[πζΎ
        audio = GameObject.FindWithTag("Audio");
    }

    public void Slash1()//‘
    {
        GameObject attack = (GameObject)Instantiate(slash1, transform.position, enemy.transform.rotation);//Ά¬
        Rigidbody attackRigidbody = attack.GetComponent<Rigidbody>();//ΜRigidbodyζΎ
        attackRigidbody.AddForce(transform.forward * -430);  //­Λ
        //aΉ
        audio.GetComponent<audio_con>().Se_Start(10);
    }

    public void Slash2()//c
    {
        GameObject attack = (GameObject)Instantiate(slash2, transform.position, enemy.transform.rotation);//Ά¬
        Rigidbody attackRigidbody = attack.GetComponent<Rigidbody>();//ΜRigidbodyζΎ
        attackRigidbody.AddForce(transform.forward * -430);  //­Λ
        //aΉ
        audio.GetComponent<audio_con>().Se_Start(10);
    }

}
