using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect_wave : MonoBehaviour
{
    private Vector3 large;
    public int speed=5;     //膨張の速さ

    void Start()
    {
        large = gameObject.transform.localScale;    //オブジェクトの大きさを取得
    }
    void Update()
    {
        //speedだけ拡大
        large.x += speed;
        large.y += speed;
        //変化した大きさの値をオブジェクトに反映
        gameObject.transform.localScale = large;
    }

}
