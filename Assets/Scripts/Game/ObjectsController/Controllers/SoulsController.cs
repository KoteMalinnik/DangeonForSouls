using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoulsController : MonoBehaviour
{
	/// <summary>
	/// Контролируемый пул объектов
	/// </summary>
	static Pool pool { get; set; } = null;

	void Awake()
	{
		pool = GetComponent<Pool>();
	}

	/// <summary>
	/// Позиция предыдущего объекта по оси Х
	/// </summary>
	static float lastObjectPositionX = 0;
	static Vector3 platformPosition = Vector3.zero;

	public static void fillObjectWithSouls(Transform platformTransform)
	{
		if (pool == null) return;

		//Выставляем начальную позицию на платформе
		platformPosition = platformTransform.localPosition;
		lastObjectPositionX = platformPosition.x - platformTransform.localScale.x / 2 + 1;

		int objectsCount = (int)platformTransform.localScale.x - 1;

		Debug.Log($"Взять {objectsCount} объектов из пула SoulsPool");
		for (; objectsCount > 0; objectsCount--, lastObjectPositionX++)
		{
			getObjectFromPool();
		}
	}

	static void getObjectFromPool()
	{
		var obj = pool.getObject();

		if (obj != null)
		{
			Transform objTransform = obj.transform;
			setupPosition(objTransform);

			obj.GetComponent<SoulAnimation>().setStartParametrs();
		}
	}

	/// <summary>
	/// Установить позицию Transform
	/// </summary>
	static void setupPosition(Transform objTransform)
	{
		//Выставляем позицию по оси Y так, чтобы душа была на видимой стороне платформы
		var newPosition = objTransform.localPosition;

		newPosition.x = lastObjectPositionX;
		newPosition.y = platformPosition.y > 0 ? platformPosition.y - 1 : platformPosition.y + 1;
		newPosition.z = platformPosition.z;

		Replacer.setNewPosition(objTransform, newPosition);
	}
}
