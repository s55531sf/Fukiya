using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hp : MonoBehaviour //�G��HP�֌W�̏���
{
    public float weight = 1;       //�p���[�Q�[�W�㏸�ʂ̔{��
    public int Hp_max=100;  //�ő�HP
    public GameObject enemy;//�G�̃I�u�W�F�N�g
    public battle_end battle_end;//�I���֌W�̃X�N���v�g
    public int flag_enemy = 0;//�G�̎�ނ�\��0:�q�� 1:��(boss) 2:����
    private GameObject player;//�v���[���[�̃I�u�W�F�N�g
    private GameObject audio;//�I�[�f�B�I�R���g���[���[�̃I�u�W�F�N�g
    private int Hp_now; //���݂�HP
    void Start()
    {
        //�v���C���[�̃^�O���t�����I�u�W�F�N�g������
        player = GameObject.FindWithTag("Player");
        audio = GameObject.FindWithTag("Audio");
        Hp_now = Hp_max;//���݂�HP��������
    }
    
    //�_���[�W����
    public void TakeDamage(int damage)
    {
        //SE�Đ�
        if (flag_enemy != 2)
        {
            //��̎h���鉹
            audio.GetComponent<audio_con>().Se_Start(0);
        }
        else
        {
            //�����͂�����
            audio.GetComponent<audio_con>().Se_Start(9);
        }

        //�_���[�W����
        Hp_now -= damage;
        //�_���[�W��(�ő�60)*weight �����p���[���`���[�W����
        if (damage <= 60)
        {
            player.GetComponent<player_pow>().pow_up(damage * weight);
        }
        else
        {
            player.GetComponent<player_pow>().pow_up(60 * weight);
        }

        //�G�̎��S����
        if (Hp_now <= 0)
        { 
            EnemyDead();
        }
    }

    private void EnemyDead()
    {
        //�G��|���� 20*weight �����p���[���`���[�W����
        player.GetComponent<player_pow>().pow_up(30 * weight);
        player.GetComponent<player_o2>().o2cost(-1000);
        if (flag_enemy==1)
        {
            //��������
            battle_end.End_start(1);
        }
        //�|���ꂽ�G���폜����
        Destroy(enemy);
    }
}
