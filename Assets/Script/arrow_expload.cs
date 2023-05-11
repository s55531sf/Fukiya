using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_expload : MonoBehaviour
{
    public GameObject damageUI;
    public GameObject exp_effect;
    private float dis;
    private int damage;
    private GameObject audio;//オーディオコントローラーのオブジェクト

    void Start()
    {
        //Audioコントローラーを取得
        audio = GameObject.FindWithTag("Audio");
    }

    void OnTriggerEnter(Collider col) //何かのオブジェクトに当たったら
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy"); // シーン上にいるすべての敵を配列にいれる
        Vector3 center = transform.position; //矢の位置
        GameObject effect = Instantiate(exp_effect, center, Quaternion.identity);
        Invoke("effect_destroy", 1.0f);
        //爆発音
        audio.GetComponent<audio_con>().Se_Start(8);
        Debug.Log("爆発");
        Debug.Log(enemys.Length);

        if (enemys.Length != 0)//敵がいるなら
        {
            foreach (GameObject enemy in enemys)//敵がいる数だけ繰り返す
            {
                dis = Vector3.Distance(enemy.transform.position, center); //矢と敵の距離
                Debug.Log(dis);
                if (dis < 1)    //距離が1以内なら200ダメージ
                {
                    damage = 200;
                }
                else if(dis<3)//1以上離れるとダメージが下がり、3以上離れるとダメージ0
                {
                    damage = (int)(200-200*((dis-1)/2));
                }
                //Debug.Log(damage);
                if (dis < 3)
                {
                  //ダメージテキスト生成
                  GameObject obj = Instantiate<GameObject>(damageUI,enemy.transform.position-Camera.main.transform.forward * 0.5f, Quaternion.identity);
                  obj.GetComponent<UI_damage>().SetDamage(damage); //UIにダメージ量を送信
                  enemy.GetComponent<enemy_hp>().TakeDamage(damage);//敵のダメージ処理
                }
            }
        
        }
        

        //このオブジェクトを破壊する
        Destroy(this.gameObject);
    }
   
}