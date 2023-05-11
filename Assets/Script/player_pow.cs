using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_pow : MonoBehaviour
{
    public Slider slider;   // �p���[�Q�[�W
    public static float now_pow=0;
    public float max_pow = 300;
    public audio_con audio_con;

    void Start()
    {
        Invoke("slider_reset", 0.01f);
        Debug.Log("slider"+slider.value);
    }

    void slider_reset()
    {
        slider.value = 0;
        now_pow = 0;
    }

    public void pow_up(float charge) //charge:�`���[�W������
    {
        now_pow += charge;
        if (now_pow > max_pow) //�ő�l�𒴂��ĉ񕜂���Ȃ�
        {
            now_pow = max_pow;//���݂̎_�f���ő�l�𒴂��Ȃ��悤�ɂ���
        }
        //pow���ő�Ȃ�
        if(now_pow == max_pow)
        {
            //�`���[�W��
            audio_con.Se_Start(5);
        }
        slider.value = now_pow / max_pow; //�_�f�o�[�������ŕ\��
    }

    public void pow_reset() //�p���[�Q�[�W���Z�b�g
    {
        now_pow = 0;
        slider.value = 0;
    }
}
