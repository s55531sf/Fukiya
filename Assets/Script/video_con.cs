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


    VideoClip[] array = new VideoClip[6];//se��z��Ɋi�[����

    void Start()
    {
        array[0] = video0;//HP����
        array[1] = video1;//���
        array[2] = video2;//����E�W�����v
        array[3] = video3;//�K�E�Q�[�W(������)
        array[4] = video4;//�K�E�Q�[�W(���߂₷�����@)
        array[5] = video5;//�ꎞ��~

    }

    //bgm�Đ�
    public void Video_Start(int num) //num:�Đ�����video
    {
        videoplayer.source = VideoSource.VideoClip; // ����\�[�X�̐ݒ�
        videoplayer.clip = array[num];
        videoplayer.Play();
    }

}
