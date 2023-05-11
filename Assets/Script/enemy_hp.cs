using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hp : MonoBehaviour //敵のHP関係の処理
{
    public float weight = 1;       //パワーゲージ上昇量の倍率
    public int Hp_max=100;  //最大HP
    public GameObject enemy;//敵のオブジェクト
    public battle_end battle_end;//終了関係のスクリプト
    public int flag_enemy = 0;//敵の種類を表す0:子侍 1:侍(boss) 2:剣撃
    private GameObject player;//プレーヤーのオブジェクト
    private GameObject audio;//オーディオコントローラーのオブジェクト
    private int Hp_now; //現在のHP
    void Start()
    {
        //プレイヤーのタグが付いたオブジェクトを検索
        player = GameObject.FindWithTag("Player");
        audio = GameObject.FindWithTag("Audio");
        Hp_now = Hp_max;//現在のHPを初期化
    }
    
    //ダメージ処理
    public void TakeDamage(int damage)
    {
        //SE再生
        if (flag_enemy != 2)
        {
            //矢の刺さる音
            audio.GetComponent<audio_con>().Se_Start(0);
        }
        else
        {
            //剣をはじく音
            audio.GetComponent<audio_con>().Se_Start(9);
        }

        //ダメージ処理
        Hp_now -= damage;
        //ダメージ量(最大60)*weight だけパワーをチャージする
        if (damage <= 60)
        {
            player.GetComponent<player_pow>().pow_up(damage * weight);
        }
        else
        {
            player.GetComponent<player_pow>().pow_up(60 * weight);
        }

        //敵の死亡処理
        if (Hp_now <= 0)
        { 
            EnemyDead();
        }
    }

    private void EnemyDead()
    {
        //敵を倒すと 20*weight だけパワーをチャージする
        player.GetComponent<player_pow>().pow_up(30 * weight);
        player.GetComponent<player_o2>().o2cost(-1000);
        if (flag_enemy==1)
        {
            //勝利判定
            battle_end.End_start(1);
        }
        //倒された敵を削除する
        Destroy(enemy);
    }
}
