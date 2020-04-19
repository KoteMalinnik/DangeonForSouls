using UnityEngine;

/// <summary>
/// Генератор объектов для пула. Чтобы создать пул объектов, надо создать объект в иерархии и прикрепить к нему компонент Generator
/// </summary>
[RequireComponent(typeof(Pool))]
public class Generator : MonoBehaviour
{
	/// <summary>
	/// The prefab.
	/// </summary>
	PoolObject poolObjectPrefab = null;

	[SerializeField]
	/// <summary>
	/// Имя префаба в папке Resources\Prefabs
	/// </summary>
	string prefabName = null;

	[SerializeField, Range(1, 50)]
	/// <summary>
	/// Количество генерируемых объектов. Задает максимальное количество объектов в пуле
	/// </summary>
	int objectsCount = 0;

	void Awake()
	{
		loadPrefab();
		renameGameObject();

		Pool pool = transform.GetComponent<Pool>();
		pool.initialize(objectsCount);
		Transform poolTransform = pool.transform;

		int poolObjectsCount = pool.maxSize;
		var newPoolObject = new PoolObject();

		for (int i = 0; i < poolObjectsCount; i++)
		{
			newPoolObject = Instantiate(poolObjectPrefab, Vector3.zero, Quaternion.identity);

			newPoolObject.transform.parent = poolTransform;
			newPoolObject.name = $"{prefabName} ({i})";
			newPoolObject.setParentPool(pool);

			pool.addObject(newPoolObject);
		}

		Destroy(this);
	}

	/// <summary>
	/// Загрузить префаб из папки Resources\Prefabs
	/// </summary>
	void loadPrefab()
	{
		var path = @"Prefabs\" + prefabName;
		Debug.Log($"<color=yellow>Загрузка префаба {prefabName} по пути {path}</color>");
		poolObjectPrefab = Resources.Load<PoolObject>(path);
	}

	/// <summary>
	/// Переименовать объект по имени префаба
	/// </summary>
	void renameGameObject()
	{
		gameObject.name = $"{prefabName}sPool";
	}

	void OnDestroy()
	{
		Debug.Log($"Объект <color=white>{prefabName}sGenerator</color> уничтожен");
	}
}