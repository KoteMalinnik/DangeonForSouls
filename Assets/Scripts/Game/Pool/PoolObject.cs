using UnityEngine;

/// <summary>
/// Перемещение объекта в пул при выходе из зоны видимости камеры
/// </summary>
public class PoolObject : MonoBehaviour
{
	PoolObjectsReplacer replacer = null;

	public void setReplacer(PoolObjectsReplacer newReplacer)
	{
		if (newReplacer.pool == null) Debug.LogError("Пул Replacer-а не инициализирован!");
		replacer = newReplacer;
	}

    void OnBecameInvisible()
	{
		#if UNITY_EDITOR
		replacer.returnObjectToThePool(this);
		#endif

		//Если игра не находится в состоянии Конеца Игры
		//Если игра не находится в состоянии Пауза
		if (!Statements.gameOver && !Statements.pause)
		{
			replacer.returnObjectToThePool(this);
		}
	}
}
