using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu_btn : MonoBehaviour
{
    public int flag = 0; //どのボタンか (0:続ける)
    public Text button_text;//ボタンにあるテキスト
    public GameObject menu;
    public menu_cmp menu_cmp;

    //ボタンを押したとき
    public void OnClick()
    {
        Debug.Log("押された");
        //時間停止解除
        if (flag == 0)
        {
            //カーソル表示
            Cursor.visible = true;
            menu_cmp.stop = false;
            menu.SetActive(false);
            Time.timeScale = 1f;
            //設定保存
            PlayerPrefs.SetFloat("BGM", setting_con.bgm_vol);
            PlayerPrefs.SetFloat("SE", setting_con.se_vol);
            PlayerPrefs.SetFloat("Mou", setting_con.mou_vol);

            //タイトルに戻る
        }
        else if (flag == 1)
        {
            menu_cmp.stop = false;
            menu.SetActive(false);
            Time.timeScale = 1f;
            //設定保存
            PlayerPrefs.SetFloat("BGM", setting_con.bgm_vol);
            PlayerPrefs.SetFloat("SE", setting_con.se_vol);
            PlayerPrefs.SetFloat("Mou", setting_con.mou_vol);
            //シーン遷移
            SceneManager.LoadScene("Title");
        }
    }

    //ボタンの上にカーソルが乗った
    public void PointerEnter()
    {
        //ボタン選択時の演出
        button_text.GetComponent<Text>().color = Color.white;
        button_text.GetComponent<Outline>().effectColor = Color.black;
        Debug.Log("マウス通ったよ");
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
