using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField, Tooltip("現在レベル"), Min(0)] public int _level = 1;//現在レベル
    public int Level => _level;
    [SerializeField, Tooltip("現在経験値"), Min(0)] public int _exp = 0;//現在経験値
    public int Exp => _exp;
    [SerializeField, Tooltip("必要経験値"), Min(0)] public int _expPool = 100;//必要経験値
    public int ExpPool => _expPool;
    [SerializeField, Tooltip("体力"), Min(0)] public int _playerLife = 100;//体力
    public int Life => _playerLife;
    [SerializeField, Tooltip("最大体力"), Min(0)] public int _playerMaxLife = 100;//最大体力
    public int MaxLife => _playerMaxLife;

    bool _isDeath = false;
    public bool IsDeath => _isDeath;

    void Start()
    {
        _playerLife = _playerMaxLife;
    }

    void Update()
    {
        LevelManagar();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Exp")
        {
            _exp += 10;
            Destroy(collision.gameObject);
        }
    }

    void LevelManagar()//レベル管理
    {
        if(_exp == _expPool)
        {
            LevelUp();
        }
    }

    void LevelUp()//レベルが上がった際の処理
    {
        _exp = 0;
        _playerMaxLife += 10;
        _playerLife = _playerMaxLife;
        _expPool += 10;
        _level ++;
        Debug.Log("プレイヤーのレベルが" + _level + " になった！");
        Debug.Log("次のレベルまで" + _expPool + " 必要");
    }

    public void Damage(int damage)
    {
        if(_playerLife <= 0)
        {
            Death();
        }
            _playerLife -= damage;
            Debug.Log(damage + " ダメージを受けてプレイヤーのHPが " + _playerLife + " になった！");
    }

    public void Death()
    {

        _isDeath = true;
        Debug.Log("死亡");
    }
}

