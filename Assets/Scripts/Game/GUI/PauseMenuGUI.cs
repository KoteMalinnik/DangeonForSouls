using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Меню паузы
/// </summary>
public class PauseMenuGUI : baseGUI
{
	[SerializeField]
	/// <summary>
	/// Панель паузы
	/// </summary>
	GameObject pausePanel = null;

	[SerializeField]
	/// <summary>
	/// Кнопка паузы
	/// </summary>
	Button pauseButton = null;

	[SerializeField]
	/// <summary>
	/// Кнопка восстановления за определенное количество душ
	/// </summary>
	Button soulRecovery = null;

	/// <summary>
	/// Текст кнопки recoveryBoost
	/// </summary>
	Text soulRecoveryCost = null;

	[SerializeField]
	/// <summary>
	/// Label кнопки continueOrRestart
	/// </summary>
	Text continueOrRestart = null;
	const string _continue = "Continue";
	const string _restart = "Restart";

	/// <summary>
	/// Аниматор панели паузы
	/// </summary>
	Animator pausePanelAnimator = null;

	void Awake()
	{
		continueOrRestart.text = _continue;

		soulRecoveryCost = soulRecovery.GetComponentInChildren<Text>();
		pausePanelAnimator = pausePanel.GetComponent<Animator>();

		pausePanel.SetActive(false); //Скрыть панели паузы
		pauseButton.interactable = true; //Включение взаимодействия кнопки паузы
	}

	/// <summary>
	/// Пауза игрового процесса
	/// </summary>
	public void __Pause()
	{
		Statements.setPause(true);

		soulRecovery.interactable = false; //Отключение взаимодействия кнопки восстановления за души
		pauseButton.interactable = false; //Отключение взаимодействия кнопки паузы

		pausePanel.SetActive(true); //Показать панель паузы

		pausePanelAnimator.Play("simplePanelAnimation"); //Запуск анимации панели паузы

		soulRecoveryCost.text = $"Continue\n{ValuesController.recoveryCostValue} souls"; //Установка текста для кнопки восстановления

		presetGUI(); //Установка bestScoreValue.text и soundStatement.isOn

		if (Statements.gameOver)
		{
			//Восстановление за души активно, если есть нужное количество душ
			soulRecovery.interactable = Recovery.canRecovery();

			//Установка текста кнопки continueOrRestart
			continueOrRestart.text = _restart; 
		}
	}

	/// <summary>
	/// Переход в главное меню
	/// </summary>
	public void __MainMenu()
	{
		Debug.Log("Загрузка сцены MainMenu");
		SceneManager.LoadSceneAsync("MainMenu");
	}

	/// <summary>
	/// Продолжить
	/// </summary>
	public void __Continue()
	{
		if(!Statements.gameOver)
		{
			pauseButton.interactable = true;
			pausePanel.SetActive(false);
			Statements.setPause(false);
		}
	}

	/// <summary>
	/// Рестарт
	/// </summary>
	public void __Restart()
	{
		if (Statements.gameOver)
		{
			Debug.Log("Перезагрузка сцены");
			var sceneIndex = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(sceneIndex);
			return;
		}
	}

	/// <summary>
	/// Восстановление за души
	/// </summary>
	public void __SoulRecovery()
	{
		Recovery.applyRecovery();
		__Continue();
	}

	void OnDestroy()
	{
		ValuesController.setScoreValue(0); //Обнуление текущего счета при переходе между сценами
	}
}