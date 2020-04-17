using System.Collections;
using System.Collections.Generic;
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
		Statements.setGameOver(false);
	}


//	//бонус-продолжение. Возрождение. Отключение панели паузы и выставление позиции по центру
//	public IEnumerator gameOverBoost()
//	{
//		isMoving = true;
//		Vector3 pos = transform.position;

//		while (Mathf.Abs(pos.y) > 0.01) 
//		{
//			pos = Vector3.Lerp(transform.position, new Vector3(pos.x, 0, 0), verticalSpeed*Time.deltaTime);

//			transform.position = pos;

//			yield return new WaitForEndOfFrame();
//		}

//		transform.position = new Vector3(pos.x, 0, 0);
//		isMoving = false;

//		gm.p_gui.continueOrRestartFunc();
//		yield return null;
//	}
}
