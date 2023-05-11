using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setting_con : MonoBehaviour
{
    public Slider slider_bgm;
    public Slider slider_se;
    public Slider slider_mou;
    public Text text_bgm;
    public Text text_se;
    public Text text_mou;
    public static float bgm_vol=1;
    public static float se_vol=1;
    public static float mou_vol=1;

    void Start()
    {
        slider_bgm.value = PlayerPrefs.GetFloat("BGM", 1.0f); 
        slider_se.value = PlayerPrefs.GetFloat("SE", 1.0f); 
        slider_mou.value = PlayerPrefs.GetFloat("Mou", 1.0f); 
    }

    // Update is called once per frame
    void Update()
    {
        text_bgm.text = (slider_bgm.value * 100).ToString("f0");        
        text_se.text = (slider_se.value * 100).ToString("f0");
        text_mou.text = (slider_mou.value).ToString("f2");
        bgm_vol = slider_bgm.value;
        se_vol = slider_se.value;
        mou_vol = slider_mou.value;
        if (mou_vol == 0f)
        {
            mou_vol = 0.1f;
        }
    }
}
