using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
	//　時間を遅くしているかどうか
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

			
			pauseUI.SetActive(!pauseUI.activeSelf);//　ポーズUIのアクティブ、非アクティブを切り替え

			
			if (pauseUI.activeSelf)//　ポーズUIが表示されてる時は停止
			{
				Time.timeScale = 0f;
			}
			else//　ポーズUIが表示されてなければ通常通り進行
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
