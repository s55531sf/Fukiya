using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setumei_btn : MonoBehaviour
{
    public int flag = 0; //どのボタンか判断
    public Text text;//ボタンの上のテキスト
    public GameObject setumei;//説明画面
    public GameObject main;//タイトル画面
    public setumei_con setumei_con;

    //ボタンを押したとき
    public void OnClick()
    {
        //設定画面閉じる
        if (flag == 0)
        {
            //説明画面閉じる
            setumei.SetActive(false);
            main.SetActive(true);
        //次へ
        }
        else if (flag == 1)
        {
            setumei_con.Setumei_Set(1);

        //前へ
        }
        else if (flag == 2)
        {
            setumei_con.Setumei_Set(-1);
        }

    }

    //ボタンの上にカーソルが乗った
    public void PointerEnter()
    {
        //ボタン選択時の演出
        text.GetComponent<Text>().color = Color.white;
        text.GetComponent<Outline>().effectColor = Color.black;
        Debug.Log("マウス通ったよ");
    }

    //ボタンの上からカーソルが離れた
    public void PointerExit()
    {
        //ボタン選択時の演出解除
        text.GetComponent<Text>().color = Color.black;
        text.GetComponent<Outline>().effectColor = Color.white;
        Debug.Log("マウス離れたよ");
    }
}
