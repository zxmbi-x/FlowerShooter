using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public TextMeshProUGUI scoreText;
	public Button restartButton;
	public Button mainMenu;

	public static GameManager instance;

	// one instance of game manager
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}

		else
		{
			Destroy(gameObject);
		}
	}

	public void AddScore()
	{
		float score = float.Parse(scoreText.text);
		score += 10;
		scoreText.text = score.ToString();
	}

	public void LoseGame()
	{
		restartButton.gameObject.SetActive(true);
		mainMenu.gameObject.SetActive(true);
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

}
