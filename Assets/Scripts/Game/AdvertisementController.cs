using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using System.Collections;

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
		Regular.checkObject(ref pauseMenuGUI);

		if(allowAds)
		{
			if (Advertisement.isSupported)
			{
				StartCoroutine(reinitializeAds());
				return;
			}

			Debug.LogError("<color=red>Реклама не поддерживается на устройстве</color>");
		}
	}

	/// <summary>
	/// Повторная инициализация рекламы, пока она не инициализируется
	/// </summary>
	/// <returns>The ads.</returns>
	IEnumerator reinitializeAds()
	{
		Debug.Log("<color=yellow>Инициализация рекламы</color>");

		while (!Advertisement.isInitialized)
		{
			initializeAds();
			yield return new WaitForEndOfFrame();
		}

		Debug.Log("<color=green>Реклама инициализирована</color>");
		yield return null;
	}

	/// <summary>
	/// Инициализация рекламы
	/// </summary>
	void initializeAds()
	{
		Advertisement.Initialize(gameID, true);

		if (Advertisement.isInitialized)
		{
			adsRecovery.interactable = Advertisement.IsReady(myPlacementID);
			if (adsRecovery) adsRecovery.onClick.AddListener(ShowRewardedVideo);
			Advertisement.AddListener(this);
		}
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
