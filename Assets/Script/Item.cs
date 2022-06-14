using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IObjectPool
{
    public int exp = 0;
    public int sp = 0;
    public int hp = 0;
    GameObject player;

    bool _isActrive = false;
    public bool IsActive => _isActrive;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<PlayerState>().GetItem(sp, hp);
            GameManager.Instance.AddExp(exp);
            Deth();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "GetItem")
        {
            Move();
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.5f);
    }

    public void DisactiveForInstantiate()
    {
        gameObject.SetActive(false);
        _isActrive = false;
    }
    public void Create()
    {
        gameObject.SetActive(true);
        _isActrive = true;
    }
    public void Deth()
    {
        gameObject.SetActive(false);
        _isActrive = false;
    }
}
