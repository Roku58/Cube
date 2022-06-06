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
	Skill skill;

	// Use this for initialization
	void Start()
	{
		//for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
		//{
		//	//　アイテム数を適当に設定
		//	numOfItem.Add(itemDataBase.GetItemLists()[i], i);
		//	//　確認の為データ出力
		//	Debug.Log(itemDataBase.GetItemLists()[i].GetItemName() + ": " + itemDataBase.GetItemLists()[i]);
		//}
		//Debug.Log(GetItem("a"));
		//Debug.Log(numOfItem[GetItem("b")]);



	}


	//　名前でアイテムを取得
	public Skill GetItem(string searchName)
	{
		return skillDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
	}

}