using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class video_con : MonoBehaviour
{
    public VideoPlayer videoplayer;

    public VideoClip video0;
    public VideoClip video1;
    public VideoClip video2;
    public VideoClip video3;
    public VideoClip video4;
    public VideoClip video5;


    VideoClip[] array = new VideoClip[6];//seを配列に格納する

    void Start()
    {
        array[0] = video0;//HP減少
        array[1] = video1;//矢発射
        array[2] = video2;//回避・ジャンプ
        array[3] = video3;//必殺ゲージ(爆発矢)
        array[4] = video4;//必殺ゲージ(溜めやすい方法)
        array[5] = video5;//一時停止

    }

    //bgm再生
    public void Video_Start(int num) //num:再生するvideo
    {
        videoplayer.source = VideoSource.VideoClip; // 動画ソースの設定
        videoplayer.clip = array[num];
        videoplayer.Play();
    }

}
