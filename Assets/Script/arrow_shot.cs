using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrow_shot : MonoBehaviour
{
    public GameObject Player;   //�v���C���[
    public GameObject arrow_weak;    //�ʏ��(��)
    public GameObject arrow_normal;  //�ʏ��(��)
    public GameObject arrow_strong;  //�ʏ��(��)
    public GameObject arrow_exp;     //������
    public float speed;    //��̔��ˑ��x
    public Slider slider;  //��̃`���[�W�������X���C�_�[
    public player_o2 player_o2;//�v���C���[�̎_�f�֌W�̃X�N���v�g
    public player_pow player_pow;//�v���C���[�̃p���[�֌W�̃X�N���v�g
    public menu_cmp menu_cmp;//���j���[�֌W�̃X�N���v�g
    public audio_con audio_con;//�����֌W�̃X�N���v�g
    float mouse;
    int mode = 0;//���˂���� 0=�ʏ� 1=����

    void Start()
    {
        //�X���C�_�[���Z�b�g
        slider.value = 0;
    }


    void Update()
    {

        if (Input.GetKey(KeyCode.E) && player_pow.now_pow == player_pow.max_pow && !menu_cmp.stop)//E�L�[�������ꂽ ���� ���Ԃ��~�܂��Ă��Ȃ�
        {
            mode = 1;//���˕�:������
            player_pow.pow_reset();
        }

        if (Input.GetMouseButton(0) && !menu_cmp.stop && player_o2.now_o2 > 2)    //���N���b�N������Ă��� ���� ���Ԃ��~�܂��Ă��Ȃ� ���� �_�f��2����
        {
            if (speed < 500 && player_o2.now_o2 > 2) //speed��500�����@���@���݂̎_�f��3�ȏ�  ���@mode=0�̂Ƃ�
            {
                //��̑��x�����A�_�f����
                speed+= 500 * Time.deltaTime;
                player_o2.o2cost(2);
                if(speed > 500)
                {
                    speed = 500;
                }
                //�`���[�W�o�[�������ŕ\��
                slider.value = (float)speed / 500 ;
            }

        }else if(Input.GetMouseButtonDown(0) && !menu_cmp.stop && player_o2.now_o2 <= 2) //�_�f��2�ȉ��Ȃ�
        {
            //�x����
            audio_con.Se_Start(7);
        }
        if (Input.GetMouseButtonUp(0) && !menu_cmp.stop)  //���N���b�N�������ꂽ�Ƃ� ���� ���Ԃ��~�܂��Ă��Ȃ�
        {
            if(mode == 0)//�ʏ��
            {
                //�������Đ�
                audio_con.Se_Start(4);
                if (speed > 1 && speed < 201)//speed��1����200�̂Ƃ� �ʏ�� ��U��
             {
                 Shot1(); 
             }else if(speed > 201 && speed < 500)//speed��201����499�̂Ƃ��@�ʏ�� ���U��
             {
                 Shot2();
             }
             else if(speed==500) //speed��500(max)�̂Ƃ� �ʏ�� ���U��
             {
                 Shot3();
             }
             
            }else if (mode == 1)
            {
                Shot4();//������
                mode = 0;//�ʏ��ɂ��ǂ�
            }

            slider.value = 0;
            speed = 0; //speed���Z�b�g
        }
    }

    public void Shot1()//�ʏ�� ��U��
    {
        GameObject arrow = (GameObject)Instantiate(arrow_weak, transform.position, Player.transform.rotation);//���
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();//���Rigidbody�擾
        arrowRigidbody.AddForce(transform.forward * speed*4);  //����(���x��speed*4�ˑ�)
    }
    public void Shot2()//�ʏ�� ���U��
    {
        GameObject arrow = (GameObject)Instantiate(arrow_normal, transform.position, Player.transform.rotation);//���
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();//���Rigidbody�擾
        arrowRigidbody.AddForce(transform.forward * speed * 4);  //����(���x��speed*4�ˑ�)
    }
    public void Shot3()//�ʏ�� ���U��
    {
        GameObject arrow = (GameObject)Instantiate(arrow_strong, transform.position, Player.transform.rotation);//���
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();//���Rigidbody�擾
        arrowRigidbody.AddForce(transform.forward * speed * 4);  //����(���x��speed*4�ˑ�)
    }
    public void Shot4()//�ʏ�� ���U��
    {
        GameObject arrow = (GameObject)Instantiate(arrow_exp, transform.position, Player.transform.rotation);//���
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();//���Rigidbody�擾
        arrowRigidbody.AddForce(transform.forward * speed * 3);  //����(���x��speed*3�ˑ�)
    }
}