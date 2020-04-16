using System.Collections;
using UnityEngine;

//!!! Рефакторить

public class PlayerControll : MonoBehaviour
{
//	GameManager gm;
//	SphereAudioControll sac;

//	public static PlayerControll instance { get; private set; }
//	void Awake()
//	{
//		gm = GameManager.instance;

//		if (instance == null) instance = this;
//		else if (instance = this) Destroy(this);

//		gm.pc = instance;
//		sac = GetComponent<SphereAudioControll>();
//	}

//	void Start()
//	{
//		if (pauseGUI_Manager.instance != null) gm.p_gui = pauseGUI_Manager.instance;
//		else throw new System.Exception("GUI_Manager instance is not exist.");
//	}

//	public string groundTag = "ground";

//	public bool gameOver { get; private set; } = false; //true, если игрок зацепил объект hole
//	public bool isGrounded { get; private set; } //true, если находимся у объекта ground
//	public bool isMoving { get; private set; } = false; //true, если происходит вертикальное перемещение объекта Sphere

//	bool gameStarted { get; set; } = false; //true, если произошел первый свайп с момента запуска сцены Game

//	public float animSpeed = 3;

//	[Header("Speed Parametrs")]
//	public float verticalSpeed = 1;
//	public float horizontalSpeed = 1;
//	public float speedCoefficient = 0;
//	public float maxSpeedBoost = 10;
//	float speedBoost = 0;

//	public float score = 0;

//	readonly Vector2 mYAxis = new Vector2(0, 1);

//	const float mAngleRange = 30;
//	const float mMinSwipeDist = 10.0f;
//	Vector2 mStartPosition;

//	void Update()
//	{
//		if (!gm.p_gui.isPause && !gameOver)
//		{
//			if (gameStarted) score += Time.deltaTime*10; //считаем очки, если игрок начал управлять сферой

//			if (speedBoost <= maxSpeedBoost) speedBoost = score / 100; //рассчитываем дополнительное ускорение

//			//горизонтальное перемещение
//			Vector3 pos = transform.position;
//			pos = new Vector3(pos.x + (horizontalSpeed + speedCoefficient * speedBoost) * Time.deltaTime, pos.y, pos.z);
//			transform.position = pos;

//			//если игрок не перемещается вертикально
//			if (!isMoving)
//			{
//#if !UNITY_EDITOR
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
//#elif UNITY_EDITOR
//				//управление из редактора
//				if(Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y <= 0)
//				{
//					if (!gameStarted) gameStarted = true;

//					isGrounded = false;
//					OnSwipeTop();
//				}

//				if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y >= 0)
//				{
//					if (!gameStarted) gameStarted = true;

//					isGrounded = false;
//					OnSwipeBottom();
//				}

//				if(Input.GetKeyDown(KeyCode.Escape))
//				{
//					gm.p_gui.pauseFunc();
//				}
//#endif
//			}
//		}
//	}

//	//функция вызывается при свайпе вверх
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

//	//корутина вертикального движения. direction = 1 - вверх, -1 - вниз
//	IEnumerator moveSphere(int direction)
//	{
//		isMoving = true; //выставление переменной, которая блокирует управление вертикальным перемещением
//		Vector3 pos = transform.position;

//		//пока объект не коснулся ground или hole
//		while (!isGrounded && !gameOver)
//		{
//			//если игра не на паузе
//			if(!gm.p_gui.isPause)
//			{
//				if (verticalSpeed <= 0) throw new System.Exception("Vertical speed = 0.");
//				//рассчет вертикально-горизонтального движния
//				pos = new Vector3(pos.x + (horizontalSpeed + speedCoefficient * speedBoost) * Time.deltaTime, pos.y + verticalSpeed * direction * Time.deltaTime, pos.z);

//				//выравнивание, чтобы не западало на платформу
//				if ((pos.y > 4 && direction > 0) || (pos.y < -4 && direction < 0)) pos = new Vector3(pos.x, 4 * direction, pos.z);
//				transform.position = pos;
//			}
//			yield return new WaitForEndOfFrame();
//		}
//		isMoving = false; //вертикальное движение завершено

//		//Debug.Log("End of sphere moving");
//		yield return null;
//	}

//	void OnTriggerEnter(Collider coll)
//	{
//		if (coll.gameObject.tag == groundTag) //если коснулись ground
//		{
//			isGrounded = true;
//			//Debug.Log("This is GROUND. Good!");
//		}
//		else if (coll.gameObject.tag == "soul") //если коснулись soul
//		{
//			//подбираем душу. Рассчитываем счетчик и воспроизводим звук. Уничтожаем душу
//			gm.colectedSouls++;
//			gm.p_gui.updateSoulCounter(gm.colectedSouls);
//			if (gm.sound) sac.playSoulSound();
//			Destroy(coll.gameObject);
//		}
//		else //если коснулись hole
//		{
//			//Debug.Log("This is HOLE. Game Over.");
//			gameOver = true; //игрок проиграл
//			gameStarted = false; //игра закончилась

//			if (gm.sound) sac.playGameOverSound();
//			//выставляем лучший счет, если он обновился
//			if (score > gm.bestScore) gm.bestScore = (int)score;

//			gm.saveInt();

//			//показываем панель паузы
//			gm.p_gui.pauseFunc();
//		}
//	}

//	//бонус-продолжение. Возрождение. Отключение панели паузы и выставление позиции по центру
//	public IEnumerator gameOverBoost()
//	{
//		isMoving = true;
//		Vector3 pos = transform.position;
//		gameOver = false;

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