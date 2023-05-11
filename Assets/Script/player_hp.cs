using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player_hp : MonoBehaviour
{
    public float max_hp = 100f;               //HP�̍ő��
    public static float now_hp = 100f;  //���݂�HP
    public Slider slider;           //HP�X���C�_�[
    public Image damage_effect;     //��e���̃G�t�F�N�g��Image
    public menu_cmp menu_cmp;       //���Ԋ֌W�̃X�N���v�g
    public battle_end battle_end;   //�Q�[���I���֌W�̃X�N���v�g

    private int regene_stop = 0;     //���R�񕜒�~
    private int regene_stop_max = 8; //�ő厩�R�񕜒�~����
    private float regene_val = 0.25f; //���R�񕜗�

    void Start()
    {
        //��Փx�~�̎��A�ő�̗�1.5�{  �U���󂯂�2.0s�㎩���񕜊J�n ���R�񕜗ʑ���
        if (select_cmp.dif_flag == 0)
        {
            max_hp = max_hp*1.5f;
            regene_stop_max = 5;
            regene_val = 0.3f;
        }
        now_hp = max_hp;
        slider.value = 1;  //Slider�𖞃^���ɂ���B
        StartCoroutine("Regene");
    }

    void Update()
    {
        //����������ʂ̐Ԃ𓧖��ɂ���
        this.damage_effect.color = Color.Lerp(this.damage_effect.color, Color.clear, Time.deltaTime);
    }

    

    public void player_damage(float damage) //damage:�_���[�W ���̐��Ȃ��
    {
        if (damage > 0) //�_���[�W�����̐��Ȃ�(�񕜂ł͂Ȃ��̂Ȃ�)
        {
            //��ʂ�Ԃ�����
            this.damage_effect.color = new Color(0.5f, 0f, 0f, 0.5f);
            regene_stop = regene_stop_max;//���R��3.2s��~(��Փx�~�Ȃ�2.0s)
            Debug.Log("regene_stop" + regene_stop);
        }
 
        now_hp -= damage;
        if (now_hp > max_hp) //�ő�l�𒴂��ĉ񕜂���Ȃ�
        {
            now_hp = max_hp;//���݂̎_�f���ő�l�𒴂��Ȃ��悤�ɂ���
        }
        slider.value = now_hp / max_hp;//�_�f�o�[�������ŕ\��

        //hp��0�ȉ��@���@���Ԓ�~������Ȃ��̂Ȃ�
        if(now_hp <= 0 && !menu_cmp.stop)
        {
            //�s�k����
            battle_end.End_start(0);
        }
    }

    IEnumerator Regene()
    {
        yield return new WaitForSeconds(0.4f);//0.4s��~
        //���R�񕜒�~���Ԃł͂Ȃ��̂Ȃ�   ����  ���Ԃ��~�܂��Ă��Ȃ��̂Ȃ�
        if (regene_stop<=0 && !menu_cmp.stop)
        {
            //regene_val������
            Debug.Log("��");
            player_damage(-regene_val);
        }
        else
        {
            Debug.Log("�񕜒�~");
            //���R�񕜒�~���Ԃ����炷
            regene_stop--;
        }
        //HP�o�[�������ŕ\��
        slider.value = (float)now_hp / (float)max_hp;
        //�ċA�I�ɌĂяo��
        StartCoroutine("Regene");
    }

}
