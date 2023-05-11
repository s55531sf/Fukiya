using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class select_cmp : MonoBehaviour
{
    public data_load data_load;
    public static int dif_flag=0;//���̃V�[���ɓ�Փx��n��
    public int flag = 0; //�ǂ̓�Փx��
    public Text button_text;//�{�^���ɂ���e�L�X�g
    public Text exp_text;       //��Փx����
    public Text timetext;   //�ŒZ���j���Ԃ�\������e�L�X�g


    //�{�^�����������Ƃ�
    public void OnClick()
    {
        Debug.Log("�����ꂽ");
        dif_flag = flag;//��Փx�����
        SceneManager.LoadScene("Battle");
    }

    //�{�^���̏�ɃJ�[�\���������
    public void PointerEnter()
    {
        //�{�^���I�����̉��o
        button_text.GetComponent<Text>().color = Color.white;
        button_text.GetComponent<Outline>().effectColor = Color.black;
        timetext.text = data_load.Load_time(flag);
        Debug.Log("�}�E�X�ʂ�����");
        //���I�����Ă����Փx�̐���
        if (flag == 0) //�~
        {
            exp_text.text = "���g�̗̑͂������A�񕜑��x�������B�G�̍U������r�I�����₷��\n���S�҂ɂ������߂ȓ�Փx";
        }else if (flag == 1)//�|
        {
            exp_text.text = "���g�̗͕̑͂W���I�ŁA�G�̍U���͏��������ɂ���\n����Ă������ɂ������߂ȓ�Փx";
        }else if (flag == 2)//��
        {
            exp_text.text = "���g�̗͕̑͂W���I�����A�G�̍U�������������Ȃ�����ɂ���\n�Ҏ҂ɂ������߂̓�Փx";
        }
    }

    //�{�^���̏ォ��J�[�\�������ꂽ
    public void PointerExit()
    {
        //�{�^���I�����̉��o������
        button_text.GetComponent<Text>().color = Color.black;
        button_text.GetComponent<Outline>().effectColor = Color.clear;
        Debug.Log("�}�E�X���ꂽ��");
    }
}
