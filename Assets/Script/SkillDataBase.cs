using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillDataBase", menuName = "CreateSkillDataBase")]
public class SkillDataBase : ScriptableObject
{

	[SerializeField]�@public List<Skill> skillLists = new List<Skill>();

	//�@�A�C�e�����X�g��Ԃ�
	public List<Skill> GetItemLists()
	{
		return skillLists;
	}
}
