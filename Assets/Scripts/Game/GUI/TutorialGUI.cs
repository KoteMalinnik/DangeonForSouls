using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGUI : MonoBehaviour
{
    [Header("GUI Objects")]
	public GameObject tutorialImage; // изображение с обучением

	////Корутина обучения
	//IEnumerator tutorial()
	//{
	//	Debug.Log("Tutorial started");
	//	pauseStatement = true; //выставляем паузу
	//	pauseButton.interactable = false; //отключаем взаимодействие кнопки паузы
	//	tutorialImage.SetActive(true); //показываем изображение с обучением

	//	//будем находится здесь до тех пор, пока не будет произведено нажатие правой кнопкой мыши или тап по экрану
	//	yield return new WaitUntil(() => Input.touchCount > 0 || Input.GetMouseButtonDown(1));

	//	pauseStatement = false; //отключаем паузу
	//	pauseButton.interactable = true; //включаем взаимодействие кнопки
	//	tutorialImage.SetActive(false); //отключаем изображение с обучением

	//	Debug.Log("End of tutorial");
	//	yield return null;
	//}
}
