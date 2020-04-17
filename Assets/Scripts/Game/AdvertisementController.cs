using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

/// <summary>
/// Контроль рекламы
/// </summary>
public class AdvertisementController : MonoBehaviour, IUnityAdsListener
{
	[SerializeField]
	/// <summary>
	/// True, если реклама разрешена разработчиком
	/// </summary>
	bool allowAds = false;

	/// <summary>
	/// Идентификатор приложения
	/// </summary>
	string gameID = "3472065";

	[SerializeField]
	/// <summary>
	/// Кнопка восстановления за просмотр рекламы
	/// </summary>
	Button adsRecovery = null; // кнопка, которая будет показывать ролик

	/// <summary>
	/// Идентификатор рекламного ролика
	/// </summary>
	string myPlacementID = "rewardedVideo";

	[SerializeField]
	PauseMenuGUI pauseMenuGUI = null;

	void Start()
	{
		if(pauseMenuGUI == null)
		{
			Debug.LogError("Пустой объект PauseMenuGUI");
			pauseMenuGUI = FindObjectOfType<PauseMenuGUI>();
		}

		if(allowAds)
		{
			if (Advertisement.isSupported)
			{
				initializeAds();
				return;
			}

			Debug.LogError("<color=red>Реклама не поддерживается на устройстве</color>");
		}
	}

	/// <summary>
	/// Инициализация рекламы
	/// </summary>
	void initializeAds()
	{
		Advertisement.Initialize("3472065", true);

		if (Advertisement.isInitialized)
		{
			Debug.Log("<color=green>Реклама инициализирована</color>");

			adsRecovery.interactable = Advertisement.IsReady(myPlacementID);
			if (adsRecovery) adsRecovery.onClick.AddListener(ShowRewardedVideo);
			Advertisement.AddListener(this);

			return;
		}

		Debug.LogError("<color=red>Реклама не была инициализирована</color>");
	}

	/// <summary>
	/// Показать рекламный ролик
	/// </summary>
	void ShowRewardedVideo()
	{
		Debug.Log("Показ рекламы");
		Advertisement.Show(myPlacementID);
	}


	void IUnityAdsListener.OnUnityAdsReady(string placementId)
	{
		Debug.Log("<color=yellow>Реклама готова</color>");
		adsRecovery.interactable |= placementId == myPlacementID;
	}

	void IUnityAdsListener.OnUnityAdsDidError(string message)
	{
		Debug.LogError("<color=red>Ошибка</color>");
	}

	void IUnityAdsListener.OnUnityAdsDidStart(string placementId)
	{
		// дополнительные действия, которые необходимо предпринять, когда конечные пользователи запускают объявление.
	}

	void IUnityAdsListener.OnUnityAdsDidFinish(string placementId, ShowResult showResult)
	{
		switch (showResult)
		{
			case ShowResult.Finished:
				Debug.Log("Реклама была просмотрена");
				startRecovery();
				break;
			case ShowResult.Skipped:
				Debug.Log("Реклама была пропущена");
				break;
			case ShowResult.Failed:
				Debug.Log("Реклама завершилась из-за ошибки");
				startRecovery();
				break;
		}
	}

	void startRecovery()
	{
		Recovery.startRecovery();
		pauseMenuGUI.__Continue();
	}
}
