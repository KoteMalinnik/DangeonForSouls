using UnityEngine;

/// <summary>
/// Контроль перемещения объектов Platfrom
/// </summary>
public sealed class PlatformController : ObjectsController
{
	[SerializeField]
	SoulsController soulsController = null;

	[SerializeField, Range(1, 10)]
	int objectsAtStartCount = 5;

	new void Awake()
	{
		Regular.checkObject(ref soulsController);
		base.Awake();
	}

	void Start()
	{
		lastObjectPosition = new Vector3(-4, 5, 0);
		getObjects(objectsAtStartCount);
	}

	protected override void setupObject(PoolObject obj)
	{
		Transform objTransform = obj.transform;

		setupScale(objTransform);
		setupPosition(objTransform);

		if (soulsController == null) return;
		soulsController.fillObjectWithSouls(objTransform); //Заполнить платформу объектами Soul
	}

	/// <summary>
	/// Размер последнего объекта по оси Х 
	/// </summary>
	float lastObjectScaleX = 0;

	protected override void setupScale(Transform objTransform)
	{
		var newScale = objTransform.localScale;
		newScale.x = Random.Range(4, 10);

		objTransform.localScale = newScale;
		lastObjectScaleX = newScale.x;
	}

	protected override void setupPosition(Transform objTransform)
	{
		//Выставляем противоположную позицию по оси Y, чтобы платформа была на другой стороне
		var newPosition = lastObjectPosition;

		newPosition.y = -lastObjectPosition.y;
		newPosition.x += lastObjectScaleX / 2; //Учесть предыдущий размер

		objTransform.localPosition = newPosition;

		newPosition.x += objTransform.localScale.x / 2; //Учесть текущий размер
		lastObjectPosition = newPosition;
	}
}
