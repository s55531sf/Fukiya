using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu_btn : MonoBehaviour
{
    public int flag = 0; //�ǂ̃{�^���� (0:������)
    public Text button_text;//�{�^���ɂ���e�L�X�g
    public GameObject menu;
    public menu_cmp menu_cmp;

    //�{�^�����������Ƃ�
    public void OnClick()
    {
        Debug.Log("�����ꂽ");
        //���Ԓ�~����
        if (flag == 0)
        {
            //�J�[�\���\��
            Cursor.visible = true;
            menu_cmp.stop = false;
            menu.SetActive(false);
            Time.timeScale = 1f;
            //�ݒ�ۑ�
            PlayerPrefs.SetFloat("BGM", setting_con.bgm_vol);
            PlayerPrefs.SetFloat("SE", setting_con.se_vol);
            PlayerPrefs.SetFloat("Mou", setting_con.mou_vol);

            //�^�C�g���ɖ߂�
        }
        else if (flag == 1)
        {
            menu_cmp.stop = false;
            menu.SetActive(false);
            Time.timeScale = 1f;
            //�ݒ�ۑ�
            PlayerPrefs.SetFloat("BGM", setting_con.bgm_vol);
            PlayerPrefs.SetFloat("SE", setting_con.se_vol);
            PlayerPrefs.SetFloat("Mou", setting_con.mou_vol);
            //�V�[���J��
            SceneManager.LoadScene("Title");
        }
    }

    //�{�^���̏�ɃJ�[�\���������
    public void PointerEnter()
    {
        //�{�^���I�����̉��o
        button_text.GetComponent<Text>().color = Color.white;
        button_text.GetComponent<Outline>().effectColor = Color.black;
        Debug.Log("�}�E�X�ʂ�����");
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
