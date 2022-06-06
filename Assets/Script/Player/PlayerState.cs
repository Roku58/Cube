using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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

    [SerializeField] GameObject _damageEf;
    [SerializeField] float _damage;

    bool _isDeath = false;
    public bool IsDeath => _isDeath;

    bool _isLevelUp = false;
    public bool IsLevelUp => _isLevelUp;

    [SerializeField]List<SkillManager> _skill = new List<SkillManager>();

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

    public void AddSkill(int id)
    {
        //_skill.Add((SkillID)id);
        //SkillManager.Instance.AddSkill(id);
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
        Debug.Log(damage + " ダメージを受けてプレイヤーのHPが " + _life + " になった！");
        //_damageEf.GetComponent<GlitchFx>().enabled = false;
    }

    IEnumerator DamageEf()
    {
        //float a = _damageEf.intensity;
        //DOTween.To(
        //getter: () => a, // Tweenしたい対象の取得 
        //setter: num => a = num, // Tweenしたい対象の設定
        //endValue: 0.5, // 最終的な値
        //duration: 0.3 // アニメーション時間
        //);
        _damageEf.GetComponent<GlitchFx>().enabled = true;
        //yield return null;
        yield return new WaitForSeconds(_damage);

        _damageEf.GetComponent<GlitchFx>().enabled = false;

    }
    
    public void Death()
    {

        _isDeath = true;
        Debug.Log("ゲームオーバー");
    }
}

