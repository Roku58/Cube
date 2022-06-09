public interface ISkill
{
    /// <summary>�X�L����ID</summary>
    SkillID ID { get; }

    /// <summary>�X�L���̃^�C�v</summary>
    SkillType Type { get; }
    SkillDef SkillId { get; }


    /// <summary>�X�L���̃��x�����ő傩�ǂ���</summary>
    bool IsLevelMax { get; }

    /// <summary>����擾���ɌĂ�</summary>
    void SetUp();

    /// <summary>���t���[���Ă�</summary>
    void Update();

    /// <summary>���ڈȍ~�̎擾���ɌĂ�</summary>
    void LevelUp();

    /// <summary>�X�L���폜���ɌĂ�</summary>
    void Delete();
}


public enum SkillID
{
    Gun = 0,
    AddHP = 1,
}

public enum SkillType
{
    Active = 0,
    Passive = 1,
}

public enum SkillDef
{
    Invalid = 0,
    MeleeWeapon = 1,
    ShotBullet = 2,
    AreaAttack = 3,
}