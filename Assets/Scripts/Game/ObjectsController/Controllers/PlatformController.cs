using UnityEngine;

/// <summary>
/// Контроль перемещения объектов Platfrom
/// </summary>
public sealed class PlatformController : ObjectsController
{
	[SerializeField]
	SoulsController soulsController = null;

	void Start()
	{
		lastObjectPosition = new Vector3(-4, 4, 3);
		getObjects(pool.getCurrentSize());
	}

	//public new void getObjectFromPool()
	//{
	//	var objTransform = base.getObjectFromPool();
	//	setupPosition(objTransform);
	//	setupScale(objTransform);
	//	soulsController.fillObjectWithSouls(objTransform); //Заполнить платформу объектами Soul
	//}

	/// <summary>
	/// Размер последнего объекта по оси Х 
	/// </summary>
	float lastObjectScaleX = 0;

	void setupScale(Transform objTransform)
	{
		var newScale = objTransform.localScale;
		newScale.x = Random.Range(4, 10);

		objTransform.localScale = newScale;
		lastObjectScaleX = newScale.x;
	}

	/// <summary>
	/// Установить позицию Transform
	/// </summary>
	protected override void setupPosition(Transform objTransform)
	{
		//Выставляем противоположную позицию по оси Y, чтобы платформа была на другой стороне
		var newPosition = lastObjectPosition;
		if (lastObjectPosition.y < 0) newPosition.y = 4;
		if (lastObjectPosition.y > 0) newPosition.y = -4;

		newPosition.x += lastObjectScaleX / 2; //Учесть предыдущий размер

		Replacer.setNewPosition(objTransform, newPosition);

		newPosition.x += objTransform.localScale.x / 2; //Учесть текущий размер
		lastObjectPosition = newPosition;
	}
}
