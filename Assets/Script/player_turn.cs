using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_turn : MonoBehaviour
{
    public menu_cmp menu_cmp;//メニュー関係のスクリプト
    public float rotateSpeed = 2.0f;   //回転の速さ
    private GameObject playerObject;   //プレイヤーオブジェクト
    float tmp = 0;

    void Start()
    {
        //プレイヤーを取得
        playerObject = GameObject.Find("player");
    }


    void Update()
    {
        //時間が止まっていない時
        if (!menu_cmp.stop)
        {
        rotateCamera();
        }
    }

    //カメラを回転させる関数
    private void rotateCamera()
    {
        Debug.Log("setting"+setting_con.mou_vol);
        //マウスの入力からX,Y方向の回転の度合いを定義
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed * setting_con.mou_vol, Input.GetAxis("Mouse Y") * rotateSpeed, 0) * setting_con.mou_vol;
        tmp += Input.GetAxis("Mouse Y") * rotateSpeed;
        //メインカメラを回転させる
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