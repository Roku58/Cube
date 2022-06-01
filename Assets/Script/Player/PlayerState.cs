using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField, Tooltip(""), Min(0)] public int _level = 1;//現在レベル
    [SerializeField, Tooltip(""), Min(0)] public int _exp = 0;//現在経験値
    [SerializeField, Tooltip(""), Min(0)] public int _expPool = 100;//必要経験値
    [SerializeField, Tooltip(""), Min(0)] public int _playerLife = 100;//体力
    [SerializeField, Tooltip(""), Min(0)] public int _playerMaxLife = 100;//最大体力

    bool _isDeath = false;

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

