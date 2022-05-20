using System.Collections;
using UnityEngine;
using UnityEngine.AI;
//using DG.Tweening;
public class EnemyController : MonoBehaviour
{
     NavMeshAgent agent = null;
    [SerializeField, Min(0)] int maxHp = 100;
    [SerializeField, Min(0)] int hp = 100;
    public int atk = 1;
    [SerializeField] GameObject bullet; //弾プレハブ
    [SerializeField] GameObject death; //死体プレハブ
    [SerializeField] GameObject　hitef; //ヒットエフェクト
    [SerializeField] Transform muzzle; //マズル
    Animator _anim = default;
    GameObject player = default;
    [SerializeField] float sarchdistance = 5;//探知距離
    [SerializeField] float atackdistance = 2;//探知距離





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
        SetHP();
        _anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
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
        Vector3 enemypos = this.transform.position;
        Vector3 playerpos = player.transform.position;
        //float dis = Vector3.Distance(enemypos, playerpos);
        //agent.isStopped = false;
        Move();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerState>().Damage(atk);
            this.gameObject.SetActive(false);
            var obj = Instantiate(death, this.transform.position, Quaternion.identity);
            foreach (ContactPoint point in collision.contacts)
            {
                GameObject damageEf = Instantiate(hitef) as GameObject;
                damageEf.transform.position = (Vector3)point.point;
                Debug.Log("EHF");
            }
            Destroy(this.gameObject,1f);
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
            agent.SetDestination(player.transform.position);

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


    void Dead()
    {
        //Instantiate(sitai);
        Destroy(gameObject);
        //isDead = true;
        //animator.SetBool(DeadHash, true);
        //StartCoroutine(DeadTimer());
    }

}