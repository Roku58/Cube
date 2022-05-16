using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
	//�@���Ԃ�x�����Ă��邩�ǂ���
	private bool isSlowDown = false;
	[SerializeField] private GameObject pauseUI;

	void Update()
	{
		Pause();
	}

	void Pause()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{

			
			pauseUI.SetActive(!pauseUI.activeSelf);//�@�|�[�YUI�̃A�N�e�B�u�A��A�N�e�B�u��؂�ւ�

			
			if (pauseUI.activeSelf)//�@�|�[�YUI���\������Ă鎞�͒�~
			{
				Time.timeScale = 0f;
			}
			else//�@�|�[�YUI���\������ĂȂ���Βʏ�ʂ�i�s
			{
				Time.timeScale = 1f;
			}
		}

	}

	public void OnClickStartButton()
	{
		SceneManager.LoadScene("GAME1");
	}

	public void OnClick()
	{
		SceneManager.LoadScene("Titole");
	}
}
