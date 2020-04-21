using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

/// <summary>
/// Перемещение объекта в пул при выходе из зоны видимости камеры
/// </summary>
public class PoolObject : MonoBehaviour
{
	[SerializeField]
	bool reuseObjectOnInvisible = false;

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
