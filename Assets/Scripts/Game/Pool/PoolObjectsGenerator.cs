using UnityEngine;

/// <summary>
/// Генератор объектов для пула
/// </summary>
public class PoolObjectsGenerator : MonoBehaviour
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
		Debug.Log($"<color=yellow>Загрузка префаба {prefabName} из ресурсов</color>");
		var path = @"Prefabs\" + prefabName;
		poolObjectPrefab = Resources.Load<PoolObject>(path);
	}

	PoolObjectsReplacer replacer = null;

	[SerializeField, Range(1, 50)]
	int poolSize = 0;

	void Awake()
	{
		replacer = new PoolObjectsReplacer(poolSize);
	}

	void Start()
	{
		loadPrefab();

		Pool pool = replacer.pool;

		int poolObjectsCount = pool.maxSize;
		var newPoolObject = new PoolObject();

		for (int i = 0; i < poolObjectsCount; i++)
		{
			newPoolObject = Instantiate(poolObjectPrefab, Vector3.zero, Quaternion.identity);

			newPoolObject.transform.parent = transform;
			newPoolObject.name = i.ToString();
			newPoolObject.setReplacer(replacer);

			pool.addObject(newPoolObject);
		}
	}
}