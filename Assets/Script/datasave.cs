using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class datasave : MonoBehaviour
{
    public timer_cmp timer_cmp;
    private int[] fasttime = new int[3];
    private int flag;   //���݂̓�Փx�擾
    private int now_sec;//����̋L�^(�b)

    void Start()
    {
        flag = select_cmp.dif_flag;//��Փx�i�[ 0:�~ 1:�| 2:��
        fasttime=data_load.time;
        Debug.Log(fasttime);
    }

    public void Time_save(int now_sec)
    {
        Debug.Log("fastume"+ fasttime[0]);
        Debug.Log("now_sec"+now_sec);
        //��Փx�~�̂Ƃ�
        if (select_cmp.dif_flag == 0 && now_sec < fasttime[0])
        {
            PlayerPrefs.SetInt("Ume", now_sec);
        }else if (select_cmp.dif_flag == 1 && now_sec < fasttime[1])
        {
            PlayerPrefs.SetInt("Take", now_sec);
        }else if (select_cmp.dif_flag == 2 && now_sec < fasttime[2])
        {
            PlayerPrefs.SetInt("Matu", now_sec);
        }
    }
}
