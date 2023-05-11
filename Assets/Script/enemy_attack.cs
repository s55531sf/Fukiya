using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_attack : MonoBehaviour
{
    public GameObject slash1;
    public GameObject slash2;
    public GameObject wave;
    public GameObject enemy;
    public audio_con audio_con;

    private Vector3 pos;
    private int flag;
    private int speed;//”­Ë‘¬“x

    void Start()
    {
        flag = select_cmp.dif_flag;
        if (flag == 0)//“ïˆÕ“x”~
        {
            speed = 400;

        }else if(flag == 1)//“ïˆÕ“x’|
        {
            speed = 500;

        }else if (flag == 2)//“ïˆÕ“x¼
        {
            speed = 600;
        }
    }

    public void Slash1()//‰¡Œ•Œ‚
    {
        GameObject attack = (GameObject)Instantiate(slash1, transform.position, enemy.transform.rotation);//Œ•Œ‚¶¬
        Rigidbody attackRigidbody = attack.GetComponent<Rigidbody>();//Œ•Œ‚‚ÌRigidbodyæ“¾
        attackRigidbody.AddForce(transform.forward *-speed);  //”­Ë(‘¬“x‚Íspeed*4ˆË‘¶)
        audio_con.Se_Start(10);
    }

    public void Slash2()//cŒ•Œ‚
    {
        GameObject attack = (GameObject)Instantiate(slash2, transform.position, enemy.transform.rotation);//Œ•Œ‚¶¬
        Rigidbody attackRigidbody = attack.GetComponent<Rigidbody>();//Œ•Œ‚‚ÌRigidbodyæ“¾
        attackRigidbody.AddForce(transform.forward * -speed);  //”­Ë(‘¬“x‚Íspeed*4ˆË‘¶)
        audio_con.Se_Start(10);
    }

    public void Wave()//ÕŒ‚”g
    {
        pos = transform.position;
        pos.y -= 0.5f;
        GameObject attack = (GameObject)Instantiate(wave, pos, transform.rotation);//ÕŒ‚”g¶¬
        attack.transform.eulerAngles = new Vector3(90, 0, 0);//ÕŒ‚”g‚ğx²‚ğ’†S‚É90“x‰ñ“]
    }
}
