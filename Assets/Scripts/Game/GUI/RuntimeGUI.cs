using UnityEngine;
using UnityEngine.UI;

//!!! Рефакторить
public class RuntimeGUI : MonoBehaviour
{
	[SerializeField]
	/// <summary>
	/// Значение текущего счета
	/// </summary>
	Text _scoreValue = null;
	static Text scoreValue = null;

	[SerializeField]
	/// <summary>
	/// Количество собранных душ
	/// </summary>
	Text _collectedSoulsValue = null;
	static Text collectedSoulsValue = null;

    void Awake()
	{
		scoreValue = _scoreValue;
		collectedSoulsValue = _collectedSoulsValue;

		//Обновление начальных значений при запуске сцены
		updateCurrentScoreValue(0);
		updateCollectedSoulsValue(ValuesController.colectedSoulsValue);
	}

	/// <summary>
	/// Обновляет отображаемое количество собранных душ
	/// </summary>
	public static void updateCollectedSoulsValue(int newCollectedSoulsValue)
	{
		if(collectedSoulsValue != null) collectedSoulsValue.text = newCollectedSoulsValue.ToString();
	}

	/// <summary>
	/// Обновляет отображаемое количество текущих очков
	/// </summary>
	public static void updateCurrentScoreValue(int newCurrentScoreValue)
	{
		if (scoreValue != null) scoreValue.text = $"{newCurrentScoreValue} m";
	}

	void OnDestroy()
	{
		collectedSoulsValue = null;
		scoreValue = null;
	}
}
