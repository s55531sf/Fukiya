using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_o2 : MonoBehaviour
{
    int max_o2 = 10000;               //酸素の最大量
    public static int now_o2 =10000;  //現在の酸素
    public Slider slider;           //O2スライダー

    void Start()
    {
        slider.value = 1;  //Sliderを満タンにする。
        now_o2 = max_o2;
    }

    public void o2cost(int cost) //cost:消費する酸素 負の数なら回復
    {
       // Debug.Log(now_o2);
        now_o2 -= cost;
        if(now_o2 > max_o2) //最大値を超えて回復するなら
        {
            now_o2 = max_o2;//現在の酸素が最大値を超えないようにする
        }
        slider.value = (float)now_o2 / (float)max_o2; ;//酸素バーを割合で表示
    }
}
