using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

	//　アイテムデータベース
	[SerializeField]
	private SkillDataBase skillDataBase;
    //　スキルレベル管理
    private Dictionary<Skill, int> numOfItem = new Dictionary<Skill, int>();
    [SerializeField]List<Skill> _skills = new List<Skill>();

	// Use this for initialization
	void Start()
	{
        //var list = GameData.SkillSelectTable.Where(s => player.Level >= s.Level);
        GetSkill(1);
        for (int i = 0; i < _skills.Count; i++)
        {
            AddSkill(i);
            //　確認の為データ出力
            //Debug.Log(skillDataBase.GetItemLists()[i].GetSkillID() + ": " + skillDataBase.GetItemLists()[i]);
            //Debug.Log(GetItem(i));
        }
        foreach (Skill s in _skills)
        {
            Debug.Log(s);
        }

        //for (int i = 0; i < skillDataBase.GetItemLists().Count; i++)
        //{
        //    //　アイテム数を適当に設定
        //    numOfItem.Add(skillDataBase.GetItemLists()[i], i);
        //    //　確認の為データ出力
        //    Debug.Log(skillDataBase.GetItemLists()[i].GetItemName() + ": " + skillDataBase.GetItemLists()[i]);
        //}
        //Debug.Log(GetItem(1));
        //Debug.Log(numOfItem[GetItem(2)]);



        //Debug.Log(_skills[GetItem(ski)]);

    }

	public Skill GetSkill(int searchId)
	{
		return skillDataBase.GetItemLists().
			Find(skillId => skillId.GetSkillID() == searchId);
	}

	//public void AddSkill(int id)
	//{
	//	_skills.Add(GetItem(id));
	//}
    public void AddSkill(int id)
    {
            var s = GetSkill(id);
            {
                if (s != null)
                {
                    _skills.Add(GetSkill(id));
                    s.SetUp();
                }
            }
   
    }
    //　名前でアイテムを取得
    //public Skill GetItem(string searchName)
    //{
    //    return skillDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
    //}

}