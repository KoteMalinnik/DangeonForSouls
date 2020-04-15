using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuGUI_Manager : MonoBehaviour
{
	GameManager gm;

    public static menuGUI_Manager instance { get; private set; }
	void Awake()
	{
		gm = GameManager.instance;

		if (instance == null) instance = this;
		else if (instance = this) Destroy(this);

		gm.m_gui = instance;

		//выставляем значение лучшего счета на канвасе
		bestScoreText.text = gm.bestScore + " m";

		//вкл/выкл чекмарк звука в зависимости от параметра в GameManager
		if (gm.sound)
		{
			soundToggle.isOn = true;
			gm.am.toggleAudioSource(true); //включение звука
		}
		else soundToggle.isOn = false;
	}

	[Header("GUI Text")]
	public Text bestScoreText; //Text лучшего счета

	[Header("GUI Toggles")]
	public Toggle soundToggle; //Toggle звука

	public void soundFunc()
	{
		gm.savePrefs(soundToggle.isOn); //переключаем звук через сохранение нового значения чекмарка звука
	}

	public void playButton()
	{
		SceneManager.LoadSceneAsync("Game"); //загружаем сцену Game
	}

	public void quitButton()
	{
		Application.Quit(); //Выход из приложения
	}
}