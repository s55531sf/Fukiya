using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class select_cmp : MonoBehaviour
{
    public data_load data_load;
    public static int dif_flag=0;//他のシーンに難易度を渡す
    public int flag = 0; //どの難易度か
    public Text button_text;//ボタンにあるテキスト
    public Text exp_text;       //難易度説明
    public Text timetext;   //最短撃破時間を表示するテキスト


    //ボタンを押したとき
    public void OnClick()
    {
        Debug.Log("押された");
        dif_flag = flag;//難易度を入力
        SceneManager.LoadScene("Battle");
    }

    //ボタンの上にカーソルが乗った
    public void PointerEnter()
    {
        //ボタン選択時の演出
        button_text.GetComponent<Text>().color = Color.white;
        button_text.GetComponent<Outline>().effectColor = Color.black;
        timetext.text = data_load.Load_time(flag);
        Debug.Log("マウス通ったよ");
        //今選択している難易度の説明
        if (flag == 0) //梅
        {
            exp_text.text = "自身の体力も高く、回復速度も速い。敵の攻撃も比較的避けやすい\n初心者におすすめな難易度";
        }else if (flag == 1)//竹
        {
            exp_text.text = "自身の体力は標準的で、敵の攻撃は少し避けにくい\n慣れてきた時におすすめな難易度";
        }else if (flag == 2)//松
        {
            exp_text.text = "自身の体力は標準的だが、敵の攻撃が激しくかなり避けにくい\n猛者におすすめの難易度";
        }
    }

    //ボタンの上からカーソルが離れた
    public void PointerExit()
    {
        //ボタン選択時の演出を解除
        button_text.GetComponent<Text>().color = Color.black;
        button_text.GetComponent<Outline>().effectColor = Color.clear;
        Debug.Log("マウス離れたよ");
    }
}
