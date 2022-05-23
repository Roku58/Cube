using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;
//using DG.Tweening;
public class EnemyController : MonoBehaviour
{
     NavMeshAgent agent = null;
    [SerializeField, Min(0)] int maxHp = 100;
    [SerializeField, Min(0)] int hp = 100;
    [SerializeField, Min(0)] int atk = 1;
    [SerializeField, Min(0)] float speed = 1;
    GameObject player; //
    [SerializeField] GameObject bullet; //弾
    [SerializeField] GameObject death; //死体
    [SerializeField] GameObject　hitef; //ヒットエフェクト
    [SerializeField] Transform muzzle; //マズル
    Animator _anim = default;
    Rigidbody rb = default;

    //public ObjectPool<GameObject> enemyPool;
    private IObjectPool<EnemyController> enemyPool;


    public void Initialize(IObjectPool<EnemyController> pool)
    {
        enemyPool = pool;

    }
    public int Hp
    {
        set
        {
            hp = Mathf.Clamp(value, 0, maxHp);
        }
        get
        {
            return hp;
        }
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetHP();
        //_anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void LateUpdate()
    {
        // アニメーションの処理
        if (_anim)
        {
            _anim.SetFloat("Speed", agent.velocity.magnitude);        }
    }
    void Update()
    {
        //Vector3 enemypos = this.transform.position;
        //Vector3 playerpos = player.transform.position;
        //float dis = Vector3.Distance(enemypos, playerpos);
        Move();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<PlayerState>().Damage(atk);
            //var obj = Instantiate(death, this.transform.position, Quaternion.identity);
            enemyPool.Release(this);

        }
    }

    void SetHP()
    {
        Hp = maxHp;
    }

    void Move()
    {
        if(player)
        {
            transform.LookAt(player.transform);
            Vector3 directionToTarget = (player.transform.position - transform.position).normalized;
            rb.velocity = directionToTarget * speed;
            

        }

        
    }

    void AttackBullet()
    {
        var go = Instantiate(bullet);
        go.transform.position = muzzle.position;
        go.transform.forward = muzzle.forward;
    }

    // 被ダメージ処理
    public void Damage(int damage)
    {
        hp -= damage;
        Debug.Log(damage + " ダメージを受けてエネミーのHPが " + hp + " になった！");
        if (Hp <= 0)
        {
            Dead();
        }
    }


    public void Dead()
    {
        //Instantiate(sitai);
        enemyPool.Release(this);
    }

}