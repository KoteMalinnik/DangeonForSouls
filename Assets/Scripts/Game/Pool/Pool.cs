using System.Collections.Generic;
using UnityEngine;

public class Pool
{
	/// <summary>
	/// Максимальный размер пула
	/// </summary>
	public int maxSize { get; private set; } = 20;

	/// <summary>
	/// Изменение максимального размера пула
	/// </summary>
	public void changeMaxSize(int newMaxSize)
	{
		if(newMaxSize<1)
		{
			Debug.LogError("<color=red>Неверное значение. Изменение максимального размера пула отменено.</color>");
			return;
		}

		maxSize = newMaxSize;
	}

	/// <summary>
	/// Пул объектов
	/// </summary>
	List<PoolObject> pool = null;

	/// <summary>
	/// Инициализация пула
	/// </summary>
	public void initializePool()
	{
		pool = new List<PoolObject>();
	}

	/// <summary>
	/// Добавляет объект в пул
	/// </summary>
	public void addObject(PoolObject newPoolObject)
	{
		if(!pool.Contains(newPoolObject))
		{
			if(pool.Count >= maxSize)
			{
				Debug.Log("<color=yellow>Пул объектов полон. нельзя добавить новый объект</color>");
				return;
			}

			pool.Add(newPoolObject);

			Debug.Log($"<color=green>Объект (ID {newPoolObject}) добавлен в пул.</color>");
			return;
		}

		Debug.LogError($"<color=red>Пул уже содержит объект (ID {newPoolObject})</color>");
	}

	/// <summary>
	/// Удаляет объект из пула
	/// </summary>
	public void removeObject(PoolObject poolObject)
	{
		if (pool.Contains(poolObject))
		{
			pool.Remove(poolObject);

			Debug.Log($"<color=green>Объект (ID {poolObject}) удален из пула.</color>");
			return;
		}

		Debug.LogError($"<color=red>Пул не содержит объект (ID {poolObject})</color>");
	}

	/// <summary>
	/// Возвращает объект из пула и удаляет его. Возвращает null, если пул пуст.
	/// </summary>
	/// <returns>The first object.</returns>
	public PoolObject getObject()
	{
		if(pool.Count==0)
		{
			Debug.LogError("<color=red>Пул объектов пуст</color>");
			return null;
		}

		var objectToReturn = pool[0];
		removeObject(objectToReturn);

		Debug.Log("<color=green>Объект выделен</color>");
		return objectToReturn;
	}
}
