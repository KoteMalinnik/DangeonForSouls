using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGUI : MonoBehaviour
{
	void Start()
	{
		presetGUI();
	}

	void presetGUI()
	{
		bestScoreValue.text = $"{GameManager.bestScoreValue} m";
		soundStatement.isOn = AudioManager.audioStatement;
	}

	[SerializeField]
	/// <summary>
	/// Text, отображающий лучший счет
	/// </summary>
	Text bestScoreValue;

	[SerializeField]
	/// <summary>
	/// Переключатель звука
	/// </summary>
	Toggle soundStatement;

	public void __SwitchSound()
	{
		Debug.Log("Переключение звука");
		var newAudioStatement = soundStatement.isOn;
		AudioManager.setAudioStatement(newAudioStatement);
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