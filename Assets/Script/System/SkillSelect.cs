using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelect : MonoBehaviour
{

    [SerializeField] PlayerState player;
    [SerializeField] GameObject levelUp;
    [SerializeField] List<GameObject> _selectList;//オブジェクト
    //List<SkillSelectTable> _selectTable = new List<SkillSelectTable>();//スキル内容
    List<UnityEngine.UI.Text> _selectText = new List<UnityEngine.UI.Text>();//スキルテキスト

    bool _isLevelUp=false;
    void Start()
    {
        //設定したリストの数だけ回す
        for (int i = 0; i < _selectList.Count; ++i)
        {
            //最初は何も入れない
            //_selectTable.Add(null);

            //子要素のテキストを取得し、リストに追加
            _selectText.Add(_selectList[i].GetComponentInChildren<UnityEngine.UI.Text>());
            {
                //現在のセレクト
                var index = i;
                //さらに子要素（孫）のボタンを取得、リストに追加
                var btn = _selectList[i].GetComponentInChildren<UnityEngine.UI.Button>();
                //↑で取得したボタンにAddListener()でスクリプトからイベント追加
                btn.onClick.AddListener(() =>
                {

                    //if (_canvas.alpha == 0) return;
                    //追加する関数
                    OnClick(index);
                });
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       _isLevelUp = player.IsLevelUp;
        if(_isLevelUp)
        {
            SelectStart();
        }
    }

    public void SelectStart()
    {
        levelUp.SetActive(true);
        //リスト宣言
        //List<SkillSelectTable> table = new List<SkillSelectTable>();
        //
        //var list = GameData.SkillSelectTable.Where(s => GameManager.Level >= s.Level);
        //
        //int totalProb = list.Sum(s => s.Probability);
        //
        //int rand = Random.Range(0, totalProb);
        //
        for (int i = 0; i < _selectList.Count; ++i)
        {
            //_selectTable[i] = null;
            _selectText[i].text = "";
        }
        //
        for (int i = 0; i < _selectList.Count; ++i)
        {
            //foreach (var s in list)
            //{
            //    if (rand < s.Probability)
            //    {
            //        _selectTable[i] = s;
            //        _selectText[i].text = s.Name;
            //        list = list.Where(ls => !(ls.Type == s.Type && ls.TargetId == s.TargetId));
            //        break;
            //    }
            //    rand -= s.Probability;
            //}
        }
    }

    public void OnClick(int index)
    {
        //GameManager.Instance.LevelUpSelect(_selectTable[index]);
        //LevelUpSelect(_selectTable[index])
        levelUp.SetActive(false);
        _isLevelUp =false;
    }

    //public void LevelUpSelect(SkillSelectTable table)
    //{
    //    switch (table.Type)
    //    {
    //        case SelectType.Skill:
    //            _player.AddSkill(table.TargetId);
    //            break;

    //        case SelectType.Passive:
    //            _passive.Add(table.TargetId);
    //            break;

    //        case SelectType.Execute:
    //            //TODO:
    //            break;
    //    }
    //}
}
