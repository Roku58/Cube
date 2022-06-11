using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform muzzle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AttackBullet()
    {
        var go = Instantiate(bullet);
        go.transform.position = muzzle.position;
        go.transform.forward = muzzle.forward;
    }

    void Daeth()
    {
        Destroy(gameObject);
    }
}
