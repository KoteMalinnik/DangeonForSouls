using UnityEngine;
using UnityEngine.UI;

public abstract class baseGUI : MonoBehaviour
{
	/// <summary>
	/// Предустановка bestScoreValue.text и soundStatement.isOn
	/// </summary>
	protected void presetGUI()
	{
		bestScoreValue.text = $"{ValuesController.bestScoreValue} m";
		soundStatement.isOn = AudioManager.allowAudio;
	}

	[SerializeField]
	/// <summary>
	/// Text, отображающий лучший счет
	/// </summary>
	Text bestScoreValue = null;

	[SerializeField]
	/// <summary>
	/// Переключатель звука
	/// </summary>
	Toggle soundStatement = null;

	/// <summary>
	/// Переключить звук
	/// </summary>
	public void __SwitchSound()
	{
		Debug.Log("Переключение звука");
		var newAudioStatement = soundStatement.isOn;
		AudioManager.setAudioStatement(newAudioStatement);
	}
}
