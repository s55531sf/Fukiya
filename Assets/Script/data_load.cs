using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data_load : MonoBehaviour
{
    public static int[] time = new int[3];//�e��Փx�̍ŒZ���j����
    private int min;
    private int sec;
    void Start()
    {
        time[0] = PlayerPrefs.GetInt("Ume",3599);//�~�̍ŒZ���j����
        time[1] = PlayerPrefs.GetInt("Take",3599);//�|�̍ŒZ���j����
        time[2] = PlayerPrefs.GetInt("Matu",3599);//���̍ŒZ���j����
    }

    public string Load_time(int flag)
    {
        Debug.Log("time0"+time[flag]);
        Debug.Log("min"+(int)time[flag] / 60);
        if (time[flag] > 0)
        {
        min = (int)time[flag] / 60;
        sec = time[flag] - (min * 60);
        return min.ToString("00") + ":" + sec.ToString("00");
        }
        else
        {
            return "--:--";
        }
    }
    
}
