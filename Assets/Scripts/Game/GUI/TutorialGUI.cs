using System.Collections;
using UnityEngine;

/// <summary>
/// Контроль панели обучения
/// </summary>
public class TutorialGUI : MonoBehaviour
{
	[SerializeField]
	bool alwaysShowTutorialPanel = false;

	void Start()
	{
		#if UNITY_EDITOR
		if(alwaysShowTutorialPanel)
		{
			StartCoroutine(showTutorialPanel());
			return;
		}
		#endif

		//Обучение будет показываться один раз в начале игры
		//Счет будет нулевым, если игру запускают первый раз
		if (ValuesController.bestScoreValue < 1) StartCoroutine(showTutorialPanel());
	}

	/// <summary>
	/// Отключение панели обучения
	/// </summary>
	IEnumerator showTutorialPanel()
	{
		Statements.setPause(true); //Состояние паузы вкл.
		gameObject.SetActive(true); //Показать панель обучения

		Debug.Log("Панель обучения вкл.");

		#if UNITY_EDITOR
		//Пока не будет произведено нажатие правой кнопкой мыши 
		yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
		#elif PLATFORM_ANDROID
		//Пока не будет произведено нажатие на экран
		yield return new WaitUntil(() => Input.touchCount > 0);
		#endif

		Debug.Log("Панель обучения выкл.");

		gameObject.SetActive(false); //Отключить панель обучения
		Statements.setPause(false); //Состояние паузы выкл.

		yield return null;
	}
}
