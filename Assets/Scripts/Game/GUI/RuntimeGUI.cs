using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class RuntimeGUI : MonoBehaviour
{
    void Awake()
	{
		//Отключение панели паузы
		pausePanel.SetActive(false);
		//Включение взаимодействия кнопки паузы
		pauseButton.interactable = true;

		//выставление начального текста на канвасе
		runtimeCurrentScoreText.text = "0 m";
		runtimeSoulsCounterText.text = gm.colectedSouls.ToString();

		//Ставим на паузу, если нужно обучение. Обучение будет показываться один раз в начале игры.
		//Логично предположить, что счет будет нулевым, если не играли до этого
		if (gm.bestScore < 1) StartCoroutine(tutorial());
	}

	[Header("GUI Text")]
	public Text runtimeCurrentScoreText; //текущий счет
	public Text runtimeSoulsCounterText; //количество собранных душ

	[Header("GUI Buttons")]
	public Button pauseButton; // пауза


	void Update()
	{
		//Если статус не "пауза" и не "gameOver", то выводим счет
		if (!pauseStatement && !gm.pc.gameOver) runtimeCurrentScoreText.text = (int)gm.pc.score + " m";
	}

	//обновление счетчика душ по запросу
	public void updateSoulCounter(int count)
	{
		runtimeSoulsCounterText.text = count.ToString();
	}


	//Функция для кнопки паузы
	public void pauseFunc()
	{
		pauseStatement = true; // выставляем паузу
		pauseButton.interactable = false; //отключаем взаимодействие кнопки паузы

		pausePanel.SetActive(true); //показываем панель паузы
		pausePanel.GetComponent<Animator>().Play("simplePanelAnimation"); //анимируем панель паузы
																		  //выставление текста бонусов
		gameOverBoostButton.GetComponentInChildren<Text>().text = $"Continue\n{gm.gameOverBoostCost} souls";
		gameOverAdBoostButton.GetComponentInChildren<Text>().text = "Continue (after watching ads)";

		//если текущий счет стал лучше предыдущего, то перезаписываем лучший счет
		if (gm.pc.score > gm.bestScore) gm.bestScore = (int)gm.pc.score;
		gm.saveInt();

		//выставление чекмарка звука
		if (gm.sound) soundToggle.isOn = true;
		else soundToggle.isOn = false;

		//показываем лучший счет
		bestScoreText.text = gm.bestScore + " m";

		//отключаем взаимодействие кнопок бонусов
		gameOverBoostButton.interactable = false;
		gameOverAdBoostButton.interactable = false;

		//если игрок проиграл
		if (gm.pc.gameOver)
		{
			//бонус-продолжение за души будет включен, если есть нужное количество душ
			gameOverBoostButton.interactable = gm.gameOverBoostCost <= gm.colectedSouls;
			//бонус-продолжение за просмотр рекламы будет включен, если реклама готова
			//gameOverAdBoostButton.interactable = Advertisement.IsReady("rewardedVideo");

			//изменение текста кнопки продолжить-рестар
			continueOrRestartButton.GetComponentInChildren<Text>().text = "Restart";
		}
	}
}
