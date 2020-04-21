using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Содержит регулярные функции
/// </summary>
public class Regular : MonoBehaviour
{
	/// <summary>
	/// Проверить присвоение объекту obj какого-либо значения. Если он пуст, то произвести попытку найти объект на сцене
	/// </summary>
	public static void checkObject<T>(ref T obj) where T : MonoBehaviour
	{
		if(obj == null)
		{
			obj = FindObjectOfType<T>();

			if(obj == null)
			{
				Debug.LogError($"<color=yellow>Объект класса {typeof(T)} отсутствует на сцене</color>");
				return;
			}

			Debug.Log($"<color=yellow>Объект класса {typeof(T)} назначен</color>");
		}
	}
}
