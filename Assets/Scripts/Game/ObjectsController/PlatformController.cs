using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
 //   [SerializeField, Range(1, 50)]
	///// <summary>
	///// Количество объектов, которые будут взяты из пула и помещены на сцену в методе Start()
	///// </summary>
	//int objectsAtStartCount = 1;

	///// <summary>
	///// Контролируемый пул объектов
	///// </summary>
	//Pool pool { get; set; } = null;

	//Camera mainCamera { get; set; } = null;
	//Transform mainCameraTransfrom { get; set; } = null;

	///// <summary>
	///// Позиция камеры для запроса объекта из пула
	///// </summary>
	//float cameraPositionToGetObjFromPool { get; set; } = 0;

	///// <summary>
	///// Ширина объекта
	///// </summary>
	//readonly float objWidth = 50;

	///// <summary>
	///// Расстояние от позиции камеры до пересечения перспективы с объектом
	///// </summary>
	//readonly float lengthFromoObjectCenterToIntersection = 9.56f;

	///// <summary>
	///// постоянная разница от края объекта до пересечения с перспективой
	///// </summary>
	//readonly float constDelta = 13f;

	//void Awake()
	//{
	//	mainCamera = Camera.main;
	//	mainCameraTransfrom = Camera.main.transform;

	//	pool = GetComponent<Pool>();
	//}

	//void Start()
	//{
	//	Debug.Log($"Взять {objectsAtStartCount} объектов из пула");
	//	for (int objectsCount = objectsAtStartCount; objectsCount > 0; objectsCount--)
	//	{
	//		getObjectFromPool();
	//	}
	//}

	//void Update()
	//{
	//	if (mainCameraTransfrom.position.x >= cameraPositionToGetObjFromPool)
	//	{
	//		Debug.Log("<color=yellow>Update: Позиция камеры достигнута</color>");
	//		getObjectFromPool();
	//	}
	//}

	//void getObjectFromPool()
	//{
	//	Debug.Log("Взять объект из пула");
	//	var obj = pool.getObject();

	//	if (obj != null)
	//	{
	//		Transform objTransform = obj.transform;

	//		setupObjectTransform(ref objTransform);
	//		calculateNextCameraPositionToGetObjectFromPool(objTransform);
	//	}
	//}

	///// <summary>
	///// Позиция последнего объекта по оси Х
	///// </summary>
	//float lastObjectPositionX = 0;

	///// <summary>
	///// Установить позицию для objTransform
	///// </summary>
	///// <param name="objTransform">Object transform.</param>
	//void setupObjectTransform(ref Transform objTransform)
	//{
	//	Rotator.setRotation(ref objTransform, new Vector3(-90, 0, 0));

	//	var newPosition = new Vector3(lastObjectPositionX, 0, 15);
	//	lastObjectPositionX += objWidth;
	//	Replacer.setNewPosition(ref objTransform, newPosition);
	//}

	///// <summary>
	///// Вычислить новую позицию камеры, в которой требуется запросить объект из пула
	///// </summary>
	///// <param name="objTransform">Object transform.</param>
	//void calculateNextCameraPositionToGetObjectFromPool(Transform objTransform)
	//{
	//	//Рассчет позиций объекта
	//	float objCenterPosition = objTransform.localPosition.x; //Центр
	//	float objRightEdgePosition = objCenterPosition + objWidth / 2; //Позиция правого края

	//	cameraPositionToGetObjFromPool = objRightEdgePosition - lengthFromoObjectCenterToIntersection - constDelta;
	//}


	//void calculateNextCameraPositionToGetObjectFromPool(PoolObject obj)
	//{
	//	Transform objTransform = obj.transform;

	//	//Рассчет позиций объекта
	//	float objCenterPosition = objTransform.localPosition.x; //Центр
	//	float objWidth = obj.GetComponent<MeshFilter>().mesh.bounds.size.x * objTransform.localScale.x; //Ширина
	//	float objRightEdgePosition = objCenterPosition + objWidth / 2; //Позиция правого края

	//	//Рассчет дистанции от объекта до камеры
	//	float mainCameraDistance = Mathf.Abs(mainCameraTransfrom.position.z);
	//	float objDistance = Mathf.Abs(objTransform.position.z);
	//	float distanceFromCameraToObj = mainCameraDistance + objDistance;

	//	//Рассчет расстояния от позиции камеры до пересечения справа угла обзора и объекта
	//	float alpha = mainCamera.fieldOfView / 2;
	//	float lengthFromCameraPositionToIntersection = distanceFromCameraToObj * Mathf.Tan(alpha * Mathf.Deg2Rad);

	//	float mainCameraPosition = mainCameraTransfrom.position.x;
	//	float intersectionPosition = mainCameraPosition + lengthFromCameraPositionToIntersection;

	//	cameraPositionToGetObjFromPool = objRightEdgePosition - intersectionPosition - (objWidth + 5) / 4;

	//	string debugMessage = "Calculatings:";
	//	debugMessage += $"\n ObjCenterPosition = {objCenterPosition}";
	//	debugMessage += $"\n objWidth = {objWidth}";
	//	debugMessage += $"\n objLeftEdgePosition = {objRightEdgePosition}";
	//	debugMessage += "\n";
	//	debugMessage += $"\n mainCameraDistance = {mainCameraDistance}";
	//	debugMessage += $"\n objDistance = {objDistance}";
	//	debugMessage += $"\n distanceFromCameraToObj = {distanceFromCameraToObj}";
	//	debugMessage += "\n";
	//	debugMessage += $"\n alpha = {alpha}";
	//	debugMessage += $"\n lengthFromCameraPositionToIntersection = {lengthFromCameraPositionToIntersection}";
	//	debugMessage += "\n";
	//	debugMessage += $"\n mainCameraPosition = {mainCameraPosition}";
	//	debugMessage += $"\n intersectionPosition = {intersectionPosition}";
	//	debugMessage += "\n";
	//	debugMessage += $"\n cameraPositionToGetObjFromPool = {cameraPositionToGetObjFromPool}";
	//	Debug.Log(debugMessage);
	//}
}
