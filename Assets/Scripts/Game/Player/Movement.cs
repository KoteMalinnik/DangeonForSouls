using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Движение
/// </summary>
public class Movement : MonoBehaviour
{


 //   //корутина вертикального движения. direction = 1 - вверх, -1 - вниз
	//IEnumerator moveSphere(int direction)
	//{
	//	isMoving = true; //выставление переменной, которая блокирует управление вертикальным перемещением
	//	Vector3 pos = transform.position;

	//	//пока объект не коснулся ground или hole
	//	while (!isGrounded && !gameOver)
	//	{
	//		//если игра не на паузе
	//		if (!gm.p_gui.isPause)
	//		{
	//			if (verticalSpeed <= 0) throw new System.Exception("Vertical speed = 0.");
	//			//рассчет вертикально-горизонтального движния
	//			pos = new Vector3(pos.x + (horizontalSpeed + speedCoefficient * speedBoost) * Time.deltaTime, pos.y + verticalSpeed * direction * Time.deltaTime, pos.z);

	//			//выравнивание, чтобы не западало на платформу
	//			if ((pos.y > 4 && direction > 0) || (pos.y < -4 && direction < 0)) pos = new Vector3(pos.x, 4 * direction, pos.z);
	//			transform.position = pos;
	//		}
	//		yield return new WaitForEndOfFrame();
	//	}
	//	isMoving = false; //вертикальное движение завершено

	//	//Debug.Log("End of sphere moving");
	//	yield return null;
	//}
}
