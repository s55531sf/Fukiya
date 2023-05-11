using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damage_effect_controler : MonoBehaviour
{
    public Image img;


    // Update is called once per frame
    void Update()
    {
        this.img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime);
    }
}
