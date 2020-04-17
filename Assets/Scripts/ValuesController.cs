using UnityEngine;

/// <summary>
/// Содержит игровые данные
/// </summary>
public static class ValuesController
{
	/// <summary>
	/// Очки лучшего счета
	/// </summary>
	public static int bestScoreValue { get; private set; } = 0;

	/// <summary>
	/// Установка очков лучшего счета
	/// </summary>
	public static void setBestScoreValue(int newBestScoreValue)
	{
		bestScoreValue = newBestScoreValue;
		Debug.Log($"Установка значения bestScoreValue: {bestScoreValue}");
	}

	/// <summary>
	/// Количество собранных душ
	/// </summary>
	public static int colectedSoulsValue { get; private set; } = 0;

	/// <summary>
	/// Установка количества собранных душ
	/// </summary>
	public static void setСolectedSoulsValue(int newСolectedSoulsValue)
	{
		colectedSoulsValue = newСolectedSoulsValue;
		RuntimeGUI.updateCollectedSoulsValue(colectedSoulsValue);

		Debug.Log($"Установка значения colectedSoulsValue: {colectedSoulsValue}");
	}

	/// <summary>
	/// Цена бонуса восстановления
	/// </summary>
	public static int recoveryCostValue { get; private set; } = 100;

	/// <summary>
	/// Установка цены бонуса восстановления
	/// </summary>
	public static void setRecoveryCostValue(int newRecoveryCostValue)
	{
		recoveryCostValue = newRecoveryCostValue;
		Debug.Log($"Установка значения bestScoreValue: {recoveryCostValue}");
	}

	/// <summary>
	/// Текущий счет
	/// </summary>
	public static int scoreValue { get; private set; } = 0;

	/// <summary>
	/// Установить текущий счет. Если текущий счет превышает лучший, то текущий счет становится лучшим
	/// </summary>
	public static void setScoreValue(int newScoreValue)
	{
		if (newScoreValue < 0)
		{
			Debug.LogError("<color=red>Счет меньше нуля</color>");
			return;
		}

		scoreValue = newScoreValue;

		if (scoreValue > bestScoreValue) bestScoreValue = scoreValue;

		RuntimeGUI.updateCurrentScoreValue(scoreValue);
	}

	/// <summary>
	/// True, если количество собранных душ превышает цену восстановления
	/// </summary>
	public static bool canRecovery()
	{
		return colectedSoulsValue >= recoveryCostValue;
	}

	/// <summary>
	/// Применить восстановление за души
	/// </summary>
	public static void applyRecovery()
	{
		Debug.Log("Применение восстановления за души");

		if (canRecovery())
		{
			//вычитаем стоимость продолжения от накопленных душ
			var restOfCollectedSouls = colectedSoulsValue - recoveryCostValue;
			setСolectedSoulsValue(restOfCollectedSouls);

			recoveryCostValue += 100;

			return;
		}

		Debug.LogError("<color=red>Ошибка! Кнопка не должна была быть активна</color>");
	}
}