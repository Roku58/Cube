using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
[CreateAssetMenu(fileName = "Skill", menuName = "CreateSkill")]
public class Skill: ScriptableObject
{
    [SerializeField]public enum SkillType
    {
        Wepon,
        Passive
    }

    [SerializeField] SkillType skillType = SkillType.Wepon;
    [SerializeField] string itemName; // アイテムの名前
    [SerializeField] public　int skillId;//スキルID
    [SerializeField] public int skillLevel;//スキルレベル
    [SerializeField] public int maxskillLevel;//スキルレベル
    [SerializeField] float cooltime;//クールタイム
    [SerializeField] int atk;//攻撃力
    [SerializeField] float speed;//速さ

    [SerializeField] Sprite icon; // アイテムの画像
    [SerializeField] bool isCombinable; // 合体できるかどうか
    [SerializeField] Combinable[] combinable; // 合体情報の配列
    [SerializeField] GameObject prefab; // アイテムのプレハブ

    //　スキルの種類を返す
    public SkillType GetSkillType()
    {
        return skillType;
    }
    //　スキルのIDを返す
    public int GetSkillID()
    {
        return skillId;
    }
    //　スキルの名前を返す
    public string GetItemName()
    {
        return itemName;
    }
    //　スキルの名前を返す
    public Sprite GetIcon()
    {
        return icon;
    }

    //　スキルの攻撃力を返す
    public int GetATK()
    {
        return atk;
    }

    //　スキルのクールタイムを返す
    public float GetCooltime()
    {
        return cooltime;
    }


    public bool GetIsCombinable()
    {
        return isCombinable;
    }

    public Combinable[] GetCombinable()
    {
        return combinable;
    }

    public GameObject GetPrefab()
    {
        return prefab;
    }

    public void SetUp()
    {
        skillLevel = 1;
    }
    public void LevelUp()
    {
        if (skillLevel <= maxskillLevel)
        {
            skillLevel++;
        }
    }

    // 対象のアイテム名から、合体してできるアイテムを検索
    public Skill GetCombinableInto(string withItem)
    {
        foreach (var comb in GetCombinable())
        {
            if (withItem == comb.GetWithItem())
            {
                // 見つかった時
                //return ItemManager.GetInstance().GetItem(comb.GetIntoItem());
            }
        }

        // 見つからなかった時
        return null;
    }

}

// 合体できる対象と作られるアイテムの名前を持つクラス
[Serializable]
public class Combinable
{
    [SerializeField] string withItem; // 対象のアイテムの名前
    [SerializeField] string intoItem; // 合体してできるアイテムの名前

    public string GetWithItem()
    {
        return withItem;
    }

    public string GetIntoItem()
    {
        return intoItem;
    }
}
