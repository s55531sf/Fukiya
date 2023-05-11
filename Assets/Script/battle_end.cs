using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battle_end : MonoBehaviour
{
    public menu_cmp menu_cmp;
    public datasave datasave;
    public timer_cmp timer_cmp;
    public GameObject playerui;
    public GameObject endeffect;
    public GameObject result;
    public GameObject win;
    public GameObject lose;
    public GameObject btn;
    public Text endtime_text;
    public Text endtime;
    public Text fastendtime_text;
    public Text fastendtime;
    public audio_con audio_con;

    //I—¹ˆ—ŠJn
    public void End_start(int flag)
    {
        //ƒ}ƒEƒXƒJ[ƒ\ƒ‹•\¦
        Cursor.visible = true;
        //ŠÔ’â~
        menu_cmp.stop = true;
        endeffect.SetActive(true);
        Invoke("End_Sound", 0.2f);
        endtime.text = "";
        endtime_text.text = "";
        fastendtime.text = "";
        fastendtime_text.text = "";
        //”s–k‚µ‚½ê‡
        if (flag == 0)
        {           
            Debug.Log("Lose");
            StartCoroutine("Lose");
            //Ÿ—˜‚µ‚½ê‡
        }
        else if(flag == 1)
        {
            Debug.Log("Win");            
            StartCoroutine("Win");
        }
    }

    void End_Sound()
    {
        audio_con.Se_Start(3);//‘¾ŒÛ‚Ì‰¹(ƒJƒJƒb)
        audio_con.Bgm_Stop();//bgm’â~
    }

    IEnumerator Win()
    {
        datasave.Time_save((timer_cmp.min * 60) + (int)timer_cmp.sec);
        yield return new WaitForSeconds(2);
        audio_con.Se_Start(1);//‘¾ŒÛ‚Ì‰¹
        playerui.SetActive(false);
        result.SetActive(true);
        yield return new WaitForSeconds(1);
        audio_con.Se_Start(1);//‘¾ŒÛ‚Ì‰¹
        win.SetActive(true);
        yield return new WaitForSeconds(1);
        btn.SetActive(true);
        audio_con.Se_Start(1);//‘¾ŒÛ‚Ì‰¹
        endtime.text = timer_cmp.min.ToString("00") + ":" + ((int)timer_cmp.sec).ToString("00");
        endtime_text.text = "Œ‚”jŠÔ";
        fastendtime_text.text = "Å’ZŒ‚”jŠÔ";
        fastendtime.text = ((int)data_load.time[select_cmp.dif_flag] / 60).ToString("00") + ":" + (data_load.time[select_cmp.dif_flag] - (((int)data_load.time[select_cmp.dif_flag] / 60) * 60)).ToString("00");

    }

    IEnumerator Lose()
    {
        btn.SetActive(true);
        yield return new WaitForSeconds(2);
        audio_con.Se_Start(1);//‘¾ŒÛ‚Ì‰¹
        playerui.SetActive(false);
        result.SetActive(true);
        yield return new WaitForSeconds(1);
        audio_con.Se_Start(1);//‘¾ŒÛ‚Ì‰¹
        lose.SetActive(true);
        yield return new WaitForSeconds(1);
        audio_con.Se_Start(1);//‘¾ŒÛ‚Ì‰¹
        endtime.text = "--:--";
        endtime_text.text = "Œ‚”jŠÔ";
        endtime_text.text = "Œ‚”jŠÔ";
        fastendtime_text.text = "Å’ZŒ‚”jŠÔ";
        fastendtime.text = ((int)data_load.time[select_cmp.dif_flag] / 60).ToString("00") + ":" + (data_load.time[select_cmp.dif_flag] - (((int)data_load.time[select_cmp.dif_flag] / 60) * 60)).ToString("00");
    }
}
