using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

	//�@�A�C�e���f�[�^�x�[�X
	[SerializeField]
	private SkillDataBase skillDataBase;
	//�@�X�L�����x���Ǘ�
	//private Dictionary<Skill, int> numOfItem = new Dictionary<Skill, int>();
	Skill skill;
	 List<Skill> _skills = new List<Skill>();

	// Use this for initialization
	void Start()
	{
		//var list = GameData.SkillSelectTable.Where(s => player.Level >= s.Level);

		for (int i = 0; i < skillDataBase.GetItemLists().Count; i++)
		{
			_skills.Add(skillDataBase.GetItemLists()[i]);
			//�@�m�F�̈׃f�[�^�o��
			//Debug.Log(skillDataBase.GetItemLists()[i].GetSkillID() + ": " + skillDataBase.GetItemLists()[i]);
			Debug.Log(GetItem(i));
		}


		//for (int i = 0; i < skillDataBase.GetItemLists().Count; i++)
		//      {
		//          //�@�A�C�e������K���ɐݒ�
		//          numOfItem.Add(skillDataBase.GetItemLists()[i], i);
		//          //�@�m�F�̈׃f�[�^�o��
		//          Debug.Log(skillDataBase.GetItemLists()[i].GetItemName() + ": " + skillDataBase.GetItemLists()[i]);
		//      }
		//Debug.Log(GetItem("a"));
		//Debug.Log(numOfItem[GetItem("b")]);

		
		//Debug.Log(_skills[GetItem(2)]);

	}

	public Skill GetItem(int searchId)
	{
		return skillDataBase.GetItemLists().Find(skillId => skillId.GetSkillID() == searchId);
	}

	public void AddSkill(int id)
	{
		_skills.Add(GetItem(id));
		//_skill.Add((Skill)skillId);
		//SkillManager.Instance.AddSkill(id);
	}

	//�@���O�ŃA�C�e�����擾
	//public Skill GetItem(string searchName)
	//{
	//    return skillDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
	//}

}