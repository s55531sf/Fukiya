using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_o2 : MonoBehaviour
{
    int max_o2 = 10000;               //�_�f�̍ő��
    public static int now_o2 =10000;  //���݂̎_�f
    public Slider slider;           //O2�X���C�_�[

    void Start()
    {
        slider.value = 1;  //Slider�𖞃^���ɂ���B
        now_o2 = max_o2;
    }

    public void o2cost(int cost) //cost:�����_�f ���̐��Ȃ��
    {
       // Debug.Log(now_o2);
        now_o2 -= cost;
        if(now_o2 > max_o2) //�ő�l�𒴂��ĉ񕜂���Ȃ�
        {
            now_o2 = max_o2;//���݂̎_�f���ő�l�𒴂��Ȃ��悤�ɂ���
        }
        slider.value = (float)now_o2 / (float)max_o2; ;//�_�f�o�[�������ŕ\��
    }
}
