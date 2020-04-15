using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	// Менеджеры
	public pauseGUI_Manager p_gui { get; set;} //отвечает за канвас в сцене Game
	public menuGUI_Manager m_gui { get; set; } //отвечает за канвас в сцене MainMenu
	public PlayerControll pc { get; set;}		//отвечает за управление сферой
	public ObjectsGenerator og { get; set; }	//отвечает за генерацию объектов
	public AudioManager am { get; set; }		//отвечает за звук в игре

	public static GameManager instance { get; set; }
	void Awake()
	{
		if (instance == null) instance = this;
		else if (instance = this) Destroy(this);

		//PlayerPrefs.DeleteAll();

		am = GetComponent<AudioManager>();

		DontDestroyOnLoad(gameObject);

		if(Application.isMobilePlatform)
		{
			//QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = 30;
		}
	}

	void Start()
	{
		// загружаем данные
		loadPrefs();
		// отключаем звук в preload сцене
		am.toggleAudioSource(false);
		SceneManager.LoadSceneAsync("MainMenu");
	}

	// словарь сохраняемых данных
	string key_bestScore = "bestScore";
	public int bestScore { get; set;}

	string key_sound = "sound";
	public bool sound { get; set; }

	string key_collectedSouls = "collectedSouls";
	public int colectedSouls { get; set; }

	string key_gameOverBoostCost = "gameOverBoostCost";
	public int gameOverBoostCost { get; set; }

	// загрузка данных
	void loadPrefs()
	{
		//если существуют все ключи в PlayerPrefs
		if (PlayerPrefs.HasKey(key_sound) && PlayerPrefs.HasKey(key_bestScore)
		    && PlayerPrefs.HasKey(key_collectedSouls) && PlayerPrefs.HasKey(key_gameOverBoostCost))
		{
			bestScore = PlayerPrefs.GetInt(key_bestScore);
			colectedSouls = PlayerPrefs.GetInt(key_collectedSouls);
			gameOverBoostCost = PlayerPrefs.GetInt(key_gameOverBoostCost);

			if (PlayerPrefs.GetInt(key_sound) == 1) sound = true;
			else sound = false;

			Debug.Log("loaded");
		}
		else
		{
			// иначе устанавливаем по умолчанию, сохраняем, и снова загружаем
			Debug.Log("error");
			gameOverBoostCost = 100;
			bestScore = 0;
			colectedSouls = 0;

			saveInt();
			savePrefs(true);

			loadPrefs();
		}
	}

	// сохранение целочисленных данных
	public void saveInt()
	{
		PlayerPrefs.SetInt(key_bestScore, bestScore);
		PlayerPrefs.SetInt(key_gameOverBoostCost, gameOverBoostCost);
		PlayerPrefs.SetInt(key_collectedSouls, colectedSouls);
	}

	//сохранение булевой переменной звука
	public void savePrefs(bool newSound)
	{
		sound = newSound;
		if (newSound) PlayerPrefs.SetInt(key_sound, 1);
		else PlayerPrefs.SetInt(key_sound, 0);
		//установка AudioManager по значению
		am.toggleAudioSource(newSound);
	}

}