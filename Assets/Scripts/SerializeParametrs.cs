﻿using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Сериализация данных
/// </summary>
public class SerializeParametrs : MonoBehaviour
{
	void Awake()
	{
		loadAllParametrs();

		SceneManager.LoadScene("MainMenu");
	}

	//Ключи для сериализуемых параметров
	const string key_bestScoreValue = "bestScoreValue";
	const string key_collectedSoulsValue = "collectedSoulsValue";
	const string key_recoveryCostValue = "recoveryCostValue";
	const string key_audioStatement = "audioStatement";

	/// <summary>
	/// Загрузка всех параметров
	/// </summary>
	void loadAllParametrs()
	{
		Debug.Log("Загрузка параметров из PlayerPrefs");

		var newBestScoreValue = loadParametr(key_bestScoreValue, 0);
		GameManager.setBestScoreValue(newBestScoreValue);

		var newCollectedSoulsValue = loadParametr(key_collectedSoulsValue, 0);
		GameManager.setСolectedSoulsValue(newCollectedSoulsValue);

		var newRecoveryCostValue = loadParametr(key_recoveryCostValue, 100);
		GameManager.setRecoveryCostValue(newRecoveryCostValue);

		var newAudioStatement = loadParametr(key_audioStatement, true);
		AudioManager.setAudioStatement(newAudioStatement);
	}

	/// <summary>
	/// Загрузка параметра типа int с ключом key. Если такого нет, ему будет присвоено значение defaultValue
	/// </summary>
	/// <param name="key">Ключ.</param>
	/// <param name="defaultValue">Значение по умолчанию.</param>
	int loadParametr(string key, int defaultValue)
	{
		var parametrValue = PlayerPrefs.GetInt(key, defaultValue);

		Debug.Log($"Параметр {key} загружен. Значение: {parametrValue}");

		return parametrValue;
	}

	/// <summary>
	/// Загрузка параметра типа bool с ключом key. Если такого нет, ему будет присвоено значение defaultValue
	/// </summary>
	/// <param name="key">Ключ.</param>
	/// <param name="defaultValue">Значение по умолчанию.</param>
	bool loadParametr(string key, bool defaultValue)
	{
		var parametrValue = PlayerPrefs.GetInt(key, defaultValue ? 1 : 0);
		bool statementValue = parametrValue == 1;

		Debug.Log($"Параметр {key} загружен. Значение: {statementValue}");

		return statementValue;
	}

	/// <summary>
	/// Сохранение параметра parametrValue типа int с ключом key
	/// </summary>
	public static void saveParametr(string key, int parametrValue)
	{
		PlayerPrefs.SetInt(key, parametrValue);

		Debug.Log($"Параметр {key} сохранен. Значение: {parametrValue}");
	}

	/// <summary>
	/// Сохранение параметра statementValue типа bool с ключом key
	/// </summary>
	public static void saveParametr(string key, bool statementValue)
	{
		int parametrValue = statementValue ? 1 : 0;
		PlayerPrefs.SetInt(key, parametrValue);

		Debug.Log($"Параметр {key} сохранен. Значение: {statementValue}");
	}

	public static void saveAllParametrs()
	{
		Debug.Log("Сохранение значений");

		saveParametr(key_audioStatement, AudioManager.audioStatement);
		saveParametr(key_bestScoreValue, GameManager.bestScoreValue);
		saveParametr(key_collectedSoulsValue, GameManager.colectedSoulsValue);
		saveParametr(key_recoveryCostValue, GameManager.recoveryCostValue);
	}

	void OnApplicationQuit()
	{
		saveAllParametrs();
	}
}
