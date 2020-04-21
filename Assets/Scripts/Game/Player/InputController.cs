using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Управление
/// </summary>
public class InputController : MonoBehaviour
{
	[SerializeField]
	PauseMenuGUI pauseMenuGUI = null;

	/// <summary>
	/// Кешированный Transform
	/// </summary>
	Transform cachedTransform = null;

	void Awake()
	{
		Regular.checkObject(ref pauseMenuGUI);

		cachedTransform = transform;

		//обязательно устанавливаем состояние первого свайпа в false
		Statements.setFirstSwipe(false);
	}

	void Update()
	{
		if(!Statements.gameOver && !Statements.pause)
		{
			#if !UNITY_EDITOR
			touchScreenInput();
			#elif UNITY_EDITOR
			unityEditorInput();
			#endif
		}
	}

	#if !UNITY_EDITOR
	readonly Vector2 mYAxis = new Vector2(0, 1);
	const float mAngleRange = 30;
	const float mMinSwipeDist = 10.0f;
	Vector2 mStartPosition = Vector2.zero;

	/// <summary>
	/// Управление с помощью свайпа на мобильном устройстве
	/// </summary>
	void touchScreenInput()
	{
		if (Input.touchCount > 0)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Began) mStartPosition = Input.GetTouch(0).position;
			
			if (Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				Vector2 mEndPosition = Input.GetTouch(0).position;
				Vector2 mSwipeVector = mEndPosition - mStartPosition;

				if (mSwipeVector.magnitude > mMinSwipeDist)
				{
					mSwipeVector.Normalize();

					float angleOfSwipe = Vector2.Dot(mSwipeVector, mYAxis);
					angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;

					if (angleOfSwipe < mAngleRange) OnSwipeTop();
					if ((180.0f - angleOfSwipe) < mAngleRange) OnSwipeBottom();
				}
			}
		}
	}
	#endif

	#if UNITY_EDITOR
	/// <summary>
	/// Управление в редакторе
	/// </summary>
	void unityEditorInput()
	{
		if(Statements.grounded || !Statements.firstSwipe)
		{
			if (Input.GetKeyDown(KeyCode.W)) OnSwipeTop();
			if (Input.GetKeyDown(KeyCode.S)) OnSwipeBottom();
		}

		if (Input.GetKeyDown(KeyCode.Escape)) pauseMenuGUI.__Pause();
	}
	#endif

    /// <summary>
    /// Свайп вверх
    /// </summary>
	void OnSwipeTop()
	{
		if (cachedTransform.localPosition.y > 0) return;

		Debug.Log("Свайп вверх");
		checkFirstSwipeAndSetIt();
	}

	/// <summary>
	/// Свайп вниз
	/// </summary>
	void OnSwipeBottom()
	{
		if (cachedTransform.localPosition.y < 0) return;

		Debug.Log("Свайп вниз");
		checkFirstSwipeAndSetIt();
	}

	/// <summary>
	/// Установить состояние firstSwipe, если требуется
	/// </summary>
	void checkFirstSwipeAndSetIt()
	{
		if (!Statements.firstSwipe) Statements.setFirstSwipe(true);
	}
}
