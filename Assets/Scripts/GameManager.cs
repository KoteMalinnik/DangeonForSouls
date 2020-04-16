using UnityEngine;

/// <summary>
/// Содержит игровые данные
/// </summary>
public static class GameManager
{
	/// <summary>
	/// Очки лучшего счета
	/// </summary>
	public static int bestScoreValue { get; private set; }

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
	public static int colectedSoulsValue { get; private set; }

	/// <summary>
	/// Установка количества собранных душ
	/// </summary>
	public static void setСolectedSoulsValue(int newСolectedSoulsValue)
	{
		colectedSoulsValue = newСolectedSoulsValue;
		Debug.Log($"Установка значения colectedSoulsValue: {colectedSoulsValue}");
	}

	/// <summary>
	/// Цена бонуса восстановления
	/// </summary>
	public static int recoveryCostValue { get; private set; }

	/// <summary>
	/// Установка цены бонуса восстановления
	/// </summary>
	public static void setRecoveryCostValue(int newRecoveryCostValue)
	{
		recoveryCostValue = newRecoveryCostValue;
		Debug.Log($"Установка значения bestScoreValue: {recoveryCostValue}");
	}
}