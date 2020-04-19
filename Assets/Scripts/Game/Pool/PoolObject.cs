using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Перемещение объекта в пул при выходе из зоны видимости камеры
/// </summary>
public class PoolObject : MonoBehaviour
{
	[SerializeField]
	UnityEvent OnReturningToPoolEvent = null;

	Pool parentPool = null;

	public void setParentPool(Pool newParentPool)
	{
		if (newParentPool == null) Debug.LogError("Пул не инициализирован!");
		parentPool = newParentPool;
	}

    void OnBecameInvisible()
	{
		//Если игра не находится в состоянии Конеца Игры
		//Если игра не находится в состоянии Пауза
		if (!Statements.gameOver && !Statements.pause)
		{
			if (parentPool != null)
			{
				parentPool.addObject(this);
				if(OnReturningToPoolEvent != null) OnReturningToPoolEvent.Invoke();
			}
		}
	}

	void OnDestroy()
	{
		if (OnReturningToPoolEvent != null) OnReturningToPoolEvent.RemoveAllListeners();
	}
}
