using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGUI : baseGUI
{
	void Start()
	{
		presetGUI();
	}

	public void __Play()
	{
		Debug.Log("Загрузка сцены Game");
		SceneManager.LoadSceneAsync("Game");
	}

	public void __Quit()
	{
		Debug.Log("Выход из приложения");
		Application.Quit();
	}
}