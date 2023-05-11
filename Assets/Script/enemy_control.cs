using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_control : MonoBehaviour
{
    public GameObject player;
    public GameObject exp_effect;
    public GameObject enemy_child;
    public enemy_attack enemy_attack;
    public audio_con audio_con;
    public AnimationClip attack;
    public AnimationClip jump;
    public AnimationClip run;
    public AnimationClip idle;

    private Animation anim;
    private Rigidbody enemy_Rigid;
    private Vector3 pos;
    private float dis;
    private float force;
    private bool flag_shok = false;
    private int rand;
    private int flag;

    void Start()
    {
        Debug.Log("dif_flag"+select_cmp.dif_flag);
        flag = select_cmp.dif_flag;
        anim = GetComponent<Animation>();
        enemy_Rigid = gameObject.GetComponent<Rigidbody>();
        //StartCoroutine("Attack_switch");
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

    public void Start_Attack()
    {
        StartCoroutine("Attack_switch");
    }

    //何かと衝突したときに呼び出される
    void OnCollisionEnter(Collision col) {
        //衝突したものが地面 かつ 衝撃波を放っていないとき
        if (col.gameObject.tag=="Ground" && flag_shok)
        {
            Debug.Log("Ground");
            //衝撃波を放った
            flag_shok = false;
            //着地音
            audio_con.Se_Start(11);
            //衝撃波発生
            enemy_attack.Wave();
        }
    }

    //ランダムに攻撃
    IEnumerator Attack_switch()
    {
        dis = Vector3.Distance(player.transform.position, this.transform.position);
        Debug.Log("dis"+dis);
        if (dis < 11)
        {
            //シーン内のタグ「Child」を検索
            GameObject[] children = GameObject.FindGameObjectsWithTag("Child");
            Debug.Log("children.Length" + children.Length);
            //子侍が召喚されていないなら かつ　難易度が竹、松なら
            if (children.Length < 1 && flag !=0 ){
                rand = Random.Range(0,4);
            }
            else //されているなら もしくは 難易度梅なら
            {
                //0から2の乱数生成
                rand = Random.Range(0,3);
            }
            Debug.Log(rand);
            if (rand == 0)
            {
                StartCoroutine("Slash");
            }
            else if (rand == 1)
            {
                StartCoroutine("Shokwave");
            }
            else if (rand == 2)
            {
                StartCoroutine("Slash_Jump");
            }else if(rand == 3)
            {
                StartCoroutine("Summon");
            }
            //攻撃インターバル 梅:6s 竹:5s 松:4s
            yield return new WaitForSeconds(6-flag);
        }
        else
        {
            if (flag == 2)
            {
                StartCoroutine("Dash_slash");
            }else
            {
                StartCoroutine("Dash");
            }
            //攻撃インターバル 梅:4s 竹:3s 松:2s
            yield return new WaitForSeconds(4-flag);
        }
        StartCoroutine("Attack_switch");
    }

    //剣撃飛ばし
    IEnumerator Slash()
    {
        anim.clip = attack;//攻撃モーション
        anim.Play();//アニメーション再生
        yield return new WaitForSeconds(0.8f);//0.8s停止
        enemy_attack.Slash1();//横剣撃
        yield return new WaitForSeconds(0.4f);//0.4s停止
        enemy_attack.Slash2();//縦剣撃
        yield return new WaitForSeconds(0.3f);//0.3s停止
        anim.Stop();//モーションストップ
    }

    //衝撃波
    IEnumerator Shokwave()
    {
        force = 280f;//ジャンプの高さ
        anim.clip = jump;//ジャンプモーション
        anim.Play();//アニメーション再生
        yield return new WaitForSeconds(0.3f);//3s停止
        enemy_Rigid.AddForce(new Vector3(0, force, 0));//enemyを上に飛ばす
        flag_shok = true;//地面に付いたら衝撃波発生
        yield return new WaitForSeconds(0.7f);//0.3s停止
        anim.Stop();//アニメーションストップ
    }

    //剣撃飛ばし(ジャンプ)
    IEnumerator Slash_Jump()
    {
        force = 430f;//ジャンプの高さ
        anim.clip = jump;//ジャンプモーション
        anim.Play();//アニメーション再生
        yield return new WaitForSeconds(0.3f);//3s停止
        enemy_Rigid.AddForce(0,force,0);//enemyを上に飛ばす
        yield return null;//1フレーム停止
        anim.Stop();//モーションストップ
        yield return new WaitForSeconds(0.1f);//0.1s停止
        anim.clip = attack;//攻撃モーション
        anim.Play();//アニメーション再生
        yield return new WaitForSeconds(0.7f);//0.8s停止
        enemy_attack.Slash1();//横剣撃
        yield return new WaitForSeconds(0.4f);//0.4s停止
        enemy_attack.Slash2();//縦剣撃
        yield return new WaitForSeconds(0.3f);//0.3s停止
        anim.Stop();//モーションストップ
    }

    //召喚(同時に2体以上は召喚しない)
    IEnumerator Summon()
    {
        //敵の上方に召喚
        pos = this.transform.position;
        pos.x += 2;
        pos.y += 3;
        //子召喚 爆発召喚
        GameObject effect = Instantiate(exp_effect, pos, Quaternion.identity);
        GameObject child = Instantiate(enemy_child, pos, Quaternion.identity);
        yield return new WaitForSeconds(1.3f);//1.3s停止
        //エフェクト削除
        Destroy(effect);
    }

    //瞬歩
    IEnumerator Dash()
    {
            anim.clip = run;//攻撃モーション
            anim.Play();//アニメーション再生
            Debug.Log("遠い！");
            enemy_Rigid.AddForce(transform.forward * 800);  //発射(速度はspeed*4依存)
            yield return new WaitForSeconds(1.4f);//3s停止
            anim.Stop();//モーションストップ
    }

    //瞬歩+剣撃
    IEnumerator Dash_slash()
    {
        anim.clip = run;//攻撃モーション
        anim.Play();//アニメーション再生
        Debug.Log("遠い！");
        enemy_Rigid.AddForce(transform.forward * 800);  //発射(速度はspeed*4依存)
        yield return new WaitForSeconds(0.4f);//3s停止
        anim.Stop();//モーションストップ
        yield return new WaitForSeconds(0.1f);//0.1s停止
        anim.clip = attack;//攻撃モーション
        anim.Play();//アニメーション再生
        yield return new WaitForSeconds(0.8f);//0.8s停止
        enemy_attack.Slash1();//横剣撃
        yield return new WaitForSeconds(0.4f);//0.4s停止
        enemy_attack.Slash2();//縦剣撃
        yield return new WaitForSeconds(0.3f);//0.3s停止
        anim.Stop();//モーションストップ
    }


}
