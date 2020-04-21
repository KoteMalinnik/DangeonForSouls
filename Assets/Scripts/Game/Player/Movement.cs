using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Движение
/// </summary>
public class Movement : MonoBehaviour
{
		public float animSpeed = 3;

		[Header("Speed Parametrs")]
		public float verticalSpeed = 1;
		public float horizontalSpeed = 1;
		public float speedCoefficient = 0;
		public float maxSpeedBoost = 10;
		float speedBoost = 0;


	/// <summary>
	/// Кешированный Transform
	/// </summary>
	Transform cachedTransform = null;

	void Awake()
	{
		cachedTransform = transform;

		//обязательно устанавливаем состояние касания платформы в false
		Statements.setGrounded(false);
	}

	void horizontalMovement()
	{
		//горизонтальное перемещение
		Vector3 pos = transform.position;
		pos = new Vector3(pos.x + (horizontalSpeed + speedCoefficient * speedBoost) * Time.deltaTime, pos.y, pos.z);
		transform.position = pos;
	}

		void Update()
		{
			if (!gm.p_gui.isPause && !gameOver)
			{


				

				//если игрок не перемещается вертикально
				if (!isMoving)
				{
	#if !UNITY_EDITOR
					//управление свайпом
					if(Input.touchCount>0)
					{
						if (Input.GetTouch(0).phase == TouchPhase.Began)
						{
							mStartPosition = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
						}

						if (Input.GetTouch(0).phase == TouchPhase.Moved)
						{
							Vector2 endPosition = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
							Vector2 swipeVector = endPosition - mStartPosition;

							if (swipeVector.magnitude > mMinSwipeDist)
							{
								swipeVector.Normalize();

								float angleOfSwipe = Vector2.Dot(swipeVector, mYAxis);
								angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;

								if (angleOfSwipe < mAngleRange && transform.position.y <= 0)
								{
									if (!gameStarted) gameStarted = true;

									isGrounded = false;
									OnSwipeTop();
								}
								else if ((180.0f - angleOfSwipe) < mAngleRange && transform.position.y >= 0)
								{
									if (!gameStarted) gameStarted = true;

									isGrounded = false;
									OnSwipeBottom();
								}
							}
						}
					}
	#elif UNITY_EDITOR
					//управление из редактора
					if(Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y <= 0)
					{
						if (!gameStarted) gameStarted = true;

						isGrounded = false;
						OnSwipeTop();
					}

					if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y >= 0)
					{
						if (!gameStarted) gameStarted = true;

						isGrounded = false;
						OnSwipeBottom();
					}

					if(Input.GetKeyDown(KeyCode.Escape))
					{
						gm.p_gui.pauseFunc();
					}
	#endif
				}
			}
		}

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
