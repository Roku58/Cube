using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

	//�@�A�C�e���f�[�^�x�[�X
	[SerializeField]
	private SkillDataBase skillDataBase;
	//�@�X�L�����x���Ǘ�
	private Dictionary<Skill, int> numOfItem = new Dictionary<Skill, int>();
	Skill skill;

	// Use this for initialization
	void Start()
	{
		//for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
		//{
		//	//�@�A�C�e������K���ɐݒ�
		//	numOfItem.Add(itemDataBase.GetItemLists()[i], i);
		//	//�@�m�F�̈׃f�[�^�o��
		//	Debug.Log(itemDataBase.GetItemLists()[i].GetItemName() + ": " + itemDataBase.GetItemLists()[i]);
		//}
		//Debug.Log(GetItem("a"));
		//Debug.Log(numOfItem[GetItem("b")]);



	}


	//�@���O�ŃA�C�e�����擾
	public Skill GetItem(string searchName)
	{
		return skillDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
	}

}