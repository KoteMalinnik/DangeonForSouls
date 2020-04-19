using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public sealed class SoulsController : ObjectsController
{
	/// <summary>
	/// Позиция платформы
	/// </summary>
	Vector3 platformPosition = Vector3.zero;

	public void fillObjectWithSouls(Transform platformTransform)
	{
		if (pool == null) return;

		//Выставляем начальную позицию на платформе
		platformPosition = platformTransform.localPosition;
		lastObjectPosition.x = platformPosition.x - platformTransform.localScale.x / 2 + 1;

		int objectsCount = (int)platformTransform.localScale.x - 1;
		getObjects(objectsCount);
	}

	//new void getObjectFromPool()
	//{
	//	var objTransform = base.getObjectFromPool();
	//	setupPosition(objTransform);
	//	objTransform.GetComponent<SoulAnimation>().setStartParametrs();
	//}

	/// <summary>
	/// Установить позицию Transform
	/// </summary>
	protected override void setupPosition(Transform objTransform)
	{
		//Выставляем позицию по оси Y так, чтобы душа была на видимой стороне платформы
		var newPosition = objTransform.localPosition;

		newPosition.x = lastObjectPosition.x;
		newPosition.y = platformPosition.y > 0 ? platformPosition.y - 1 : platformPosition.y + 1;
		newPosition.z = platformPosition.z;

		Replacer.setNewPosition(objTransform, newPosition);
	}
}
