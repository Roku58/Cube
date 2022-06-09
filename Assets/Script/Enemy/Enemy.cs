using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObjectPool
{
    [SerializeField, Tooltip(""), Min(0)] int maxHp = 100;
    [SerializeField, Tooltip(""), Min(0)] int hp = 100;
    [SerializeField, Tooltip(""), Min(0)] int atk = 1;
    [SerializeField, Tooltip(""), Min(0)] float speed = 1;
    GameObject player; //
    [SerializeField, Tooltip("")] GameObject bullet; //弾
    [SerializeField, Tooltip("")] GameObject[] death; //死体
    [SerializeField, Tooltip("")] GameObject hitef; //ヒットエフェクト
    [SerializeField, Tooltip("")] Transform muzzle; //マズル
    Animator _anim = default;
    Rigidbody rb = default;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //if (!IsActive) return;
        transform.LookAt(player.transform);
        Vector3 sub = player.transform.position - transform.position;
        sub.Normalize();

        //transform.position += sub * _speed * Time.deltaTime;


        Vector3 velocity = sub.normalized * speed;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerState>().GetDamage(atk);
            //var obj = Instantiate(death, this.transform.position, Quaternion.identity);
            Deth();
        }
    }


    public void GetDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            //var go = Instantiate(_expObj, transform.position, Quaternion.identity);
            //go.AddEXP = _dropEXPValue;
            Deth();
        }
    }

    //ObjectPool
    bool _isActrive = false;
    public bool IsActive => _isActrive;
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
        var x = Random.Range(0, death.Length);
        gameObject.SetActive(false);
        //if (!death[x])
        //{
        //    Instantiate(death[x], this.transform.position, Quaternion.identity);
        //}
        Instantiate(death[1], this.transform.position, Quaternion.identity);
        //if (death.transform.parent != null)
        //{
        //    death.SetActive(true);
        //    death.transform.parent = null;

        //}
        _isActrive = false;
    }
}
