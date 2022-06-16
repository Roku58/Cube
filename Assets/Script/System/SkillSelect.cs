using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillSelect : MonoBehaviour
{
    //public static SkillSelect instance;

    [SerializeField] List<GameObject> _selectList;
    [SerializeField] GameObject levelUpUI;
    PlayerState _player;
    List<SkillSelectTable> _selectTable = new List<SkillSelectTable>();
    List<UnityEngine.UI.Text> _selectText = new List<UnityEngine.UI.Text>();
    CanvasGroup _canvas;

    public bool _isSelect { get; private set; } = false;

    bool _startEvent = false;

    private void Awake()
    {
        _canvas = GetComponent<CanvasGroup>();
        _player = GetComponent<PlayerState>();
    }

    void Start()
    {
        for (int i = 0; i < _selectList.Count; ++i)
        {
            _selectTable.Add(null);
            _selectText.Add(_selectList[i].GetComponentInChildren<UnityEngine.UI.Text>());
            {
                var index = i;
                var btn = _selectList[i].GetComponentInChildren<UnityEngine.UI.Button>();
                btn.onClick.AddListener(() =>
                {
                    if (_canvas.alpha == 0) return;
                    OnClick(index);
                });
            }
        }
    }

    private void Update()
    {
        if (_startEvent)
        {
            SelectStart();
            _startEvent = false;
        }
    }

    public void SelectStartDelay()
    {
        _startEvent = true;
    }

    public void SelectStart()
    {
        Time.timeScale = 0;

        _isSelect = true;
        _canvas.alpha = 1;
        Debug.Log("SelectStart");

        //_player = GetComponent<PlayerState>();
        //var list = GameData.SkillSelectTable.Where(s => _player.Level >= s.Level);

        List<SkillSelectTable> table = new List<SkillSelectTable>();
        //var list = GameData.SkillSelectTable.Where(s => GameManager.Level >= s.Level);
        //GameManager _players  = GetComponent<GameManager>();

        var list = GameData.SkillSelectTable.Where(s => GameManager.Level >= s.Level);


        int totalProb = list.Sum(s => s.Probability);
        int rand = Random.Range(0, totalProb);

        for (int i = 0; i < _selectList.Count; ++i)
        {
            _selectTable[i] = null;
            _selectText[i].text = "";
        }

        for (int i = 0; i < _selectList.Count; ++i)
        {
            foreach (var s in list)
            {
                if (rand < s.Probability)
                {
                    _selectTable[i] = s;
                    _selectText[i].text = s.Name;
                    list = list.Where(ls => !(ls.Type == s.Type && ls.TargetId == s.TargetId));
                    break;
                }
                rand -= s.Probability;
            }
        }
    }

    public void OnClick(int index)
    {
        Debug.Log("ƒXƒLƒ‹‘I‘ð");
        GameManager.Instance.LevelUpSelect(_selectTable[index]);
        levelUpUI.SetActive(false);
        _isSelect = false;
        //GameManager.Instance.Pause();

    }
}
