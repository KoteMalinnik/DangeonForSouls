using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoulsController : ObjectsController
{
	protected override void Start() {}

	/// <summary>
	/// Позиция предыдущего объекта по оси Х
	/// </summary>
	static Vector3 lastObjectPosition = Vector3.zero;
	static Vector3 platformPosition = Vector3.zero;

	public static void fillObjectWithSouls(Transform platformTransform)
	{
		if (pool == null) return;

		//Выставляем начальную позицию на платформе
		platformPosition = platformTransform.localPosition;
		lastObjectPosition.x = platformPosition.x - platformTransform.localScale.x / 2 + 1;

		int objectsCount = (int)platformTransform.localScale.x - 1;

		Debug.Log($"Взять {objectsCount} объектов из пула SoulsPool");
		for (; objectsCount > 0; objectsCount--, lastObjectPosition.x++)
		{
			getObjectFromPool();
		}
	}

	static void getObjectFromPool()
	{
		Debug.Log($"Взять объект из пула {pool.name}");
		var obj = pool.getObject();

		if (obj == null) return;

		Transform objTransform = obj.transform;

		setupPosition(objTransform);

		obj.GetComponent<SoulAnimation>().setStartParametrs();
	}

	/// <summary>
	/// Установить позицию Transform
	/// </summary>
	static void setupPosition(Transform objTransform)
	{
		//Выставляем позицию по оси Y так, чтобы душа была на видимой стороне платформы
		var newPosition = objTransform.localPosition;

		newPosition.x = lastObjectPosition.x;
		newPosition.y = platformPosition.y > 0 ? platformPosition.y - 1 : platformPosition.y + 1;
		newPosition.z = platformPosition.z;

		Replacer.setNewPosition(objTransform, newPosition);
	}
}
