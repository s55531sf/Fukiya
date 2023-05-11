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
    AudioClip[] array = new AudioClip[15];//se��z��Ɋi�[����

    void Start()
    {
        array[0] = se1;//��̎h���鉹
        array[1] = se2;//����
        array[2] = se3;//�u�u�n�߂��I�I�I�v�v
        array[3] = se4;//����(�J�J�b)
        array[4] = se5;//������
        array[5] = se6;//���ߊ���
        array[6] = se7;//�N���b�N��
        array[7] = se8;//�G���[��
        array[8] = se9;//������
        array[9] = se10;//�����͂�����
        array[10] = se11;//�a�������
        array[11] = se12;//���n��
    }

    void Update()
    {
        //���ʎ擾
        bgm_AudioSource.volume = setting_con.bgm_vol;
        se_AudioSource.volume = setting_con.se_vol;
    }

    //bgm�Đ�
    public void Bgm_Start()
    {
        bgm_AudioSource.PlayOneShot(bgm);
    }

    //se�Đ�
    public void Se_Start(int num) //num:�Đ�����se
    {
        se_AudioSource.PlayOneShot(array[num]);
    }

    //bgm��~
    public void Bgm_Stop()
    {
        bgm_AudioSource.Stop();
    }
}
