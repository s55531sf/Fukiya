using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class start_compornent : MonoBehaviour
{
    public int flag = 0; //�ǂ̃{�^�������f
    public Text text;//�{�^���̏�̃e�L�X�g
    public GameObject setting;//�ݒ���
    public GameObject setumei;//�������
    public GameObject main;//�^�C�g�����

    void Update()
    {
        Cursor.visible = true;
        Debug.Log("a" + setting_con.bgm_vol);
        Debug.Log("b" + setting_con.se_vol);
        Debug.Log("c" + setting_con.mou_vol);
    }

    //�{�^�����������Ƃ�
    public void OnClick()
    {
        Debug.Log("�����ꂽ");
        if (flag == 0)
        {
            //�V�[���؂�ւ�(��Փx�ݒ�)
            SceneManager.LoadScene("Select");
        } else if (flag == 1)
        {
            //������ʊJ��
            setumei.SetActive(true);
            main.SetActive(false);
        } else if (flag == 2)
        {
            //�ݒ��ʊJ��
            setting.SetActive(true);
            main.SetActive(false);
            //�ݒ�ǂݍ���
            setting_con.bgm_vol =PlayerPrefs.GetFloat("BGM", 1.0f);
            setting_con.se_vol = PlayerPrefs.GetFloat("SE", 1.0f);
            setting_con.mou_vol = PlayerPrefs.GetFloat("Mou", 1.0f);

        } else if (flag == 3)
        {
            //�Q�[���I��
            Application.Quit();

        }
        else if(flag == 4)
        {
            //�ݒ��ʕ���
            setting.SetActive(false);
            main.SetActive(true);
            //�ݒ�ۑ�
            PlayerPrefs.SetFloat("BGM", setting_con.bgm_vol);
            PlayerPrefs.SetFloat("SE", setting_con.se_vol);
            PlayerPrefs.SetFloat("Mou", setting_con.mou_vol);
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
