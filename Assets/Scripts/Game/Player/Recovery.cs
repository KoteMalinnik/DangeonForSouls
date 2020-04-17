using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//!!! Рефакторить
public class Recovery : MonoBehaviour
{
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
