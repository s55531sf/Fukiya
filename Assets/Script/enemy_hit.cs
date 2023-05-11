using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hit : MonoBehaviour
{
    public GameObject damageUI;
    public AudioClip sound1;//矢命中時のSE
    private GameObject damageholder;
    private GameObject obj;
    AudioSource audioSource;
    [SerializeField]
    private int damage;//ダメージ量


    void Start()
    {
        audioSource = GetComponent<AudioSource>();//Componentを取得
    }

    //他のオブジェクトが貫通したときに呼び出される
    void OnTriggerEnter(Collider col)
    {

        //貫通したオブジェクトのTagがEnemyなら
        if (col.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(sound1);//SE再生
            //ダメージテキスト生成(メインカメラがある方向に敵より前方に生成)
            //Debug.Log(col.bounds.center);
            Debug.Log(Quaternion.LookRotation(Camera.main.transform.position - col.bounds.center));
            GameObject obj = Instantiate<GameObject>(damageUI,col.bounds.center-Camera.main.transform.forward * 0.5f, Quaternion.identity);//ダメージテキスト生成
            //GameObject obj = Instantiate<GameObject>(damageUI, Quaternion.LookRotation(Camera.main.transform.position - col.bounds.center)* new Vector3(1, Camera.main.transform.position.y, 1), Quaternion.identity);
            obj.GetComponent<UI_damage>().SetDamage(damage); //UIにダメージ量を送信
            col.gameObject.GetComponent<enemy_hp>().TakeDamage(damage);//敵のダメージ処理
        }
        //当たったのがWave以外なら
        if (!col.CompareTag("Wave"))
        {
            //このオブジェクトを破壊する
            Destroy(this.gameObject);
        }

    }
}
