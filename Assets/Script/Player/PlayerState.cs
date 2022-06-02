using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField, Tooltip("���݃��x��"), Min(0)]  int _level = 1;//���݃��x��
    public int Level => _level;
    [SerializeField, Tooltip("���݌o���l"), Min(0)]  int _exp = 0;//���݌o���l
    public int Exp => _exp;
    [SerializeField, Tooltip("�K�v�o���l"), Min(0)]  int _expPool = 100;//�K�v�o���l
    public int ExpPool => _expPool;
    [SerializeField, Tooltip("�̗�"), Min(0)]  int _playerLife = 100;//�̗�
    public int Life => _playerLife;
    [SerializeField, Tooltip("�ő�̗�"), Min(0)]  int _playerMaxLife = 100;//�ő�̗�
    public int MaxLife => _playerMaxLife;

    bool _isDeath = false;
    public bool IsDeath => _isDeath;

    bool _isLevelUp = false;
    public bool IsLevelUp => _isLevelUp;
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
        //if (collision.gameObject.tag == "Exp")
        //{
        //    _exp += 10;
        //    Destroy(collision.gameObject);
        //}
    }

    void LevelManagar()//���x���Ǘ�
    {
        if(_exp >= _expPool)
        {
            LevelUp();
        }
    }

    void LevelUp()//���x�����オ�����ۂ̏���
    {
        _exp = 0;
        _isLevelUp = true;
        _playerMaxLife += 10;
        _playerLife = _playerMaxLife;
        _expPool += 10;
        _level ++;
        Debug.Log("�v���C���[�̃��x����" + _level + " �ɂȂ����I");
        Debug.Log("���̃��x���܂�" + _expPool + " �K�v");
    }

    public void GetExp(int exp)
    {
        _exp += exp;
    }
    public void Damage(int damage)
    {
        if(_playerLife <= 0)
        {
            Death();
        }
            _playerLife -= damage;
            Debug.Log(damage + " �_���[�W���󂯂ăv���C���[��HP�� " + _playerLife + " �ɂȂ����I");
    }

    public void Death()
    {

        _isDeath = true;
        Debug.Log("���S");
    }
}

