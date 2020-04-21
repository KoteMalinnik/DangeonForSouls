using UnityEngine;

/// <summary>
/// Содержит игровые данные
/// </summary>
public static class ValuesController
{
	/// <summary>
	/// Текущий счет
	/// </summary>
	public static int scoreValue { get; private set; } = 0;

	/// <summary>
	/// Очки лучшего счета
	/// </summary>
	public static int bestScoreValue { get; private set; } = 0;

	/// <summary>
	/// Количество собранных душ
	/// </summary>
	public static int colectedSoulsValue { get; private set; } = 0;

	/// <summary>
	/// Цена бонуса восстановления
	/// </summary>
	public static int recoveryCostValue { get; private set; } = 0; //100

	/// <summary>
	/// Установка очков лучшего счета
	/// </summary>
	public static void setBestScoreValue(int newBestScoreValue)
	{
		bestScoreValue = newBestScoreValue;
		Debug.Log($"Установка значения bestScoreValue: {bestScoreValue}");
	}

	public static void incrementBestScoreValue()
	{
		var incrementedValue = bestScoreValue + 1;
		setBestScoreValue(incrementedValue);
	}

	/// <summary>
	/// Установка количества собранных душ
	/// </summary>
	public static void setСolectedSoulsValue(int newСolectedSoulsValue)
	{
		colectedSoulsValue = newСolectedSoulsValue;
		RuntimeGUI.updateCollectedSoulsValue(colectedSoulsValue);

		Debug.Log($"Установка значения colectedSoulsValue: {colectedSoulsValue}");
	}

	public static void incrementСolectedSoulsValue()
	{
		var incrementedValue = colectedSoulsValue + 1;
		setСolectedSoulsValue(incrementedValue);
	}


	/// <summary>
	/// Установка цены бонуса восстановления
	/// </summary>
	public static void setRecoveryCostValue(int newRecoveryCostValue)
	{
		recoveryCostValue = newRecoveryCostValue;
		Debug.Log($"Установка значения recoveryCostValue: {recoveryCostValue}");
	}


	/// <summary>
	/// Установить текущий счет. Если текущий счет превышает лучший, то текущий счет становится лучшим
	/// </summary>
	public static void setScoreValue(int newScoreValue)
	{
		if (newScoreValue < 0)
		{
			Debug.Log("<color=red>Счет меньше нуля</color>");
			return;
		}

		scoreValue = newScoreValue;

		if (scoreValue > bestScoreValue) bestScoreValue = scoreValue;

		RuntimeGUI.updateCurrentScoreValue(scoreValue);
	}

	public static void incrementScoreValue()
	{
		var incrementedValue = scoreValue + 1;
		setScoreValue(incrementedValue);
	}
}