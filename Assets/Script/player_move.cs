using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public float fir_speed = 6.0f;//基本の移動速度
    public float jumpSpeed = 1.0f;//ジャンプする高さ
    public float gravity = 3.0f;//落下速度
    public player_o2 player_o2;//酸素関係のスクリプト
    public menu_cmp menu_cmp;//メニュー関係のスクリプト

    private float speed;//移動速度
    private float avoid_speed = 1.0f;//回避時の速度
    private Vector3 moveDirection = Vector3.zero; //初期化
    private CharacterController controller;//プレイヤーのCharacterController
    private int jump_cost = 200; //ジャンプに消費する酸素量
    private int avoid_cost= 400; //回避に消費する酸素量
    private bool avoid = false;  //回避中か否か

    void Start()
    {
        controller = GetComponent<CharacterController>();//CharacterControllerを取得
        speed = fir_speed;
    }

    void Update()
    {
        if (controller.isGrounded && !menu_cmp.stop) //プレイヤーが地面にいるとき かつ 時間がとまっていない
        {
            //WASDキー入力
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            //speedの値だけ移動量を大きくする
            moveDirection = moveDirection * speed * avoid_speed;                      

            //ジャンプ(スペース)キーが押されたとき かつ 現在の酸素がjump_costより大きいとき
            if (Input.GetButton("Jump") && player_o2.now_o2 >= jump_cost)
            {
                moveDirection.y = jumpSpeed; //y軸方向の移動量をjumpSpeedにする(ジャンプさせる)
                player_o2.o2cost(avoid_cost);//酸素をjump_costだけ消費
            }


        }

        //回避(右クリック)
        //右クリックが押された瞬間　かつ　酸素がavoid_cost以上　かつ 左クリック押されていないとき(矢を溜めているとき) かつ　回避中ではないとき かつ 時間が止まっていない
        if (Input.GetMouseButtonDown(1) && player_o2.now_o2 >= avoid_cost && !Input.GetMouseButton(0) && !avoid && !menu_cmp.stop)
        {
            avoid_speed = 3;
            avoid = true;
            player_o2.o2cost(avoid_cost);//酸素をavoid_costだけ消費
            Invoke("Avoid_Finish", 0.2f);//0.2s後に速度を元に戻す
            Invoke("Avoid_Reset", 1.0f);//1.0s後に回避使用可
        }


        //呼吸(左シフト)左シフトを推している時(呼吸) かつ　左クリック押されていないとき(矢を溜めているとき)
        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetMouseButton(0)) { 

            player_o2.o2cost(-2);//酸素回復               
            speed = 2.0f;//移動速度減少               
        }
        //呼吸終わり (左シフトを離したとき)
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = fir_speed;//速度を初期値にする
        }

        if (Input.GetMouseButton(0))//左クリック押されていないとき(矢を溜めているとき)
        {
            speed = 2.0f;//移動速度減少
        }
        if (Input.GetMouseButtonUp(0))//左クリックが離された時(矢が発射されたとき)
        {
            speed = fir_speed;//速度を初期値にする
        }
        //落下処理
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        //時間が止まっていなかったら
        if (!menu_cmp.stop)
        {
            //移動処理
            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    void Avoid_Finish()
    {
        avoid_speed = 1.0f;//回避速度を初期値にする
    }

    void Avoid_Reset()
    {
        avoid = false;//回避使用可
    }
}