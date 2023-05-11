using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class side_large : MonoBehaviour
{
    public GameObject obj;
    public Vector3 speed = new Vector3(1,0,0); //膨張速度
    public float time = 1.0f; //消える時間
    private Vector3 large;
    // Update is called once per frame
    void Start()
    {
        //オブジェクトの大きさを代入
        large = obj.transform.localScale;
        Invoke("Object_Destroy", time);
    }

    void Update()
    {
        large += speed;
        obj.transform.localScale = large;
    }

    void Object_Destroy()
    {
        Destroy(obj);
    }
}
