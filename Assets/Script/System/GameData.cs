using System;
using System.Collections.Generic;

public enum SelectType //スキルタイプ
{
    Skill = 1,
    Passive = 2,
    Execute = 3,
}

//[Serializable]
public class SkillSelectTable　//スキルパラメータまとめ
{
    public SelectType Type;
    public int TargetId;
    public string Name;
    public int Level;
    public int Probability;
}

public class GameData
{
    static public List<SkillSelectTable> SkillSelectTable = new List<SkillSelectTable>()
    {
        new SkillSelectTable(){ Type = SelectType.Skill, TargetId = 1,Level = 0 , Probability = 80 , Name = "Scythes"},
        //new SkillSelectTable(){ Type = SelectType.Skill, TargetId = 2,Level = 0 , Probability = 80 , Name = "シールド"},
        new SkillSelectTable(){ Type = SelectType.Skill, TargetId = 2,Level = 0 , Probability = 80 , Name = "Trap"},
        new SkillSelectTable(){ Type = SelectType.Skill, TargetId = 3,Level = 0 , Probability = 80 , Name = "Shot"},
        new SkillSelectTable(){ Type = SelectType.Skill, TargetId = 4,Level = 0 , Probability = 80 , Name = "Spear"},
        new SkillSelectTable(){ Type = SelectType.Passive, TargetId = 1,Level = 0 , Probability = 80 , Name = "Heal"},
    };
}
