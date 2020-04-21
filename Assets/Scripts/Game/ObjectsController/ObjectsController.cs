using UnityEngine;

/// <summary>
/// Класс контроллеров объектов, которые содержат пул объектов
/// </summary>
public abstract class ObjectsController : ControllerSetuper
{
	/// <summary>
	/// Контролируемый пул объектов
	/// </summary>
	protected Pool pool { get; set; } = null;

	protected void Awake()
	{
		pool = GetComponent<Pool>();
	}

	/// <summary>
	/// Взять objectsCount объектов из пула.
	/// </summary>
	protected void getObjects(int objectsCount)
	{
		//Debug.Log($"Взять {objectsCount} объектов из пула {pool.name}");
		for (; objectsCount > 0; objectsCount--)
		{
			getObjectFromPool();
		}
	}

	/// <summary>
	/// Взять objectsCount объектов из пула. secondEnumarotor инкрементируется objectsCount раз
	/// </summary>
	protected void getObjects(int objectsCount, ref float secondEnumarator)
	{
		//Debug.Log($"Взять {objectsCount} объектов из пула {pool.name}");
		for (; objectsCount > 0; objectsCount--, secondEnumarator++)
		{
			getObjectFromPool();
		}
	}

	/// <summary>
	/// Взять объект из пула и настроить его с помощью переопределяемого метода setupObject
	/// </summary>
	public void getObjectFromPool()
	{
		//Debug.Log($"Взять объект из пула {pool.name}");
		var obj = pool.getObject();

		if (obj == null) return;
		setupObject(obj);
	}

	/// <summary>
	/// Использовать объект очереди без перемещения в очередь
	/// </summary>
	public void useObject(PoolObject obj)
	{
		setupObject(obj);
	}
}
