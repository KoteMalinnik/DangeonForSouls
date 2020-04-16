using UnityEngine;
using UnityEngine.Advertisements;

//!!! Рефакторить
public class AdvertisementController : MonoBehaviour
{
    void Start()
	{
		//Инициализация рекламы
		if (Advertisement.isSupported) Advertisement.Initialize("3472065", false);
	}
}
