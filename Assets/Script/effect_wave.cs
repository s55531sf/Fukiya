using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect_wave : MonoBehaviour
{
    private Vector3 large;
    public int speed=5;     //�c���̑���

    void Start()
    {
        large = gameObject.transform.localScale;    //�I�u�W�F�N�g�̑傫�����擾
    }
    void Update()
    {
        //speed�����g��
        large.x += speed;
        large.y += speed;
        //�ω������傫���̒l���I�u�W�F�N�g�ɔ��f
        gameObject.transform.localScale = large;
    }

}
