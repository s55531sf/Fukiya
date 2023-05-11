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

    //�I�������J�n
    public void End_start(int flag)
    {
        //�}�E�X�J�[�\���\��
        Cursor.visible = true;
        //���Ԓ�~
        menu_cmp.stop = true;
        endeffect.SetActive(true);
        Invoke("End_Sound", 0.2f);
        endtime.text = "";
        endtime_text.text = "";
        fastendtime.text = "";
        fastendtime_text.text = "";
        //�s�k�����ꍇ
        if (flag == 0)
        {           
            Debug.Log("Lose");
            StartCoroutine("Lose");
            //���������ꍇ
        }
        else if(flag == 1)
        {
            Debug.Log("Win");            
            StartCoroutine("Win");
        }
    }

    void End_Sound()
    {
        audio_con.Se_Start(3);//���ۂ̉�(�J�J�b)
        audio_con.Bgm_Stop();//bgm��~
    }

    IEnumerator Win()
    {
        datasave.Time_save((timer_cmp.min * 60) + (int)timer_cmp.sec);
        yield return new WaitForSeconds(2);
        audio_con.Se_Start(1);//���ۂ̉�
        playerui.SetActive(false);
        result.SetActive(true);
        yield return new WaitForSeconds(1);
        audio_con.Se_Start(1);//���ۂ̉�
        win.SetActive(true);
        yield return new WaitForSeconds(1);
        btn.SetActive(true);
        audio_con.Se_Start(1);//���ۂ̉�
        endtime.text = timer_cmp.min.ToString("00") + ":" + ((int)timer_cmp.sec).ToString("00");
        endtime_text.text = "���j����";
        fastendtime_text.text = "�ŒZ���j����";
        fastendtime.text = ((int)data_load.time[select_cmp.dif_flag] / 60).ToString("00") + ":" + (data_load.time[select_cmp.dif_flag] - (((int)data_load.time[select_cmp.dif_flag] / 60) * 60)).ToString("00");

    }

    IEnumerator Lose()
    {
        btn.SetActive(true);
        yield return new WaitForSeconds(2);
        audio_con.Se_Start(1);//���ۂ̉�
        playerui.SetActive(false);
        result.SetActive(true);
        yield return new WaitForSeconds(1);
        audio_con.Se_Start(1);//���ۂ̉�
        lose.SetActive(true);
        yield return new WaitForSeconds(1);
        audio_con.Se_Start(1);//���ۂ̉�
        endtime.text = "--:--";
        endtime_text.text = "���j����";
        endtime_text.text = "���j����";
        fastendtime_text.text = "�ŒZ���j����";
        fastendtime.text = ((int)data_load.time[select_cmp.dif_flag] / 60).ToString("00") + ":" + (data_load.time[select_cmp.dif_flag] - (((int)data_load.time[select_cmp.dif_flag] / 60) * 60)).ToString("00");
    }
}
