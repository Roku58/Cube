using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
	[SerializeField]  GameObject pauseUI;
	[SerializeField] GameObject levelUpUI;
	[SerializeField] GameObject gameOverUI;

	bool _levelEvent = false;
	bool _isDeath = false;
	void Update()
	{
		Pause();
	}

	void Pause()
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

	}

	public void PlayerDeath()
	{
		gameOverUI.SetActive(!gameOverUI.activeSelf);
		Rezalt();
	}

	public void Rezalt()
    {

    }

	public void OnClickStartButton()
	{
		SceneManager.LoadScene("GAME");
	}

	public void OnClick()
	{
		SceneManager.LoadScene("Titole");
	}
}
