using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_damage : MonoBehaviour
{
	public enemy_hit enemy_Hit;
	private Text damageText;
	private float fadeOutSpeed = 1.5f;//text�������鑬��
	private float moveSpeed = 0.2f;   //�㏸�̑���
	float dis = 0;//����

	void Start()
	{
		damageText = GetComponentInChildren<Text>(); //�q�I�u�W�F�N�g��text���擾
	}

	void LateUpdate()
	{
		dis = Vector3.Distance(this.transform.position, Camera.main.transform.position);//���C���J�����ƃe�L�X�g�Ԃ̋���
        if (dis > 179 - 10)
        {
			dis = 179 - 10;
        }
		damageText.fontSize = 10 + (int)dis*2;//�����������قǕ�����傫������(max179)
		transform.rotation = Camera.main.transform.rotation;//text���J�����̐��ʂɂȂ�悤�ɂ���
		transform.position += Vector3.up * moveSpeed * Time.deltaTime;//text���㏸����

		//���X�ɐF�𔖂�����((R,G,B,A)=(1,0,0,0)�ɋ߂Â���)
		damageText.color = Color.Lerp(damageText.color, new Color(1f, 0f, 0f, 0f), fadeOutSpeed * Time.deltaTime);

		if (damageText.color.a <= 0.1f)
		{
			Destroy(gameObject);//text���폜
		}
	}
	public void SetDamage(int a)
    {
		Debug.Log(a);
		damageText = GetComponentInChildren<Text>();
		damageText.text = a.ToString();
	}
}
