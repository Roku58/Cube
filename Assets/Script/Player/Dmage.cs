using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dmage : MonoBehaviour
    //武器や弾につける
{
    public int damage = 10;
    [SerializeField] GameObject hitef; //ヒットエフェクト

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().GetDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().GetDamage(damage);
        }
    }
}

