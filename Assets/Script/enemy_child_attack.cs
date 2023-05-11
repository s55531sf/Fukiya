using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_child_attack : MonoBehaviour
{
    public GameObject slash1;
    public GameObject slash2;
    public GameObject enemy;
    private GameObject audio;//オーディオコントローラーのオブジェクト

    void Start()
    {
        //Audioコントローラーを取得
        audio = GameObject.FindWithTag("Audio");
    }

    public void Slash1()//横剣撃
    {
        GameObject attack = (GameObject)Instantiate(slash1, transform.position, enemy.transform.rotation);//剣撃生成
        Rigidbody attackRigidbody = attack.GetComponent<Rigidbody>();//剣撃のRigidbody取得
        attackRigidbody.AddForce(transform.forward * -430);  //発射
        //斬撃音
        audio.GetComponent<audio_con>().Se_Start(10);
    }

    public void Slash2()//縦剣撃
    {
        GameObject attack = (GameObject)Instantiate(slash2, transform.position, enemy.transform.rotation);//剣撃生成
        Rigidbody attackRigidbody = attack.GetComponent<Rigidbody>();//剣撃のRigidbody取得
        attackRigidbody.AddForce(transform.forward * -430);  //発射
        //斬撃音
        audio.GetComponent<audio_con>().Se_Start(10);
    }

}
