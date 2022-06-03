using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField, Tooltip("現在レベル"), Min(0)]  int _level = 1;
    public int Level => _level;
    [SerializeField, Tooltip("現在経験値"), Min(0)]  int _exp = 0;
    public int Exp => _exp;
    [SerializeField, Tooltip("必要経験値"), Min(0)]  int _expPool = 100;
    public int ExpPool => _expPool;
    [SerializeField, Tooltip("体力"), Min(0)]  int _life = 100;
    public int Life => _life;
    [SerializeField, Tooltip("最大体力"), Min(0)]  int _maxLife = 100;
    public int MaxLife => _maxLife;
    [SerializeField, Tooltip("SP"), Min(0)] int _sp = 0;
    public int Sp => _sp;
    [SerializeField, Tooltip("最大SP"), Min(0)] int _maxSp = 100;
    public int MaxSp => _maxSp;

    bool _isDeath = false;
    public bool IsDeath => _isDeath;

    bool _isLevelUp = false;
    public bool IsLevelUp => _isLevelUp;
    void Start()
    {
        _life = _maxLife;
    }

    void Update()
    {
        LevelManagar();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Exp")
        //{
        //    _exp += 10;
        //    Destroy(collision.gameObject);
        //}
    }

    void LevelManagar()//レベル管理
    {
        if(_exp >= _expPool)
        {
            LevelUp();
        }
    }

    void LevelUp()//レベルが上がった際の処理
    {
        _exp = 0;
        _isLevelUp = true;
        _maxLife += _level * 5;
        _life = _maxLife;
        _expPool += _level * 10;
        _level ++;
        Debug.Log("プレイヤーのレベルが" + _level + " になった！");
        Debug.Log("次のレベルまで" + _expPool + " 必要");
    }

    public void GetItem(int exp ,int sp , int hp)
    {
        _exp += exp;
        _sp += sp;
        _life += hp;
    }
    public void GetDamage(int damage)
    {
        if(_life <= 0)
        {
            Death();
        }
            _life -= damage;
            Debug.Log(damage + " ダメージを受けてプレイヤーのHPが " + _life + " になった！");
    }

    public void Death()
    {

        _isDeath = true;
        Debug.Log("ゲームオーバー");
    }
}

