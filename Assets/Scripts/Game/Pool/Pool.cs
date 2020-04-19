using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Пул объектов типа GameObject
/// </summary>
public class Pool : MonoBehaviour
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
	List<PoolObject> list = null;

	public int getCurrentSize()
	{
		return list.Count;
	}

	/// <summary>
	/// Инициализация пула
	/// </summary>
	public void initialize(int newMaxSize)
	{
		changeMaxSize(newMaxSize);
		list = new List<PoolObject>(maxSize);
		Debug.Log("Инициализирован пул с максимальным количеством объектов: " + maxSize);
	}

	/// <summary>
	/// Добавляет объект в пул
	/// </summary>
	public void addObject(PoolObject newPoolObject)
	{
		if(!list.Contains(newPoolObject))
		{
			if(getCurrentSize() >= maxSize)
			{
				Debug.Log("<color=yellow>Пул объектов полон. нельзя добавить новый объект</color>");
				return;
			}

			list.Add(newPoolObject);

			newPoolObject.gameObject.SetActive(false);

			//Debug.Log($"<color=green>Объект (ID {newPoolObject.name}) добавлен в пул.</color>");

			return;
		}

		Debug.Log($"<color=red>Пул уже содержит объект (ID {newPoolObject.name})</color>");
	}

	/// <summary>
	/// Удаляет объект из пула
	/// </summary>
	public void removeObject(PoolObject poolObject)
	{
		if (list.Contains(poolObject))
		{
			list.Remove(poolObject);

			//Debug.Log($"<color=green>Объект (ID {poolObject.name}) удален из пула.</color>");
			return;
		}

		Debug.Log($"<color=red>Пул не содержит объект (ID {poolObject.name})</color>");
	}

	/// <summary>
	/// Возвращает объект из пула и удаляет его. Возвращает null, если пул пуст.
	/// </summary>
	public PoolObject getObject()
	{
		if(getCurrentSize() == 0)
		{
			Debug.Log("<color=red>Пул объектов пуст</color>");
			return null;
		}

		var objectToReturn = list[0];
		removeObject(objectToReturn);

		objectToReturn.gameObject.SetActive(true);

		//Debug.Log($"<color=green>Объект (ID {objectToReturn.name}) выделен</color>");
		return objectToReturn;
	}
}
