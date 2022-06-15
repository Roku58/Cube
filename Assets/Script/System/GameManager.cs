using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class GameManager :MonoBehaviour
{
	static private GameManager _instance = new GameManager();
	static public GameManager Instance => _instance;

	private GameManager() { }

    [SerializeField, Tooltip("現在レベル"), Min(0)] int _level = 0;
	static public int Level => _instance._level;
	[SerializeField, Tooltip("現在経験値"), Min(0)] int _exp = 0;
    public int Exp => _exp;
    [SerializeField, Tooltip("必要経験値"), Min(0)] int _expPool = 100;
    public int ExpPool => _expPool;

    [SerializeField] PlayerState player;
	[SerializeField] Text timerText;
	[SerializeField] Text _deathText;
	[SerializeField] GameObject pauseUI;
	[SerializeField] GameObject levelUpUI;
	[SerializeField] GameObject gameOverUI;
	[SerializeField] SkillSelect _skllSelect = null;

	//bool _levelEvent = false;
	bool _isDeath = false;
	//float _deathTime = 0;


	int _stackLevelup = 0;
	List<int> _passive = new List<int>();

	PlayerState _player;
	SkillSelect _sklSelect = null;
	List<IPause> _pauseObjects = new List<IPause>();

	private float second;
	private int minute;
	private int hour;


	private void Start()
    {
		_sklSelect = GameObject.FindObjectOfType<SkillSelect>();
		second = 0;
    }

    void Update()
	{
		_isDeath = player.IsDeath;
		Pause();
		Timer();
		//LevelManagar();
		if (_isDeath)
        {
			PlayerDeath();
		}

	}

	public void LevelUpSelect(SkillSelectTable table)
	{
		switch (table.Type)
		{
			case SelectType.Skill:
				_player.AddSkill(table.TargetId);
				break;

			case SelectType.Passive:
				_passive.Add(table.TargetId);
				break;

			case SelectType.Execute:
				//TODO:
				break;
		}

		if (_stackLevelup > 0)
		{
			_sklSelect.SelectStartDelay();
			_stackLevelup--;
		}
		else
		{
			Time.timeScale = 1;
		}
	}

	//void LevelManagar()//レベル管理
	//{
	//	if (_exp >= _expPool)
	//	{
	//		LevelUp();
	//	}
	//}

	public void AddExp(int addexp)
	{
		_exp += addexp;
		if(_exp >= _expPool)
        {
			LevelUp();
		}
	}

	void LevelUp()//レベルが上がった際の処理
	{

		//Time.timeScale = 0;
		_level++;
		_exp = 0;
        //_isLevelUp = true;
        //_maxLife += _level * 5;
        _expPool += _level * 10;
		Debug.Log("レベルアップ");
		_skllSelect.SelectStart();
		
		Debug.Log("プレイヤーのレベルが" + _level + " になった！");
		Debug.Log("次のレベルまで" + _expPool + " 必要");
	}

	void Timer()
    {
		second += Time.deltaTime;

		if (minute > 60)
		{
			hour++;
			minute = 0;
		}
		if (second > 60f)
		{
			minute += 1;
			second = 0;
		}

		timerText.text = hour.ToString() + ":" + minute.ToString("00") + ":" + second.ToString("f2");
	}



	public void PauseUi()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			pauseUI.SetActive(!pauseUI.activeSelf);//　ポーズUIのアクティブ、非アクティブを切り替え
		}

		if (pauseUI.activeSelf || levelUpUI.activeSelf || gameOverUI.activeSelf)//　ポーズUIが表示されてる時は停止
		{
			Time.timeScale = 0f;
		}
		else//　ポーズUIが表示されてなければ通常通り進行
		{
			Time.timeScale = 1f;
		}

		//_isPause = !_isPause;
		//_pausePanal.SetActive(_isPause);

	}

	public void PlayerDeath()
	{
		gameOverUI.SetActive(true);
		Rezalt();
	}

	public void Rezalt()
    {
		_deathText.text = hour.ToString() + " : " + minute.ToString("00") + " : " + second.ToString("f2");


	}

	/// <summary>ポーズをさせるオブジェクトを取得しリストに追加する </summary>
	/// <param name="pause">ポーズさせるオブジェクト</param>
	public void AddPauseObject(IPause pause)
	{
		_pauseObjects.Add(pause);
	}

	/// <summary>ポーズ</summary>
	public void Pause()
	{
		
		//Array.ForEach(_pauseObjects.ToArray(), p => p.Pause());
	}

	/// <summary>ポーズ解除 </summary>
	public void Restart()
	{
		//Array.ForEach(_pauseObjects.ToArray(), p => p.Restart());
	}

	public void OnClick(string st)
	{
        SceneManager.LoadScene(st);
    }
}