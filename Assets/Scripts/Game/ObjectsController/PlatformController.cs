using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
	/// <summary>
	/// Контролируемый пул объектов
	/// </summary>
	static Pool pool { get; set; } = null;

	void Awake()
	{
		pool = GetComponent<Pool>();
	}

	void Start()
	{
		int objectsCount = pool.getCurrentSize();
		Debug.Log($"Взять {objectsCount} объектов из пула");
		for (; objectsCount > 0; objectsCount--)
		{
			getObjectFromPool();
		}
	}

	public void getObjectFromPool()
	{
		Debug.Log("Взять объект из пула");
		var obj = pool.getObject();

		if (obj != null)
		{
			Transform objTransform = obj.transform;
			setupScale(ref objTransform);
			setupPosition(ref objTransform);
		}
	}

	/// <summary>
	/// Размер последнего объекта по оси Х 
	/// </summary>
	static float lastObjectScaleX = 0;

	void setupScale(ref Transform objTransform)
	{
		var newScale = objTransform.localScale;
		newScale.x = Random.Range(4, 10);

		objTransform.localScale = newScale;
		lastObjectScaleX = newScale.x;
	}

	/// <summary>
	/// Позиция последнего объекта по оси Х
	/// </summary>
	static Vector3 lastObjectPosition = new Vector3(-10, 4, 3);

	/// <summary>
	/// Установить позицию Transform
	/// </summary>
	void setupPosition(ref Transform objTransform)
	{
		//Выставляем противоположную позицию по оси Y, чтобы платформа была на другой стороне
		var newPosition = lastObjectPosition;
		if (lastObjectPosition.y < 0) newPosition.y = 4;
		if (lastObjectPosition.y > 0) newPosition.y = -4;

		newPosition.x += lastObjectScaleX / 2; //Учесть предыдущий размер

		Replacer.setNewPosition(ref objTransform, newPosition);

		newPosition.x += objTransform.localScale.x / 2; //Учесть текущий размер

		lastObjectPosition = newPosition;
	}
}
