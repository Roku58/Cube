using System;
using System.Collections.Generic;

public enum SelectType //スキルタイプ
{
    Skill = 1,
    Passive = 2,
   // Execute = 3,
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
        new SkillSelectTable(){ Type = SelectType.Skill, Level = 0, TargetId = 1, Probability = 80 , Name = "シールド"},
        new SkillSelectTable(){ Type = SelectType.Skill, Level = 0, TargetId = 1, Probability = 80 , Name = "大鎌"},
        new SkillSelectTable(){ Type = SelectType.Skill, Level = 0, TargetId = 1, Probability = 80 , Name = "大剣"},
        new SkillSelectTable(){ Type = SelectType.Skill, Level = 0, TargetId = 1, Probability = 80 , Name = "腕"},
        //new SkillSelectTable(){ Type = SelectType.Skill, TargetId = 1, Name = "遠距離弾", Level = 0, Probability = 80 },
        //new SkillSelectTable(){ Type = SelectType.Skill, TargetId = 2, Name = "近距離範囲", Level = 0, Probability = 80 },
        //new SkillSelectTable(){ Type = SelectType.Passive, TargetId = 1, Name = "攻撃UP", Level = 0, Probability = 40 },
        //new SkillSelectTable(){ Type = SelectType.Passive, TargetId = 2, Name = "速度UP", Level = 0, Probability = 20 },
        //new SkillSelectTable(){ Type = SelectType.Passive, TargetId = 3, Name = "攻撃速度UP", Level = 5, Probability = 10 },
        //new SkillSelectTable(){ Type = SelectType.Execute, TargetId = 1, Name = "回復", Level = 0, Probability = 90 },
        //new SkillSelectTable(){ Type = SelectType.Execute, TargetId = 2, Name = "ゴールド", Level = 0, Probability = 40 }
    };
}
