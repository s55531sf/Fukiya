using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_cmp : MonoBehaviour
{
    public bool stop = false;
    public GameObject menu;
    // Update is called once per frame
    void Update()
    {
        
        //ESCキーが押されたとき
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (stop)//stop解除
            {
                Cursor.visible = false;
                menu.SetActive(false);
                Time.timeScale = 1f;
                stop = false;
                //設定保存
                PlayerPrefs.SetFloat("BGM", setting_con.bgm_vol);
                PlayerPrefs.SetFloat("SE", setting_con.se_vol);
                PlayerPrefs.SetFloat("Mou", setting_con.mou_vol);
            }
            else//stop
            {
                Cursor.visible = true;
                menu.SetActive(true);
                Time.timeScale = 0f;
                stop = true;
                //設定読み込み
                setting_con.bgm_vol = PlayerPrefs.GetFloat("BGM", 1.0f);
                setting_con.se_vol = PlayerPrefs.GetFloat("SE", 1.0f);
                setting_con.mou_vol = PlayerPrefs.GetFloat("Mou", 1.0f);

            }
        }
    }
}
