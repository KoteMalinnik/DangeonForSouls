using UnityEngine;
using UnityEngine.UI;

//!!! Рефакторить
public class RuntimeGUI : MonoBehaviour
{
	[SerializeField]
	/// <summary>
	/// Значение текущего счета
	/// </summary>
	Text currentScoreValue = null;

	[SerializeField]
	/// <summary>
	/// Количество собранных душ
	/// </summary>
	Text collectedSoulsValue = null;

    void Awake()
	{
		//Обновление начальных значений при запуске сцены
		updateCurrentScoreValue(0);
		updateCollectedSoulsValue(ValuesController.colectedSoulsValue);
	}

	/// <summary>
	/// Обновляет отображаемое количество собранных душ
	/// </summary>
	public void updateCollectedSoulsValue(int newCollectedSoulsValue)
	{
		collectedSoulsValue.text = newCollectedSoulsValue.ToString();
	}

	/// <summary>
	/// Обновляет отображаемое количество текущих очков
	/// </summary>
	public void updateCurrentScoreValue(int newCurrentScoreValue)
	{
		currentScoreValue.text = $"{newCurrentScoreValue} m";
	}
}
