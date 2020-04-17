using UnityEngine;

/// <summary>
/// Генератор объектов для пула
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

	void loadPrefab()
	{
		var path = @"Prefabs\" + prefabName;
		Debug.Log($"<color=yellow>Загрузка префаба {prefabName} по пути {path}</color>");
		poolObjectPrefab = Resources.Load<PoolObject>(path);
	}

	[SerializeField, Range(1, 50)]
	int objectsCount = 0;

	void Start()
	{
		loadPrefab();

		Pool pool = transform.GetComponent<Pool>();
		pool.initialize(objectsCount);
		Transform poolTransform = pool.transform;

		int poolObjectsCount = pool.maxSize;
		var newPoolObject = new PoolObject();

		for (int i = 0; i < poolObjectsCount; i++)
		{
			newPoolObject = Instantiate(poolObjectPrefab, Vector3.zero, Quaternion.identity);

			newPoolObject.transform.parent = poolTransform;
			newPoolObject.name = i.ToString();
			newPoolObject.setParentPool(pool);

			pool.addObject(newPoolObject);
		}

		Destroy(this);
	}

	void OnDestroy()
	{
		Debug.Log("Объект <color=white>Generator</color> уничтожен");
	}
}