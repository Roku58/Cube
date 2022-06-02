using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public int exp = 10;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //Vector3 exppos = this.transform.position;
        //Vector3 playerpos = player.transform.position;
        //float dis = Vector3.Distance(exppos, playerpos);

        //if(dis > 10)
        //{
        //    Vector3 sub = player.transform.position -  this.transform.position;
        //    transform.position += sub * 10 ;
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<PlayerState>().GetExp(exp);
            Destroy(this.gameObject);
        }

    }
}
