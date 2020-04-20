using System.Collections;
using UnityEngine;

//!!! Рефакторить
public static class Recovery
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
	public static void applyRecovery()
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
	public static void startRecovery()
	{
		Debug.Log("Запуск восстановления");
	}

	///// <summary>
	///// Переместить Player на центр и изменить состояние gameOver на False
	///// </summary>
	//IEnumerator recovery()
	//{
	//	Transform cachedTransform = transform;

	//	var position = cachedTransform.position;

	//	while (Mathf.Abs(position.y) > 0.01) 
	//	{
	//		//position = Vector3.Lerp(transform.position, new Vector3(position.x, 0, 0), verticalSpeed*Time.deltaTime);

	//		transform.position = position;

	//		yield return new WaitForEndOfFrame();
	//	}

	//	transform.position = new Vector3(position.x, 0, 0);

	//	Statements.setGameOver(false);
	//	yield return null;
	//}
}
