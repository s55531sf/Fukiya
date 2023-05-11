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
        //5秒後にエフェクトを削除
        Invoke("Effect_destroy", 5.0f);
    }

    //他のオブジェクトが貫通したときに呼び出される
    void OnTriggerEnter(Collider col)
    {
        //貫通したオブジェクトがEnemyなら
        if (col.CompareTag("Player"))
        {
            //このエフェクトが攻撃済みでないのなら
            if (!attacked)
            {
                Debug.Log("攻撃！！！");
                //ダメージ判定
                col.gameObject.GetComponent<player_hp>().player_damage(damage);
                //このエフェクトを攻撃済みにする
                attacked = true;
            }
        }
    }

    void Effect_destroy()
    {
        //このエフェクトを消去
        Destroy(attack_effect);
    }
}
