using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setumei_con : MonoBehaviour
{
    public Text text_mak;//巻物の文
    public Text text_set;//説明文
    public GameObject setumei;//説明画面
    public GameObject main;//タイトル画面
    public video_con video_con;//動画関係のスクリプト

    private int flag_set = 0;//今どの説明をするか判断


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

        //動画変更
        video_con.Video_Start(flag_set);

        //説明文変更
        if(flag_set == 0)
        {
            text_mak.text = "体力について";
            text_set.text = "左上にある赤い棒があなたの体力です。\nこれは敵からの攻撃を受けると減少します。\nすべて無くなったらあなたの負けです。";
        }else if(flag_set == 1)
        {
            text_mak.text = "攻撃方法";
            text_set.text = "左クリックを長押しした後、離した瞬間に矢が発射されます。\n左クリックを長押しする時間に比例して酸素を消費し、矢の速度\nや威力が上がります。\n酸素は左上の青い棒です。\n酸素が無くなると矢が打てなくなり、ジャンプや回避ができなくなりますが、Shiftキーを押すと、酸素が回復します。";
        }else if(flag_set == 2)
        {
            text_mak.text = "回避方法";
            text_set.text = "右クリックを押した後すぐに移動キー(WASD)を押すことで、押した方向に短い間高速移動します。\nSpaceキーを押すことでジャンプすることができます。\nこれを利用して敵の攻撃を回避することができます。\nこれらの行動には酸素を使用するので注意しましょう。";
        }else if(flag_set == 3)
        {
            text_mak.text = "必殺技1";
            text_set.text = "敵に攻撃が命中すると左上の黄色い棒が増加します。\nこれが最大まで溜まると必殺技が使えるようになります。\n溜まった状態でEキーを押し、矢を発射すると、その矢が爆発して、敵に\n大きなダメージを与えます。";
        }else if(flag_set == 4)
        {
            text_mak.text = "必殺技2";
            text_set.text = "敵の攻撃に矢を当てるとその攻撃を止めることができます。攻撃を止めることが出来たとき、敵に矢を当てるよりも大きく必殺ゲージが増加します。";
        }else if(flag_set == 5)
        {
            text_mak.text = "一時停止";
            text_set.text = "ESCキーを押すことで、戦闘を一時中断することができます。\nこの画面では音量の調整やマウス感度の設定をすることができます。\nまた、戦闘を放棄してタイトルに戻ることもできます。";
        }

    }
}
