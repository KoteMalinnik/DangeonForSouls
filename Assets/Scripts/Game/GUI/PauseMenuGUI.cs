using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//!!! Рефакторить
public class PauseMenuGUI : baseGUI
{
	//void Awake()
	//{
	//	//Отключение панели паузы
	//	pauseGUIpanel.SetActive(false);
	//	//Включение взаимодействия кнопки паузы
	//	pauseButton.interactable = true;

	//	//выставление начального текста на канвасе
	//	runtimeCurrentScoreText.text = "0 m";
	//	runtimeSoulsCounterText.text = gm.colectedSouls.ToString();

	//	//Ставим на паузу, если нужно обучение. Обучение будет показываться один раз в начале игры.
	//	//Логично предположить, что счет будет нулевым, если не играли до этого
	//	if (gm.bestScore < 1) StartCoroutine(tutorial());
	//}


	//[SerializeField]
	///// <summary>
	///// Панель паузы
	///// </summary>
	//GameObject pauseGUIpanel = null;

	[SerializeField]
	/// <summary>
	/// Кнопка паузы
	/// </summary>
	Button pauseButton = null;

	//Button gameOverBoostButton; // бонус-продолжение за души
	//Button gameOverAdBoostButton; //бонус-продолжение за просмотр рекламы


	//Функция для кнопки паузы
	//public void pauseFunc()
	//{
	//	pauseStatement = true; // выставляем паузу
	//	pauseButton.interactable = false; //отключаем взаимодействие кнопки паузы

	//	pausePanel.SetActive(true); //показываем панель паузы
	//	pausePanel.GetComponent<Animator>().Play("simplePanelAnimation"); //анимируем панель паузы
	//																	  //выставление текста бонусов
	//	gameOverBoostButton.GetComponentInChildren<Text>().text = $"Continue\n{gm.gameOverBoostCost} souls";
	//	gameOverAdBoostButton.GetComponentInChildren<Text>().text = "Continue (after watching ads)";

	//	//если текущий счет стал лучше предыдущего, то перезаписываем лучший счет
	//	if (gm.pc.score > gm.bestScore) gm.bestScore = (int)gm.pc.score;
	//	gm.saveInt();

	//	//выставление чекмарка звука
	//	if (gm.sound) soundToggle.isOn = true;
	//	else soundToggle.isOn = false;

	//	//показываем лучший счет
	//	bestScoreText.text = gm.bestScore + " m";

	//	//отключаем взаимодействие кнопок бонусов
	//	gameOverBoostButton.interactable = false;
	//	gameOverAdBoostButton.interactable = false;

	//	//если игрок проиграл
	//	if (gm.pc.gameOver)
	//	{
	//		//бонус-продолжение за души будет включен, если есть нужное количество душ
	//		gameOverBoostButton.interactable = gm.gameOverBoostCost <= gm.colectedSouls;
	//		//бонус-продолжение за просмотр рекламы будет включен, если реклама готова
	//		//gameOverAdBoostButton.interactable = Advertisement.IsReady("rewardedVideo");

	//		//изменение текста кнопки продолжить-рестар
	//		continueOrRestartButton.GetComponentInChildren<Text>().text = "Restart";
	//	}
	//}

	////для кнопки главного меню
	//public void mainMenuFunc()
	//{
	//	Debug.Log("Loading scene - Main Menu");
	//	SceneManager.LoadSceneAsync("MainMenu");
	//}

	// //для кнопки продолжить-рестарт
	//public void continueOrRestartFunc()
	//{
	//	//Text кнопки "Restart". если игрок проиграл, то перезагрузка сцены
	//	if(gm.pc.gameOver)
	//	{
	//		Debug.Log("Reloading current scene - Game");
	//		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
	//	}
	//	//Text кнопки "Continue". Снятие игры с паузы
	//	else
	//	{
	//		//иначе 
	//		pauseButton.interactable = true;
	//		pauseGUIpanel.SetActive(false);
	//		pauseStatement = false;
	//	}
	//}

	////для кнопки бонуса-продолжения за души
	//public void gameOverBoostFunc()
	//{
	//	//вычитаем стоимость продолжения от накопленных душ
	//	gm.colectedSouls -= gm.gameOverBoostCost;
	//	updateSoulCounter(gm.colectedSouls); //обновляем счетчик

	//	gm.gameOverBoostCost += 100; //добавляем к стоимости бонуса-продолжения 100

	//	gm.pc.StartCoroutine(gm.pc.gameOverBoost()); //запускаем возрождение
	//	gameOverBoostButton.interactable = false; //отключаем взаимодействие кнопки бонуса-продолжения за души
	//}

	////для кнопки бонуса-продолжения за просмотр рекламы
	//bool AdsWasWatched { get; set; } = false; //true, если кнопка была нажата, т.е. запущена реклама
	//public void gameOverAdBoostFunc()
	//{
	//	//если реклама не была просмотрена
	//	if(!AdsWasWatched)
	//	{
	//		Debug.Log("Ads Wasn't Watched");
	//		//Advertisement.Show("rewardedVideo"); //включаем рекламу
	//		AdsWasWatched = true; //выставляем переменную
	//		gameOverAdBoostButton.GetComponentInChildren<Text>().text = "Continue"; //изменяем текст кнопки
	//	}
	//	else
	//	{
	//		//если реклама была просмотренна
	//		Debug.Log("Ads Was Watched");
	//		AdsWasWatched = false; //выставляем переменную
	//		gm.pc.StartCoroutine(gm.pc.gameOverBoost()); //запускаем возрождение
	//	}
	//}
}