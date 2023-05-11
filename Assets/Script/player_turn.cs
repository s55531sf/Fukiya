using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_turn : MonoBehaviour
{
    public menu_cmp menu_cmp;//���j���[�֌W�̃X�N���v�g
    public float rotateSpeed = 2.0f;   //��]�̑���
    private GameObject playerObject;   //�v���C���[�I�u�W�F�N�g
    float tmp = 0;

    void Start()
    {
        //�v���C���[���擾
        playerObject = GameObject.Find("player");
    }


    void Update()
    {
        //���Ԃ��~�܂��Ă��Ȃ���
        if (!menu_cmp.stop)
        {
        rotateCamera();
        }
    }

    //�J��������]������֐�
    private void rotateCamera()
    {
        Debug.Log("setting"+setting_con.mou_vol);
        //�}�E�X�̓��͂���X,Y�����̉�]�̓x�������`
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed * setting_con.mou_vol, Input.GetAxis("Mouse Y") * rotateSpeed, 0) * setting_con.mou_vol;
        tmp += Input.GetAxis("Mouse Y") * rotateSpeed;
        //���C���J��������]������
        transform.RotateAround(playerObject.transform.position, Vector3.up, angle.x);
        if (-90 < tmp && tmp < 90)
        {
            transform.RotateAround(playerObject.transform.position, transform.right, angle.y);
        }
        else if (tmp > 90)
        {
            tmp = 90;
        }
        else if (tmp < -90)
        {
            tmp = -90;
        }

    }
}