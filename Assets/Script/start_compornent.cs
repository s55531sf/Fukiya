using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class start_compornent : MonoBehaviour
{
    public int flag = 0; //どのボタンか判断
    public Text text;//ボタンの上のテキスト
    public GameObject setting;//設定画面
    public GameObject setumei;//説明画面
    public GameObject main;//タイトル画面

    void Update()
    {
        Cursor.visible = true;
        Debug.Log("a" + setting_con.bgm_vol);
        Debug.Log("b" + setting_con.se_vol);
        Debug.Log("c" + setting_con.mou_vol);
    }

    //ボタンを押したとき
    public void OnClick()
    {
        Debug.Log("押された");
        if (flag == 0)
        {
            //シーン切り替え(難易度設定)
            SceneManager.LoadScene("Select");
        } else if (flag == 1)
        {
            //説明画面開く
            setumei.SetActive(true);
            main.SetActive(false);
        } else if (flag == 2)
        {
            //設定画面開く
            setting.SetActive(true);
            main.SetActive(false);
            //設定読み込み
            setting_con.bgm_vol =PlayerPrefs.GetFloat("BGM", 1.0f);
            setting_con.se_vol = PlayerPrefs.GetFloat("SE", 1.0f);
            setting_con.mou_vol = PlayerPrefs.GetFloat("Mou", 1.0f);

        } else if (flag == 3)
        {
            //ゲーム終了
            Application.Quit();

        }
        else if(flag == 4)
        {
            //設定画面閉じる
            setting.SetActive(false);
            main.SetActive(true);
            //設定保存
            PlayerPrefs.SetFloat("BGM", setting_con.bgm_vol);
            PlayerPrefs.SetFloat("SE", setting_con.se_vol);
            PlayerPrefs.SetFloat("Mou", setting_con.mou_vol);
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
