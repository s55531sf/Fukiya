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
        anim = GetComponent<Animation>();//enemyのanimation取得
        anim.Stop();
        enemy_Rigid = gameObject.GetComponent<Rigidbody>();//enemyのRigidbody取得
        player = GameObject.FindWithTag("Player");
        StartCoroutine("Slash");//7s毎に攻撃
    }

    void Update()
    {
        //speed設定
        float speed = 0.1f;
        //ベクトル生成
        Vector3 direction = player.transform.position - this.transform.position;
        //方向に変換
        Quaternion rotation = Quaternion.LookRotation(direction);
        //speedの速さでプレイヤーの方を向く
        transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, speed);

    }

    //何かと衝突したときに呼び出される
    void OnCollisionEnter(Collision col)
    {
        if (exp_cnt==4)
        {
            //爆発のエフェクト生成
            GameObject effect = Instantiate(exp_effect, this.transform.position, Quaternion.identity);
            //敵とプレイヤーの距離を取得
            float dis = Vector3.Distance(player.transform.position, this.transform.position); 
            Debug.Log("自爆");

            if (dis < 1)    //距離が1以内なら70ダメージ
            {
                damage = 70;
            }
            else if (dis < 3)//1以上離れるとダメージが下がり、3以上離れるとダメージ0
            {
                damage = (int)(70 - 70 * ((dis - 1) / 2));
            }
            else
            {
                damage = 0;
            }
            //プレイヤーのダメージ判定
            player.GetComponent<player_hp>().player_damage(damage);
            //このオブジェクトを破壊する
            Destroy(this.gameObject);

        }
    }


    //剣撃飛ばし
    IEnumerator Slash()
    {
        anim.clip = attack;//攻撃モーション
        anim.Play();//アニメーション再生
        yield return new WaitForSeconds(0.7f);//0.7s停止
        enemy_child_attack.Slash1();//横剣撃
        yield return new WaitForSeconds(0.5f);//0.5s停止
        enemy_child_attack.Slash2();//縦剣撃
        yield return new WaitForSeconds(0.3f);//0.3s停止
        anim.Stop();//モーションストップ
        yield return new WaitForSeconds(3);//8s停止
        exp_cnt++;
        Debug.Log("exp_cnt"+exp_cnt);
        if(exp_cnt == 4)
        {
            Explosion();
        }
        else
        {
             StartCoroutine("Slash");//再帰的に呼び出し
        }
    }

    //自爆
    void Explosion()
    {
        anim.clip = run;//攻撃モーション
        anim.Play();//アニメーション再生
        enemy_Rigid.AddForce(transform.forward * 800);  //発射(速度はspeed*4依存)
    }

}
