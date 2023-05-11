using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_con : MonoBehaviour
{
    public AudioSource bgm_AudioSource;
    public AudioSource se_AudioSource;

    public AudioClip bgm;
    public AudioClip se1;
    public AudioClip se2;
    public AudioClip se3;
    public AudioClip se4;
    public AudioClip se5;
    public AudioClip se6;
    public AudioClip se7;
    public AudioClip se8;
    public AudioClip se9;
    public AudioClip se10;
    public AudioClip se11;
    public AudioClip se12;
    AudioClip[] array = new AudioClip[15];//seを配列に格納する

    void Start()
    {
        array[0] = se1;//矢の刺さる音
        array[1] = se2;//太鼓
        array[2] = se3;//「「始めっ！！！」」
        array[3] = se4;//太鼓(カカッ)
        array[4] = se5;//矢を放つ音
        array[5] = se6;//溜め完了
        array[6] = se7;//クリック音
        array[7] = se8;//エラー音
        array[8] = se9;//爆発音
        array[9] = se10;//剣をはじく音
        array[10] = se11;//斬撃を放つ音
        array[11] = se12;//着地音
    }

    void Update()
    {
        //音量取得
        bgm_AudioSource.volume = setting_con.bgm_vol;
        se_AudioSource.volume = setting_con.se_vol;
    }

    //bgm再生
    public void Bgm_Start()
    {
        bgm_AudioSource.PlayOneShot(bgm);
    }

    //se再生
    public void Se_Start(int num) //num:再生するse
    {
        se_AudioSource.PlayOneShot(array[num]);
    }

    //bgm停止
    public void Bgm_Stop()
    {
        bgm_AudioSource.Stop();
    }
}
