using UnityEngine;
using UnityEngine.UI;

public abstract class baseGUI : MonoBehaviour
{
   protected void presetGUI()
	{
		bestScoreValue.text = $"{GameManager.bestScoreValue} m";
		soundStatement.isOn = AudioManager.audioStatement;
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

	public void __SwitchSound()
	{
		Debug.Log("Переключение звука");
		var newAudioStatement = soundStatement.isOn;
		AudioManager.setAudioStatement(newAudioStatement);
	}
}
