using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setumei_con : MonoBehaviour
{
    public Text text_mak;//�����̕�
    public Text text_set;//������
    public GameObject setumei;//�������
    public GameObject main;//�^�C�g�����
    public video_con video_con;//����֌W�̃X�N���v�g

    private int flag_set = 0;//���ǂ̐��������邩���f


    public void Setumei_Set(int num)
    {
        flag_set += num;
        if(flag_set < 0)
        {
            flag_set = 5;
        } else if(flag_set > 5)
        {
            flag_set = 0;
        }

        //����ύX
        video_con.Video_Start(flag_set);

        //�������ύX
        if(flag_set == 0)
        {
            text_mak.text = "�̗͂ɂ���";
            text_set.text = "����ɂ���Ԃ��_�����Ȃ��̗̑͂ł��B\n����͓G����̍U�����󂯂�ƌ������܂��B\n���ׂĖ����Ȃ����炠�Ȃ��̕����ł��B";
        }else if(flag_set == 1)
        {
            text_mak.text = "�U�����@";
            text_set.text = "���N���b�N�𒷉���������A�������u�Ԃɖ���˂���܂��B\n���N���b�N�𒷉������鎞�Ԃɔ�Ⴕ�Ď_�f������A��̑��x\n��З͂��オ��܂��B\n�_�f�͍���̐��_�ł��B\n�_�f�������Ȃ�Ɩ�łĂȂ��Ȃ�A�W�����v�������ł��Ȃ��Ȃ�܂����AShift�L�[�������ƁA�_�f���񕜂��܂��B";
        }else if(flag_set == 2)
        {
            text_mak.text = "�����@";
            text_set.text = "�E�N���b�N���������シ���Ɉړ��L�[(WASD)���������ƂŁA�����������ɒZ���ԍ����ړ����܂��B\nSpace�L�[���������ƂŃW�����v���邱�Ƃ��ł��܂��B\n����𗘗p���ēG�̍U����������邱�Ƃ��ł��܂��B\n�����̍s���ɂ͎_�f���g�p����̂Œ��ӂ��܂��傤�B";
        }else if(flag_set == 3)
        {
            text_mak.text = "�K�E�Z1";
            text_set.text = "�G�ɍU������������ƍ���̉��F���_���������܂��B\n���ꂪ�ő�܂ŗ��܂�ƕK�E�Z���g����悤�ɂȂ�܂��B\n���܂�����Ԃ�E�L�[�������A��𔭎˂���ƁA���̖�������āA�G��\n�傫�ȃ_���[�W��^���܂��B";
        }else if(flag_set == 4)
        {
            text_mak.text = "�K�E�Z2";
            text_set.text = "�G�̍U���ɖ�𓖂Ă�Ƃ��̍U�����~�߂邱�Ƃ��ł��܂��B�U�����~�߂邱�Ƃ��o�����Ƃ��A�G�ɖ�𓖂Ă�����傫���K�E�Q�[�W���������܂��B";
        }else if(flag_set == 5)
        {
            text_mak.text = "�ꎞ��~";
            text_set.text = "ESC�L�[���������ƂŁA�퓬���ꎞ���f���邱�Ƃ��ł��܂��B\n���̉�ʂł͉��ʂ̒�����}�E�X���x�̐ݒ�����邱�Ƃ��ł��܂��B\n�܂��A�퓬��������ă^�C�g���ɖ߂邱�Ƃ��ł��܂��B";
        }

    }
}
