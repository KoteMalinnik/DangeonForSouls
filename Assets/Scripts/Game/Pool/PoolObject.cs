using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

/// <summary>
/// Перемещение объекта в пул при выходе из зоны видимости камеры
/// </summary>
public class PoolObject : MonoBehaviour
{
	[SerializeField]
	/// <summary>
	/// Использовать объект, не добавляя его в очередь
	/// </summary>
	bool reuseObjectOnInvisible = false;

	[SerializeField, Range(0, 10)]
	/// <summary>
	/// Слой, на котором распологается объект
	/// </summary>
	int layer = 0;

	Pool parentPool = null;
	ObjectsController objectsController = null;

	public void setParentPool(Pool newParentPool)
	{
		if (newParentPool == null) Debug.LogError("Пул не инициализирован!");
		parentPool = newParentPool;

		objectsController = parentPool.GetComponent<ObjectsController>();
	}

    void OnBecameInvisible()
	{
		//Если игра не находится в состоянии Конеца Игры
		//Если игра не находится в состоянии Пауза
		if (!Statements.gameOver && !Statements.pause) returnToPool();
	}

	public void returnToPool()
	{
		gameObject.layer = layer;

		if (parentPool == null)
		{
			Debug.LogWarning("Родительский пул пуст");
			return;
		}

		if (reuseObjectOnInvisible) 
		{
			objectsController.useObject(this);
			return;
		}

		parentPool.addObject(this);
	}

	void OnDestoy()
	{
		if (parentPool != null) parentPool.removeObject(this);
	}
}
