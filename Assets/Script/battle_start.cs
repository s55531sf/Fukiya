using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle_start : MonoBehaviour
{
    public menu_cmp menu_cmp;
    public GameObject don;
    public enemy_control enemy_control;
    public audio_con audio_con;

    void Start()
    {
        //�}�E�X�J�[�\����\��
        Cursor.visible = false;
        menu_cmp.stop = true;
        StartCoroutine("Start_Effect");
    }

    IEnumerator Start_Effect()
    {
        Debug.Log("DON");
        yield return new WaitForSeconds(0.1f);
        audio_con.Se_Start(1);//���ۂ̉�
        yield return new WaitForSeconds(1.9f);
        audio_con.Se_Start(2);//�u�u�n�߂��I�I�I�v�v
        don.SetActive(true);
        yield return new WaitForSeconds(1);
        audio_con.Bgm_Start();
        menu_cmp.stop = false;
        yield return new WaitForSeconds(1);
        enemy_control.Start_Attack();
    }
}
