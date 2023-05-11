using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrow_shot : MonoBehaviour
{
    public GameObject Player;   //プレイヤー
    public GameObject arrow_weak;    //通常矢(弱)
    public GameObject arrow_normal;  //通常矢(中)
    public GameObject arrow_strong;  //通常矢(強)
    public GameObject arrow_exp;     //爆発矢
    public float speed;    //矢の発射速度
    public Slider slider;  //矢のチャージを示すスライダー
    public player_o2 player_o2;//プレイヤーの酸素関係のスクリプト
    public player_pow player_pow;//プレイヤーのパワー関係のスクリプト
    public menu_cmp menu_cmp;//メニュー関係のスクリプト
    public audio_con audio_con;//音声関係のスクリプト
    float mouse;
    int mode = 0;//発射する矢 0=通常 1=爆発

    void Start()
    {
        //スライダーリセット
        slider.value = 0;
    }


    void Update()
    {

        if (Input.GetKey(KeyCode.E) && player_pow.now_pow == player_pow.max_pow && !menu_cmp.stop)//Eキーが押された かつ 時間が止まっていない
        {
            mode = 1;//発射物:爆発矢
            player_pow.pow_reset();
        }

        if (Input.GetMouseButton(0) && !menu_cmp.stop && player_o2.now_o2 > 2)    //左クリック押されている かつ 時間が止まっていない かつ 酸素が2より上
        {
            if (speed < 500 && player_o2.now_o2 > 2) //speedが500未満　かつ　現在の酸素が3以上  かつ　mode=0のとき
            {
                //矢の速度増加、酸素消費
                speed+= 500 * Time.deltaTime;
                player_o2.o2cost(2);
                if(speed > 500)
                {
                    speed = 500;
                }
                //チャージバーを割合で表示
                slider.value = (float)speed / 500 ;
            }

        }else if(Input.GetMouseButtonDown(0) && !menu_cmp.stop && player_o2.now_o2 <= 2) //酸素が2以下なら
        {
            //警告音
            audio_con.Se_Start(7);
        }
        if (Input.GetMouseButtonUp(0) && !menu_cmp.stop)  //左クリックが離されたとき かつ 時間が止まっていない
        {
            if(mode == 0)//通常矢
            {
                //矢を放つ音再生
                audio_con.Se_Start(4);
                if (speed > 1 && speed < 201)//speedが1から200のとき 通常矢 弱攻撃
             {
                 Shot1(); 
             }else if(speed > 201 && speed < 500)//speedが201から499のとき　通常矢 中攻撃
             {
                 Shot2();
             }
             else if(speed==500) //speedが500(max)のとき 通常矢 強攻撃
             {
                 Shot3();
             }
             
            }else if (mode == 1)
            {
                Shot4();//爆発矢
                mode = 0;//通常矢にもどす
            }

            slider.value = 0;
            speed = 0; //speedリセット
        }
    }

    public void Shot1()//通常矢 弱攻撃
    {
        GameObject arrow = (GameObject)Instantiate(arrow_weak, transform.position, Player.transform.rotation);//矢生成
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();//矢のRigidbody取得
        arrowRigidbody.AddForce(transform.forward * speed*4);  //発射(速度はspeed*4依存)
    }
    public void Shot2()//通常矢 中攻撃
    {
        GameObject arrow = (GameObject)Instantiate(arrow_normal, transform.position, Player.transform.rotation);//矢生成
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();//矢のRigidbody取得
        arrowRigidbody.AddForce(transform.forward * speed * 4);  //発射(速度はspeed*4依存)
    }
    public void Shot3()//通常矢 強攻撃
    {
        GameObject arrow = (GameObject)Instantiate(arrow_strong, transform.position, Player.transform.rotation);//矢生成
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();//矢のRigidbody取得
        arrowRigidbody.AddForce(transform.forward * speed * 4);  //発射(速度はspeed*4依存)
    }
    public void Shot4()//通常矢 強攻撃
    {
        GameObject arrow = (GameObject)Instantiate(arrow_exp, transform.position, Player.transform.rotation);//矢生成
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();//矢のRigidbody取得
        arrowRigidbody.AddForce(transform.forward * speed * 3);  //発射(速度はspeed*3依存)
    }
}