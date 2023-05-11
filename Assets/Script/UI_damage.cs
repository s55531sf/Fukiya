using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_damage : MonoBehaviour
{
	public enemy_hit enemy_Hit;
	private Text damageText;
	private float fadeOutSpeed = 1.5f;//textが消える速さ
	private float moveSpeed = 0.2f;   //上昇の速さ
	float dis = 0;//距離

	void Start()
	{
		damageText = GetComponentInChildren<Text>(); //子オブジェクトのtextを取得
	}

	void LateUpdate()
	{
		dis = Vector3.Distance(this.transform.position, Camera.main.transform.position);//メインカメラとテキスト間の距離
        if (dis > 179 - 10)
        {
			dis = 179 - 10;
        }
		damageText.fontSize = 10 + (int)dis*2;//距離が遠いほど文字を大きくする(max179)
		transform.rotation = Camera.main.transform.rotation;//textをカメラの正面になるようにする
		transform.position += Vector3.up * moveSpeed * Time.deltaTime;//textが上昇する

		//徐々に色を薄くする((R,G,B,A)=(1,0,0,0)に近づける)
		damageText.color = Color.Lerp(damageText.color, new Color(1f, 0f, 0f, 0f), fadeOutSpeed * Time.deltaTime);

		if (damageText.color.a <= 0.1f)
		{
			Destroy(gameObject);//textを削除
		}
	}
	public void SetDamage(int a)
    {
		Debug.Log(a);
		damageText = GetComponentInChildren<Text>();
		damageText.text = a.ToString();
	}
}
