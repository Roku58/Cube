using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObjectPool , IPause
{
    [SerializeField, Tooltip(""), Min(0)] int maxHp = 100;
    [SerializeField, Tooltip(""), Min(0)] int hp = 100;
    [SerializeField, Tooltip(""), Min(0)] int atk = 5;
    [SerializeField, Tooltip(""), Min(0)] float speed = 1;
    GameObject player; //
    [SerializeField, Tooltip("")] GameObject bullet; //弾
    [SerializeField, Tooltip("")] GameObject[] death; //死体
    [SerializeField, Tooltip("")] GameObject hitef; //ヒットエフェクト
    [SerializeField, Tooltip("")] Transform muzzle; //マズル
    ItemDrop _itemDrop;
    Animator _anim = default;
    Rigidbody rb = default;
    [SerializeField] bool _isboss = false;

    enum EnemyType
    {
        Mob ,
        Boss ,
        Box ,
    }

    [SerializeField] EnemyType enemyType = EnemyType.Mob;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        _itemDrop = FindObjectOfType<ItemDrop>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (enemyType == EnemyType.Box)
        {
            return;
        }
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
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerState>().GetDamage(atk);
        }

        if (collision.gameObject.tag == "Weapon")
        {
            //collision.gameObject.GetComponent<PlayerState>().GetDamage(atk);
            //var obj = Instantiate(death, this.transform.position, Quaternion.identity);

        }

    }


    public void GetDamage(int damage)
    {
        hp -= damage;
        Debug.Log(damage + " ダメージを受けてプレイヤーのHPが " + hp + " になった！");
        if (hp <= 0)
        {

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
        if(enemyType == EnemyType.Boss)
        {
            int x = Random.Range(0, death.Length);
            Instantiate(death[x]);
        }
        else if(enemyType == EnemyType.Box)
        {
            
        }
        else
        {
            var item = _itemDrop.Spawn();
            if (item)
            {
                item.transform.position = transform.position;
            }
            gameObject.SetActive(false);
            _isActrive = false;
        }

    }

    public void Pause()
    {

    }

    public void Resume()
    {

    }
}
