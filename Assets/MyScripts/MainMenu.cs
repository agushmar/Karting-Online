using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject gameMenu;
	public GameObject optionsMenu;
	public GameObject creditsMenu;

	private void Awake()
	{
		if (PlayerPrefs.GetInt("isStarted") == 1)
			Destroy(transform.parent.gameObject);
	}
	public void PlayGame()
	{
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		optionsMenu.SetActive(false);
		gameMenu.SetActive(true);
		creditsMenu.SetActive(false);
		transform.parent.gameObject.SetActive(false);
		PlayerPrefs.SetInt("isStarted", 1);
	}

	public void Options()
	{
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		optionsMenu.SetActive(true);
		//gameMenu.SetActive(false);
		creditsMenu.SetActive(false);
		transform.parent.gameObject.SetActive(false);

	}
	public void showmainmenu()
	{
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		optionsMenu.SetActive(false);
		//gameMenu.SetActive(false);
		creditsMenu.SetActive(false);
		transform.parent.gameObject.SetActive(true);

	}
	public void showcreditsmenu()
	{
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		optionsMenu.SetActive(false);
		//gameMenu.SetActive(false);
		creditsMenu.SetActive(true);
		transform.parent.gameObject.SetActive(false);

	}

	public void QuitGame()
	{
		Debug.Log("has quit game");
		Application.Quit();
	}
}
