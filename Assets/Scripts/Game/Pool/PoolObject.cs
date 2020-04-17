using UnityEngine;

/// <summary>
/// Перемещение объекта в пул при выходе из зоны видимости камеры
/// </summary>
public class PoolObject : MonoBehaviour
{
	Pool parentPool = null;

	public void setParentPool(Pool newParentPool)
	{
		if (newParentPool == null) Debug.LogError("Пул не инициализирован!");
		parentPool = newParentPool;
	}

    void OnBecameInvisible()
	{
		#if UNITY_EDITOR
		parentPool.addObject(this);
		#endif

		//Если игра не находится в состоянии Конеца Игры
		//Если игра не находится в состоянии Пауза
		if (!Statements.gameOver && !Statements.pause)
		{
			parentPool.addObject(this);
		}
	}

	void OnDestroy()
	{
		parentPool.removeObject(this);
	}
}
