using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
public class PlayerState : MonoBehaviour
{
    [SerializeField, Tooltip("体力"), Min(0)]  int _life = 100;
    public int Life => _life;
    [SerializeField, Tooltip("最大体力"), Min(0)]  int _maxLife = 100;
    public int MaxLife => _maxLife;
    [SerializeField, Tooltip("SP"), Min(0)] int _sp = 0;
    public int Sp => _sp;
    [SerializeField, Tooltip("最大SP"), Min(0)] int _maxSp = 100;
    public int MaxSp => _maxSp;

    [SerializeField] GameObject _damageEf;
    [SerializeField] GameObject[] _exAtack;
    [SerializeField] float _damage;

    bool _isDeath = false;
    public bool IsDeath => _isDeath;

    bool _isLevelUp = false;
    public bool IsLevelUp => _isLevelUp;

    //[SerializeField]List<Skill> _skill = new List<Skill>();
    [SerializeField] List<GameObject> _skills = new List<GameObject>();
    

    void Start()
    {
        //_damageEf = GetComponent<GlitchFx>();
        _life = _maxLife;
    }

    void Update()
    {
        //LevelManagar();
        if(_maxLife < _life)
        {
            _life = _maxLife;
        }

        ExAtack();
    }

    

    

    void ExAtack()//必殺技
    {
        if (_sp >= _maxSp)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                _sp = 0;
                int x = (Random.Range(0, _exAtack.Length));
                var go = Instantiate(_exAtack[x]);
                go.transform.position = transform.position;
                Debug.Log("必殺技");
            }
        }
    }

    public void AddSkill(int skillId)
    {
        var having = _skills.Where(s => s.GetComponent<ISkill>().SkillId == (SkillDef)skillId);
        if (having.Count() > 0)
        {
            having.Single().GetComponent<ISkill>().LevelUp();
        }
        else
        {
            GameObject newskill = null;
            switch ((SkillDef)skillId)
            {
                case SkillDef.MeleeWeapon:
                    break;

                case SkillDef.ShotBullet:
                    break;

                case SkillDef.AreaAttack:
                    break;
            }

            if (newskill != null)
            {
                newskill.GetComponent<ISkill>().SetUp();
                _skills.Add(newskill);
            }
        }
    }

    public void GetItem(int sp , int hp)
    {
        _sp += sp;
        _life += hp;
    }
    public void GetDamage(int damage)
    {
        if(_life <= 0)
        {
            Death();
        }
        StartCoroutine("DamageEf");
        _life -= damage;
        //Debug.Log(damage + " ダメージを受けてプレイヤーのHPが " + _life + " になった！");
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

