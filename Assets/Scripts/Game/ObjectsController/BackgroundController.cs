using System.Collections;
using UnityEngine;
using System.Text;

public class BackgroundController : MonoBehaviour
{
	[SerializeField, Range(1, 50)]
	/// <summary>
	/// Количество объектов, которые будут взяты из пула и помещены на сцену в методе Start()
	/// </summary>
	int objectsAtStartCount = 1;

	/// <summary>
	/// Контролируемый пул объектов
	/// </summary>
	Pool pool { get; set; } = null;

	Camera mainCamera { get; set; } = null;
	Transform mainCameraTransfrom { get; set; } = null;

	/// <summary>
	/// Позиция камеры для запроса объекта из пула
	/// </summary>
	float cameraPositionToGetObjFromPool { get; set; } = 0;

	/// <summary>
	/// Ширина объекта
	/// </summary>
	readonly float objWidth = 50;

	/// <summary>
	/// Расстояние от позиции камеры до пересечения перспективы с объектом
	/// </summary>
	readonly float lengthFromoObjectCenterToIntersection = 9.56f;

	/// <summary>
	/// постоянная разница от края объекта до пересечения с перспективой
	/// </summary>
	readonly float constDelta = 13f;

	void Awake()
	{
		mainCamera = Camera.main;
		mainCameraTransfrom = Camera.main.transform;

		pool = GetComponent<Pool>();
	}

	void Start()
	{
		Debug.Log($"Взять {objectsAtStartCount} объектов из пула");
		for (int objectsCount = objectsAtStartCount; objectsCount > 0; objectsCount--)
		{
			getObjectFromPool();
		}
	}

	void Update()
	{
		if (mainCameraTransfrom.position.x >= cameraPositionToGetObjFromPool)
		{
			Debug.Log("<color=yellow>Update: Позиция камеры достигнута</color>");
			getObjectFromPool();
		}
	}

	void getObjectFromPool()
	{
		Debug.Log("Взять объект из пула");
		var obj = pool.getObject();

		if(obj != null)
		{
			Transform objTransform = obj.transform;

			setupObjectTransform(ref objTransform);
			calculateNextCameraPositionToGetObjectFromPool(objTransform);
		}
	}

	/// <summary>
	/// Позиция последнего объекта по оси Х
	/// </summary>
	float lastObjectPositionX = 0;

	/// <summary>
	/// Установить позицию для objTransform
	/// </summary>
	/// <param name="objTransform">Object transform.</param>
	void setupObjectTransform(ref Transform objTransform)
	{
		Rotator.setRotation(ref objTransform, new Vector3(-90, 0, 0));

		var newPosition = new Vector3(lastObjectPositionX, 0, 15);
		lastObjectPositionX += objWidth;
		Replacer.setNewPosition(ref objTransform, newPosition);
	}

	/// <summary>
	/// Вычислить новую позицию камеры, в которой требуется запросить объект из пула
	/// </summary>
	/// <param name="objTransform">Object transform.</param>
	void calculateNextCameraPositionToGetObjectFromPool(Transform objTransform)
	{
		//Рассчет позиций объекта
		float objCenterPosition = objTransform.localPosition.x; //Центр
		float objRightEdgePosition = objCenterPosition + objWidth / 2; //Позиция правого края

		cameraPositionToGetObjFromPool = objRightEdgePosition - lengthFromoObjectCenterToIntersection - constDelta;
	}
}
