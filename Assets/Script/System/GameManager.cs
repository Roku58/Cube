using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager :MonoBehaviour
{
	static private GameManager _instance = new GameManager();
	static public GameManager Instance => _instance;
	private GameManager() { }

	[SerializeField] PlayerState player;
	[SerializeField] Text timerText;
	[SerializeField] Text _deathText;
	[SerializeField] GameObject pauseUI;
	[SerializeField] GameObject levelUpUI;
	[SerializeField] GameObject gameOverUI;

	bool _levelEvent = false;
	bool _isDeath = false;
	float _deathTime = 0;

	int _level = 0;
	static public int Level => _instance._level;
	int _stackLevelup = 0;
	List<int> _passive = new List<int>();

	PlayerState _player;
	SkillSelect _sklSelect = null;

	private float second;
	private int minute;
	private int hour;

	private void Start()
    {
		second = 0;
	}

    void Update()
	{
		_isDeath = player.IsDeath;
		Pause();
		Timer();
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



	public void Pause()
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

	public void OnClickStartButton(string st)
	{
        //SceneManager.LoadScene();

    }

	public void OnClick(string st)
	{
		//SceneManager.LoadScene(st);
	}
}