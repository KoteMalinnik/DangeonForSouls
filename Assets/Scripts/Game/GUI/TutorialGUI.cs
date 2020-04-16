using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGUI : MonoBehaviour
{
	void Awake()
	{
		Statements.setPauseStatement(true); //Состояние паузы вкл.
		gameObject.SetActive(true); //Показать панель обучения

		Debug.Log("Панель обучения вкл.");
	}

	void Start()
	{
		StartCoroutine(showTutorialPanel());
	}

	/// <summary>
	/// Отключение панели обучения
	/// </summary>
	IEnumerator showTutorialPanel()
	{
		#if UNITY_EDITOR
		//Пока не будет произведено нажатие правой кнопкой мыши 
		yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
		#elif PLATFORM_ANDROID
		//Пока не будет произведено нажатие на экран
		yield return new WaitUntil(() => Input.touchCount > 0);
		#endif

		Debug.Log("Панель обучения выкл.");

		gameObject.SetActive(false); //Отключить панель обучения
		Statements.setPauseStatement(false); //Состояние паузы выкл.

		yield return null;
	}
}
