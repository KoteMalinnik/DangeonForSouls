using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Пул объектов типа GameObject
/// </summary>
public class Pool
{
	/// <summary>
	/// Максимальный размер пула
	/// </summary>
	public int maxSize { get; private set; } = 0;

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
	List<GameObject> poolList = null;

	public int getPoolSize()
	{
		return poolList.Count;
	}

	/// <summary>
	/// Инициализация пула
	/// </summary>
	public void initializePool(int maxPoolSize)
	{
		changeMaxSize(maxPoolSize);
		poolList = new List<GameObject>(maxSize); 
	}

	/// <summary>
	/// Добавляет объект в пул
	/// </summary>
	public void addObject(GameObject newPoolObject)
	{
		if(!poolList.Contains(newPoolObject))
		{
			if(getPoolSize() >= maxSize)
			{
				Debug.Log("<color=yellow>Пул объектов полон. нельзя добавить новый объект</color>");
				return;
			}

			poolList.Add(newPoolObject);

			Debug.Log($"<color=green>Объект (ID {newPoolObject}) добавлен в пул.</color>");
			return;
		}

		Debug.LogError($"<color=red>Пул уже содержит объект (ID {newPoolObject})</color>");
	}

	/// <summary>
	/// Удаляет объект из пула
	/// </summary>
	public void removeObject(GameObject poolObject)
	{
		if (poolList.Contains(poolObject))
		{
			poolList.Remove(poolObject);

			Debug.Log($"<color=green>Объект (ID {poolObject}) удален из пула.</color>");
			return;
		}

		Debug.LogError($"<color=red>Пул не содержит объект (ID {poolObject})</color>");
	}

	/// <summary>
	/// Возвращает объект из пула и удаляет его. Возвращает null, если пул пуст.
	/// </summary>
	public GameObject getObject()
	{
		if(getPoolSize() == 0)
		{
			Debug.LogError("<color=red>Пул объектов пуст</color>");
			return null;
		}

		var objectToReturn = poolList[0];
		removeObject(objectToReturn);

		Debug.Log("<color=green>Объект выделен</color>");
		return objectToReturn;
	}
}
