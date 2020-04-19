using UnityEngine;
using System;

public abstract class ObjectsController : MonoBehaviour
{
	/// <summary>
	/// Контролируемый пул объектов
	/// </summary>
	protected Pool pool { get; set; } = null;

	protected void Awake()
	{
		pool = GetComponent<Pool>();
	}

	protected void getObjects(int objectsCount)
	{
		Debug.Log($"Взять {objectsCount} объектов из пула {pool.name}");
		for (; objectsCount > 0; objectsCount--)
		{
			getObjectFromPool();
		}
	}

	public void getObjectFromPool()
	{
		Debug.Log($"Взять объект из пула {pool.name}");
		var obj = pool.getObject();

		if (obj == null) return;
		setupObject(obj);
	}

	protected virtual void setupObject(PoolObject obj) {}

	/// <summary>
	/// Позиция предыдущего объекта по оси Х
	/// </summary>
	protected Vector3 lastObjectPosition = Vector3.zero;

	/// <summary>
	/// Установить позицию Transform
	/// </summary>
	protected virtual void setupPosition(Transform objTransform) {}
}
