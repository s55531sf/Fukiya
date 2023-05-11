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
        
        //ESC�L�[�������ꂽ�Ƃ�
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (stop)//stop����
            {
                Cursor.visible = false;
                menu.SetActive(false);
                Time.timeScale = 1f;
                stop = false;
                //�ݒ�ۑ�
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
                //�ݒ�ǂݍ���
                setting_con.bgm_vol = PlayerPrefs.GetFloat("BGM", 1.0f);
                setting_con.se_vol = PlayerPrefs.GetFloat("SE", 1.0f);
                setting_con.mou_vol = PlayerPrefs.GetFloat("Mou", 1.0f);

            }
        }
    }
}
