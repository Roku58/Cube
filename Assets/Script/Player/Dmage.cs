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

        if (collision.gameObject.GetComponent<EnemyController>())
        {
            collision.gameObject.GetComponent<EnemyController>().Damage(damage);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            foreach (ContactPoint point in collision.contacts)
            {
                GameObject damageEf = Instantiate(hitef) as GameObject;
                damageEf.transform.position = (Vector3)point.point;
                Debug.Log("EHF");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyController>())
        {
            other.gameObject.GetComponent<EnemyController>().Damage(damage);
        }
    }
}

