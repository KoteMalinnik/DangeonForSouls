using UnityEngine;

public abstract class ObjectsController : MonoBehaviour
{
	/// <summary>
	/// Контролируемый пул объектов
	/// </summary>
	protected static Pool pool { get; set; } = null;

	protected void Awake()
	{
		pool = GetComponent<Pool>();
	}

	protected virtual void Start()
	{
		int objectsCount = pool.getCurrentSize();
		Debug.Log($"Взять {objectsCount} объектов из пула {pool.name}");
		for (; objectsCount > 0; objectsCount--)
		{
			getObjectFromPool();
		}
	}
}
