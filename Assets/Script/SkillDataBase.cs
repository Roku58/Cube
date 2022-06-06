using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillDataBase", menuName = "CreateSkillDataBase")]
public class SkillDataBase : ScriptableObject
{

	[SerializeField]
	public List<Skill> skillLists = new List<Skill>();

	//　アイテムリストを返す
	public List<Skill> GetItemLists()
	{
		return skillLists;
	}
}
