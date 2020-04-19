using UnityEngine;

/// <summary>
/// Класс контроллеров объектов, которые содержат пул объектов
/// </summary>
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

	/// <summary>
	/// Взять objectsCount объектов из пула.
	/// </summary>
	protected void getObjects(int objectsCount)
	{
		Debug.Log($"Взять {objectsCount} объектов из пула {pool.name}");
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
		Debug.Log($"Взять {objectsCount} объектов из пула {pool.name}");
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
		Debug.Log($"Взять объект из пула {pool.name}");
		var obj = pool.getObject();

		if (obj == null) return;
		setupObject(obj);
	}

	/// <summary>
	///  Переопределяемый метод для настройки объекта
	/// </summary>
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
