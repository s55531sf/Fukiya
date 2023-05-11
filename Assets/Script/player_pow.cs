using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_pow : MonoBehaviour
{
    public Slider slider;   // パワーゲージ
    public static float now_pow=0;
    public float max_pow = 300;
    public audio_con audio_con;

    void Start()
    {
        Invoke("slider_reset", 0.01f);
        Debug.Log("slider"+slider.value);
    }

    void slider_reset()
    {
        slider.value = 0;
        now_pow = 0;
    }

    public void pow_up(float charge) //charge:チャージされる量
    {
        now_pow += charge;
        if (now_pow > max_pow) //最大値を超えて回復するなら
        {
            now_pow = max_pow;//現在の酸素が最大値を超えないようにする
        }
        //powが最大なら
        if(now_pow == max_pow)
        {
            //チャージ音
            audio_con.Se_Start(5);
        }
        slider.value = now_pow / max_pow; //酸素バーを割合で表示
    }

    public void pow_reset() //パワーゲージリセット
    {
        now_pow = 0;
        slider.value = 0;
    }
}
