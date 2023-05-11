using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hit : MonoBehaviour
{
    public GameObject damageUI;
    public AudioClip sound1;//�������SE
    private GameObject damageholder;
    private GameObject obj;
    AudioSource audioSource;
    [SerializeField]
    private int damage;//�_���[�W��


    void Start()
    {
        audioSource = GetComponent<AudioSource>();//Component���擾
    }

    //���̃I�u�W�F�N�g���ђʂ����Ƃ��ɌĂяo�����
    void OnTriggerEnter(Collider col)
    {

        //�ђʂ����I�u�W�F�N�g��Tag��Enemy�Ȃ�
        if (col.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(sound1);//SE�Đ�
            //�_���[�W�e�L�X�g����(���C���J��������������ɓG���O���ɐ���)
            //Debug.Log(col.bounds.center);
            Debug.Log(Quaternion.LookRotation(Camera.main.transform.position - col.bounds.center));
            GameObject obj = Instantiate<GameObject>(damageUI,col.bounds.center-Camera.main.transform.forward * 0.5f, Quaternion.identity);//�_���[�W�e�L�X�g����
            //GameObject obj = Instantiate<GameObject>(damageUI, Quaternion.LookRotation(Camera.main.transform.position - col.bounds.center)* new Vector3(1, Camera.main.transform.position.y, 1), Quaternion.identity);
            obj.GetComponent<UI_damage>().SetDamage(damage); //UI�Ƀ_���[�W�ʂ𑗐M
            col.gameObject.GetComponent<enemy_hp>().TakeDamage(damage);//�G�̃_���[�W����
        }
        //���������̂�Wave�ȊO�Ȃ�
        if (!col.CompareTag("Wave"))
        {
            //���̃I�u�W�F�N�g��j�󂷂�
            Destroy(this.gameObject);
        }

    }
}
