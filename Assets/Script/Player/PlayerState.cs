using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
public class PlayerState : MonoBehaviour
{
    [SerializeField, Tooltip("���݃��x��"), Min(0)]  int _level = 1;
    public int Level => _level;
    [SerializeField, Tooltip("���݌o���l"), Min(0)]  int _exp = 0;
    public int Exp => _exp;
    [SerializeField, Tooltip("�K�v�o���l"), Min(0)]  int _expPool = 100;
    public int ExpPool => _expPool;
    [SerializeField, Tooltip("�̗�"), Min(0)]  int _life = 100;
    public int Life => _life;
    [SerializeField, Tooltip("�ő�̗�"), Min(0)]  int _maxLife = 100;
    public int MaxLife => _maxLife;
    [SerializeField, Tooltip("SP"), Min(0)] int _sp = 0;
    public int Sp => _sp;
    [SerializeField, Tooltip("�ő�SP"), Min(0)] int _maxSp = 100;
    public int MaxSp => _maxSp;

    [SerializeField] GameObject _damageEf;
    [SerializeField] float _damage;

    bool _isDeath = false;
    public bool IsDeath => _isDeath;

    bool _isLevelUp = false;
    public bool IsLevelUp => _isLevelUp;

    [SerializeField]List<Skill> _skill = new List<Skill>();

    void Start()
    {
        //_damageEf = GetComponent<GlitchFx>();
        _life = _maxLife;
    }

    void Update()
    {
        LevelManagar();
        if(_maxLife < _life)
        {
            _life = _maxLife;
        }

        xxx();
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
        _maxLife += _level * 5;
        _life = _maxLife;
        _expPool += _level * 10;
        _level ++;
        Debug.Log("�v���C���[�̃��x����" + _level + " �ɂȂ����I");
        Debug.Log("���̃��x���܂�" + _expPool + " �K�v");
    }

    void xxx()
    {
        if (_sp >= _maxSp)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                _sp = 0;
                Debug.Log("�K�E�Z");
            }
        }
    }

    public void AddSkill(int skillId)
    {
        var having = _skill.Where(s => s.skillId == skillId);
        if (having.Count() > 0)
        {
            having.Single().LevelUp();
        }
        else
        {
            Skill newSkill = null;

            if (newSkill != null)
            {
                newSkill.SetUp();
                _skill.Add(newSkill);
            }
        }
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
        //DamageEf();
        StartCoroutine("DamageEf");
        _life -= damage;
        Debug.Log(damage + " �_���[�W���󂯂ăv���C���[��HP�� " + _life + " �ɂȂ����I");
        //_damageEf.GetComponent<GlitchFx>().enabled = false;
    }

    IEnumerator DamageEf()
    {
        //float a = _damageEf.intensity;
        //DOTween.To(
        //getter: () => a, // Tween�������Ώۂ̎擾 
        //setter: num => a = num, // Tween�������Ώۂ̐ݒ�
        //endValue: 0.5, // �ŏI�I�Ȓl
        //duration: 0.3 // �A�j���[�V��������
        //);
        _damageEf.GetComponent<GlitchFx>().enabled = true;
        //yield return null;
        yield return new WaitForSeconds(_damage);

        _damageEf.GetComponent<GlitchFx>().enabled = false;

    }
    
    public void Death()
    {

        _isDeath = true;
        Debug.Log("�Q�[���I�[�o�[");
    }
}

