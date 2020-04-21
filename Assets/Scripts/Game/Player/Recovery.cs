using System.Collections;
using UnityEngine;

//!!! Рефакторить
public class Recovery : MonoBehaviour
{
	/// <summary>
	/// True, если количество собранных душ превышает цену восстановления
	/// </summary>
	public static bool canRecovery()
	{
		bool result = ValuesController.colectedSoulsValue >= ValuesController.recoveryCostValue;
		return result;
	}

	/// <summary>
	/// Применить восстановление за души
	/// </summary>
	public void applyRecovery()
	{
		Debug.Log("Расчет количества оставшихся душ и новой цены");

		//Вычитаем цену восстановления из количества собранных душ
		var restOfCollectedSouls = ValuesController.colectedSoulsValue - ValuesController.recoveryCostValue;
		ValuesController.setСolectedSoulsValue(restOfCollectedSouls);

		//Добавляем к цене
		var newRecoveryCostValue = ValuesController.recoveryCostValue + 100;
		ValuesController.setRecoveryCostValue(newRecoveryCostValue);

		startRecovery();
	}

	/// <summary>
	/// Запустить восстановление
	/// </summary>
	public void startRecovery()
	{
		Debug.Log("Восстановление");
		Statements.setGameOver(false);
		StartCoroutine(recoveryAnimation());
	}

	[SerializeField, Range(1, 10)]
	/// <summary>
	/// Скорость анимации восстановления
	/// </summary>
	float recoverySpeed = 1;

	[SerializeField]
	/// <summary>
	/// Требуемая точность
	/// </summary>
	float recoveryAccuracy = 0.1f;

	/// <summary>
	/// Переместить Player на центр и изменить состояние паузы на False
	/// </summary>
	IEnumerator recoveryAnimation()
	{
		Debug.Log("Запуск восстановления");
		Transform cachedTransform = transform;

		var targetPosition = Vector3.zero;
		targetPosition.x = cachedTransform.localPosition.x;

		while (Mathf.Abs(cachedTransform.localPosition.y) > recoveryAccuracy) 
		{
			cachedTransform.localPosition = Vector3.Lerp(cachedTransform.localPosition, targetPosition, recoverySpeed * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}

		cachedTransform.localPosition = targetPosition;
		Statements.setPause(false);

		Debug.Log("Конец восстановления");
		yield return null;
	}
}
