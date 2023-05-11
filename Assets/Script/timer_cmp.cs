using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer_cmp : MonoBehaviour
{
    public menu_cmp menu_cmp;
    public Text timer_text;
    public int min;
    public float sec;
    private float sec_old;

    // Start is called before the first frame update
    void Start()
    {
        min = 0;
        sec = 0;
        sec_old = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //時間が止まっていない時
        if (!menu_cmp.stop)
        {
            sec += Time.deltaTime;
            if (sec >= 60f)
            {
                min += 1;
                sec -= 60f;
            }

            //1s毎にテキスト更新
            if ((int)sec != (int)sec_old)
            {
                timer_text.text = min.ToString("00") + ":" + ((int)sec).ToString("00");
            }
            sec_old = sec;
        }
    }
}
