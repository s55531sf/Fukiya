using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave_hit : MonoBehaviour
{
    public GameObject attack_effect;//エフェクトのゲームオブジェクト
    public int damage=10;//攻撃力
    bool attacked = false;//攻撃判定

    void Start()
    {
        //0.2秒後に攻撃判定を削除
        Invoke("Attack_end", 0.5f);
        //2秒後にエフェクトを削除
        Invoke("Effect_destroy", 2.0f);
    }

    //何かしらのオブジェクトが貫通したときに呼び出される
    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);
        //貫通したオブジェクトのタグがプレイヤーだった時　かつ　攻撃判定があるとき
        if (!attacked && col.gameObject.tag=="Player")
        {
           // Debug.Log("しょうげき");
            //プレイヤーへダメージ処理
            col.gameObject.GetComponent<player_hp>().player_damage(damage);
            attacked = false;
        }
    }

    void Attack_end()
    {
        //攻撃判定削除
        attacked = true;
    }

    void Effect_destroy()
    {
        //エフェクトを消去
        Destroy(attack_effect);
    }
    

}
