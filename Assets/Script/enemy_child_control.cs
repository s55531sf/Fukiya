using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_child_control : MonoBehaviour
{
    public GameObject exp_effect;   
    public enemy_child_attack enemy_child_attack;
    public AnimationClip attack;
    public AnimationClip run;
    private Animation anim;
    private Rigidbody enemy_Rigid;
    private GameObject player;
    private float force;
    private bool flag_shok = false;
    private int exp_cnt = 0;
    private int damage = 0;

    void Start()
    {
        anim = GetComponent<Animation>();//enemy��animation�擾
        anim.Stop();
        enemy_Rigid = gameObject.GetComponent<Rigidbody>();//enemy��Rigidbody�擾
        player = GameObject.FindWithTag("Player");
        StartCoroutine("Slash");//7s���ɍU��
    }

    void Update()
    {
        //speed�ݒ�
        float speed = 0.1f;
        //�x�N�g������
        Vector3 direction = player.transform.position - this.transform.position;
        //�����ɕϊ�
        Quaternion rotation = Quaternion.LookRotation(direction);
        //speed�̑����Ńv���C���[�̕�������
        transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, speed);

    }

    //�����ƏՓ˂����Ƃ��ɌĂяo�����
    void OnCollisionEnter(Collision col)
    {
        if (exp_cnt==4)
        {
            //�����̃G�t�F�N�g����
            GameObject effect = Instantiate(exp_effect, this.transform.position, Quaternion.identity);
            //�G�ƃv���C���[�̋������擾
            float dis = Vector3.Distance(player.transform.position, this.transform.position); 
            Debug.Log("����");

            if (dis < 1)    //������1�ȓ��Ȃ�70�_���[�W
            {
                damage = 70;
            }
            else if (dis < 3)//1�ȏ㗣���ƃ_���[�W��������A3�ȏ㗣���ƃ_���[�W0
            {
                damage = (int)(70 - 70 * ((dis - 1) / 2));
            }
            else
            {
                damage = 0;
            }
            //�v���C���[�̃_���[�W����
            player.GetComponent<player_hp>().player_damage(damage);
            //���̃I�u�W�F�N�g��j�󂷂�
            Destroy(this.gameObject);

        }
    }


    //������΂�
    IEnumerator Slash()
    {
        anim.clip = attack;//�U�����[�V����
        anim.Play();//�A�j���[�V�����Đ�
        yield return new WaitForSeconds(0.7f);//0.7s��~
        enemy_child_attack.Slash1();//������
        yield return new WaitForSeconds(0.5f);//0.5s��~
        enemy_child_attack.Slash2();//�c����
        yield return new WaitForSeconds(0.3f);//0.3s��~
        anim.Stop();//���[�V�����X�g�b�v
        yield return new WaitForSeconds(3);//8s��~
        exp_cnt++;
        Debug.Log("exp_cnt"+exp_cnt);
        if(exp_cnt == 4)
        {
            Explosion();
        }
        else
        {
             StartCoroutine("Slash");//�ċA�I�ɌĂяo��
        }
    }

    //����
    void Explosion()
    {
        anim.clip = run;//�U�����[�V����
        anim.Play();//�A�j���[�V�����Đ�
        enemy_Rigid.AddForce(transform.forward * 800);  //����(���x��speed*4�ˑ�)
    }

}
