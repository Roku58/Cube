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
    /// <summary>�X�L����ID</summary>
    //SkillID ID { get; }

    ///// <summary>�X�L���̃^�C�v</summary>
    //SkillType Type { get; }
    SkillDef SkillId { get; }


    ///// <summary>�X�L���̃��x�����ő傩�ǂ���</summary>
    //bool IsLevelMax { get; }

    /// <summary>����擾���ɌĂ�</summary>
    void SetUp();

    void SkillUpdate();
    /// <summary>���ڈȍ~�̎擾���ɌĂ�</summary>
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
    Trap = 2,
    Shot = 3,
    Spears = 4,
}