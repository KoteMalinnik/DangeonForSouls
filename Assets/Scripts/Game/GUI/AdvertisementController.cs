using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertisementController : MonoBehaviour
{
    void Start()
	{
		//Инициализация рекламы
		if (Advertisement.isSupported) Advertisement.Initialize("3472065", false);
	}
}
