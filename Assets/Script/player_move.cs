using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public float fir_speed = 6.0f;//��{�̈ړ����x
    public float jumpSpeed = 1.0f;//�W�����v���鍂��
    public float gravity = 3.0f;//�������x
    public player_o2 player_o2;//�_�f�֌W�̃X�N���v�g
    public menu_cmp menu_cmp;//���j���[�֌W�̃X�N���v�g

    private float speed;//�ړ����x
    private float avoid_speed = 1.0f;//������̑��x
    private Vector3 moveDirection = Vector3.zero; //������
    private CharacterController controller;//�v���C���[��CharacterController
    private int jump_cost = 200; //�W�����v�ɏ����_�f��
    private int avoid_cost= 400; //����ɏ����_�f��
    private bool avoid = false;  //��𒆂��ۂ�

    void Start()
    {
        controller = GetComponent<CharacterController>();//CharacterController���擾
        speed = fir_speed;
    }

    void Update()
    {
        if (controller.isGrounded && !menu_cmp.stop) //�v���C���[���n�ʂɂ���Ƃ� ���� ���Ԃ��Ƃ܂��Ă��Ȃ�
        {
            //WASD�L�[����
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            //speed�̒l�����ړ��ʂ�傫������
            moveDirection = moveDirection * speed * avoid_speed;                      

            //�W�����v(�X�y�[�X)�L�[�������ꂽ�Ƃ� ���� ���݂̎_�f��jump_cost���傫���Ƃ�
            if (Input.GetButton("Jump") && player_o2.now_o2 >= jump_cost)
            {
                moveDirection.y = jumpSpeed; //y�������̈ړ��ʂ�jumpSpeed�ɂ���(�W�����v������)
                player_o2.o2cost(avoid_cost);//�_�f��jump_cost��������
            }


        }

        //���(�E�N���b�N)
        //�E�N���b�N�������ꂽ�u�ԁ@���@�_�f��avoid_cost�ȏ�@���� ���N���b�N������Ă��Ȃ��Ƃ�(��𗭂߂Ă���Ƃ�) ���@��𒆂ł͂Ȃ��Ƃ� ���� ���Ԃ��~�܂��Ă��Ȃ�
        if (Input.GetMouseButtonDown(1) && player_o2.now_o2 >= avoid_cost && !Input.GetMouseButton(0) && !avoid && !menu_cmp.stop)
        {
            avoid_speed = 3;
            avoid = true;
            player_o2.o2cost(avoid_cost);//�_�f��avoid_cost��������
            Invoke("Avoid_Finish", 0.2f);//0.2s��ɑ��x�����ɖ߂�
            Invoke("Avoid_Reset", 1.0f);//1.0s��ɉ���g�p��
        }


        //�ċz(���V�t�g)���V�t�g�𐄂��Ă��鎞(�ċz) ���@���N���b�N������Ă��Ȃ��Ƃ�(��𗭂߂Ă���Ƃ�)
        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetMouseButton(0)) { 

            player_o2.o2cost(-2);//�_�f��               
            speed = 2.0f;//�ړ����x����               
        }
        //�ċz�I��� (���V�t�g�𗣂����Ƃ�)
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = fir_speed;//���x�������l�ɂ���
        }

        if (Input.GetMouseButton(0))//���N���b�N������Ă��Ȃ��Ƃ�(��𗭂߂Ă���Ƃ�)
        {
            speed = 2.0f;//�ړ����x����
        }
        if (Input.GetMouseButtonUp(0))//���N���b�N�������ꂽ��(����˂��ꂽ�Ƃ�)
        {
            speed = fir_speed;//���x�������l�ɂ���
        }
        //��������
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        //���Ԃ��~�܂��Ă��Ȃ�������
        if (!menu_cmp.stop)
        {
            //�ړ�����
            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    void Avoid_Finish()
    {
        avoid_speed = 1.0f;//��𑬓x�������l�ɂ���
    }

    void Avoid_Reset()
    {
        avoid = false;//����g�p��
    }
}