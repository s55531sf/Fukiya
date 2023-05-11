using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player_hp : MonoBehaviour
{
    public float max_hp = 100f;               //HPの最大量
    public static float now_hp = 100f;  //現在のHP
    public Slider slider;           //HPスライダー
    public Image damage_effect;     //被弾時のエフェクトのImage
    public menu_cmp menu_cmp;       //時間関係のスクリプト
    public battle_end battle_end;   //ゲーム終了関係のスクリプト

    private int regene_stop = 0;     //自然回復停止
    private int regene_stop_max = 8; //最大自然回復停止時間
    private float regene_val = 0.25f; //自然回復量

    void Start()
    {
        //難易度梅の時、最大体力1.5倍  攻撃受けた2.0s後自動回復開始 自然回復量増加
        if (select_cmp.dif_flag == 0)
        {
            max_hp = max_hp*1.5f;
            regene_stop_max = 5;
            regene_val = 0.3f;
        }
        now_hp = max_hp;
        slider.value = 1;  //Sliderを満タンにする。
        StartCoroutine("Regene");
    }

    void Update()
    {
        //すこしずつ画面の赤を透明にする
        this.damage_effect.color = Color.Lerp(this.damage_effect.color, Color.clear, Time.deltaTime);
    }

    

    public void player_damage(float damage) //damage:ダメージ 負の数なら回復
    {
        if (damage > 0) //ダメージが正の数なら(回復ではないのなら)
        {
            //画面を赤くする
            this.damage_effect.color = new Color(0.5f, 0f, 0f, 0.5f);
            regene_stop = regene_stop_max;//自然回復3.2s停止(難易度梅なら2.0s)
            Debug.Log("regene_stop" + regene_stop);
        }
 
        now_hp -= damage;
        if (now_hp > max_hp) //最大値を超えて回復するなら
        {
            now_hp = max_hp;//現在の酸素が最大値を超えないようにする
        }
        slider.value = now_hp / max_hp;//酸素バーを割合で表示

        //hpが0以下　かつ　時間停止中じゃないのなら
        if(now_hp <= 0 && !menu_cmp.stop)
        {
            //敗北処理
            battle_end.End_start(0);
        }
    }

    IEnumerator Regene()
    {
        yield return new WaitForSeconds(0.4f);//0.4s停止
        //自然回復停止期間ではないのなら   かつ  時間が止まっていないのなら
        if (regene_stop<=0 && !menu_cmp.stop)
        {
            //regene_valだけ回復
            Debug.Log("回復");
            player_damage(-regene_val);
        }
        else
        {
            Debug.Log("回復停止");
            //自然回復停止期間を減らす
            regene_stop--;
        }
        //HPバーを割合で表示
        slider.value = (float)now_hp / (float)max_hp;
        //再帰的に呼び出し
        StartCoroutine("Regene");
    }

}
