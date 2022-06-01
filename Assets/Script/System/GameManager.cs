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

			
			pauseUI.SetActive(!pauseUI.activeSelf);//�@�|�[�YUI�̃A�N�e�B�u�A��A�N�e�B�u��؂�ւ�

		}

		if (pauseUI.activeSelf || levelUpUI.activeSelf || gameOverUI.activeSelf)//�@�|�[�YUI���\������Ă鎞�͒�~
		{
			Time.timeScale = 0f;
		}
		else//�@�|�[�YUI���\������ĂȂ���Βʏ�ʂ�i�s
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