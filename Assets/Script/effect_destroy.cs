using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect_destroy : MonoBehaviour
{
    void Start()
    {
        Invoke("effect_des", 5.0f);
    }

    private void effect_des()
    {
        Destroy(this.gameObject);
    }
}
