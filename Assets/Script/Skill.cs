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
    [SerializeField] string itemName; // �A�C�e���̖��O
    [SerializeField] public�@int skillId;//�X�L��ID
    [SerializeField] public int skillLevel;//�X�L�����x��
    [SerializeField] public int maxskillLevel;//�X�L�����x��
    [SerializeField] float cooltime;//�N�[���^�C��
    [SerializeField] int atk;//�U����
    [SerializeField] float speed;//����

    [SerializeField] Sprite icon; // �A�C�e���̉摜
    [SerializeField] bool isCombinable; // ���̂ł��邩�ǂ���
    [SerializeField] Combinable[] combinable; // ���̏��̔z��
    [SerializeField] GameObject prefab; // �A�C�e���̃v���n�u

    //�@�X�L���̎�ނ�Ԃ�
    public SkillType GetSkillType()
    {
        return skillType;
    }
    //�@�X�L����ID��Ԃ�
    public int GetSkillID()
    {
        return skillId;
    }
    //�@�X�L���̖��O��Ԃ�
    public string GetItemName()
    {
        return itemName;
    }
    //�@�X�L���̖��O��Ԃ�
    public Sprite GetIcon()
    {
        return icon;
    }

    //�@�X�L���̍U���͂�Ԃ�
    public int GetATK()
    {
        return atk;
    }

    //�@�X�L���̃N�[���^�C����Ԃ�
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

    // �Ώۂ̃A�C�e��������A���̂��Ăł���A�C�e��������
    public Skill GetCombinableInto(string withItem)
    {
        foreach (var comb in GetCombinable())
        {
            if (withItem == comb.GetWithItem())
            {
                // ����������
                //return ItemManager.GetInstance().GetItem(comb.GetIntoItem());
            }
        }

        // ������Ȃ�������
        return null;
    }

}

// ���̂ł���Ώۂƍ����A�C�e���̖��O�����N���X
[Serializable]
public class Combinable
{
    [SerializeField] string withItem; // �Ώۂ̃A�C�e���̖��O
    [SerializeField] string intoItem; // ���̂��Ăł���A�C�e���̖��O

    public string GetWithItem()
    {
        return withItem;
    }

    public string GetIntoItem()
    {
        return intoItem;
    }
}
