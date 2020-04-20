﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Управление
/// </summary>
public class InputController : MonoBehaviour
{
//	public float animSpeed = 3;

//	[Header("Speed Parametrs")]
//	public float verticalSpeed = 1;
//	public float horizontalSpeed = 1;
//	public float speedCoefficient = 0;
//	public float maxSpeedBoost = 10;
//	float speedBoost = 0;


//	readonly Vector2 mYAxis = new Vector2(0, 1);
//	const float mAngleRange = 30;
//	const float mMinSwipeDist = 10.0f;
//	Vector2 mStartPosition;

//	void Update()
//	{
//		if(!Statements.gameOver && !Statements.pause)
//		{
			
//		}

//		if (!gm.p_gui.isPause && !gameOver)
//		{
//			if (gameStarted) score += Time.deltaTime * 10; //считаем очки, если игрок начал управлять сферой

//			if (speedBoost <= maxSpeedBoost) speedBoost = score / 100; //рассчитываем дополнительное ускорение

//			//горизонтальное перемещение
//			Vector3 pos = transform.position;
//			pos = new Vector3(pos.x + (horizontalSpeed + speedCoefficient * speedBoost) * Time.deltaTime, pos.y, pos.z);
//			transform.position = pos;

//			//если игрок не перемещается вертикально
//			if (!isMoving)
//			{
////#if !UNITY_EDITOR
//				//управление свайпом
//				if(Input.touchCount>0)
//				{
//					if (Input.GetTouch(0).phase == TouchPhase.Began)
//					{
//						mStartPosition = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
//					}

//					if (Input.GetTouch(0).phase == TouchPhase.Moved)
//					{
//						Vector2 endPosition = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
//						Vector2 swipeVector = endPosition - mStartPosition;

//						if (swipeVector.magnitude > mMinSwipeDist)
//						{
//							swipeVector.Normalize();

//							float angleOfSwipe = Vector2.Dot(swipeVector, mYAxis);
//							angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;

//							if (angleOfSwipe < mAngleRange && transform.position.y <= 0)
//							{
//								if (!gameStarted) gameStarted = true;

//								isGrounded = false;
//								OnSwipeTop();
//							}
//							else if ((180.0f - angleOfSwipe) < mAngleRange && transform.position.y >= 0)
//							{
//								if (!gameStarted) gameStarted = true;

//								isGrounded = false;
//								OnSwipeBottom();
//							}
//						}
//					}
//				}
////#elif UNITY_EDITOR
//				//управление из редактора
//				if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y <= 0)
//				{
//					if (!gameStarted) gameStarted = true;

//					isGrounded = false;
//					OnSwipeTop();
//				}

//				if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y >= 0)
//				{
//					if (!gameStarted) gameStarted = true;

//					isGrounded = false;
//					OnSwipeBottom();
//				}

//				if (Input.GetKeyDown(KeyCode.Escape))
//				{
//					gm.p_gui.pauseFunc();
//				}
////#endif
//			}
//		}
//	}

//    //функция вызывается при свайпе вверх
//	void OnSwipeTop()
//	{
//		StartCoroutine(moveSphere(1));
//		//Debug.Log("Swipe Top");
//	}

//	//функция вызывается при свайпе вниз
//	void OnSwipeBottom()
//	{
//		StartCoroutine(moveSphere(-1));
//		//Debug.Log("Swipe Bottom");
//	}
}
