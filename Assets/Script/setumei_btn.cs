using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setumei_btn : MonoBehaviour
{
    public int flag = 0; //�ǂ̃{�^�������f
    public Text text;//�{�^���̏�̃e�L�X�g
    public GameObject setumei;//�������
    public GameObject main;//�^�C�g�����
    public setumei_con setumei_con;

    //�{�^�����������Ƃ�
    public void OnClick()
    {
        //�ݒ��ʕ���
        if (flag == 0)
        {
            //������ʕ���
            setumei.SetActive(false);
            main.SetActive(true);
        //����
        }
        else if (flag == 1)
        {
            setumei_con.Setumei_Set(1);

        //�O��
        }
        else if (flag == 2)
        {
            setumei_con.Setumei_Set(-1);
        }

    }

    //�{�^���̏�ɃJ�[�\���������
    public void PointerEnter()
    {
        //�{�^���I�����̉��o
        text.GetComponent<Text>().color = Color.white;
        text.GetComponent<Outline>().effectColor = Color.black;
        Debug.Log("�}�E�X�ʂ�����");
    }

    //�{�^���̏ォ��J�[�\�������ꂽ
    public void PointerExit()
    {
        //�{�^���I�����̉��o����
        text.GetComponent<Text>().color = Color.black;
        text.GetComponent<Outline>().effectColor = Color.white;
        Debug.Log("�}�E�X���ꂽ��");
    }
}
