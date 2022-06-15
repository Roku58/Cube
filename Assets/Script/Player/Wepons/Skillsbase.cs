using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Skillsbase : MonoBehaviour
{

    protected float _timer = 0;

    protected float _skillLevel = 1;

    public float _cooldown { get; set; } = 2;
    //protected AddOrignalMethod Method = new AddOrignalMethod();
    public virtual void ActiveSkill()
    {

    }
}

public interface ISkill
{
    /// <summary>スキルのID</summary>
    //SkillID ID { get; }

    ///// <summary>スキルのタイプ</summary>
    //SkillType Type { get; }
    SkillDef SkillId { get; }


    ///// <summary>スキルのレベルが最大かどうか</summary>
    //bool IsLevelMax { get; }

    /// <summary>初回取得時に呼ぶ</summary>
    void SetUp();


    /// <summary>二回目以降の取得時に呼ぶ</summary>
    void LevelUp();
}


//public enum SkillID
//{
//    Gun = 0,
//    AddHP = 1,
//}

//public enum SkillType
//{
//    Active = 0,
//    Passive = 1,
//}

public enum SkillDef
{
    Invalid = 0,
    Scythes = 1,
    ShotBullet = 2,
    AreaAttack = 3,
}