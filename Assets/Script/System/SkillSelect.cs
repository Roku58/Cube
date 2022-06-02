using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelect : MonoBehaviour
{

    [SerializeField] PlayerState player;
    [SerializeField] GameObject levelUp;
    [SerializeField] List<GameObject> _selectList;//�I�u�W�F�N�g
    //List<SkillSelectTable> _selectTable = new List<SkillSelectTable>();//�X�L�����e
    List<UnityEngine.UI.Text> _selectText = new List<UnityEngine.UI.Text>();//�X�L���e�L�X�g

    bool _isLevelUp=false;
    void Start()
    {
        //�ݒ肵�����X�g�̐�������
        for (int i = 0; i < _selectList.Count; ++i)
        {
            //�ŏ��͉�������Ȃ�
            //_selectTable.Add(null);

            //�q�v�f�̃e�L�X�g���擾���A���X�g�ɒǉ�
            _selectText.Add(_selectList[i].GetComponentInChildren<UnityEngine.UI.Text>());
            {
                //���݂̃Z���N�g
                var index = i;
                //����Ɏq�v�f�i���j�̃{�^�����擾�A���X�g�ɒǉ�
                var btn = _selectList[i].GetComponentInChildren<UnityEngine.UI.Button>();
                //���Ŏ擾�����{�^����AddListener()�ŃX�N���v�g����C�x���g�ǉ�
                btn.onClick.AddListener(() =>
                {

                    //if (_canvas.alpha == 0) return;
                    //�ǉ�����֐�
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
        //���X�g�錾
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
