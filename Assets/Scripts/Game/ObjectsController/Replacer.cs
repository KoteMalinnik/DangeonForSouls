using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Перемещение объектов в пространстве
/// </summary>
public static class Replacer
{
	/// <summary>
	/// Установить начальную позицию объекта с учетом предыдущей расстановки
	/// </summary>
	public static void setNewPosition(ref Transform poolObjectTransform, ref Vector3 lastObjectPosition, float deltaPositionX)
	{
		poolObjectTransform.position = lastObjectPosition + new Vector3(deltaPositionX, 0, 0);
		lastObjectPosition = poolObjectTransform.position;

		Debug.Log($"<color=yellow>Перемещение объекта (ID {poolObjectTransform.name})</color>");
	}
}