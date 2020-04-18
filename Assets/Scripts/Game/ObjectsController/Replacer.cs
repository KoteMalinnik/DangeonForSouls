using UnityEngine;

/// <summary>
/// Перемещение объекта в пространстве
/// </summary>
public static class Replacer
{
	/// <summary>
	/// Установить позицию объекта с учетом позиции предыдущего объекта в пуле на фиксированное расстояние по оси Х
	/// </summary>
	/// <param name="objectTransform">Transform объекта.</param>
	/// <param name="lastObjectPosition">Позиция предыдущего объекта.</param>
	/// <param name="deltaPositionX">Расстояние, на которое требуется перенести объект по оси X.</param>
	public static void setNewPosition(ref Transform objectTransform, ref Vector3 lastObjectPosition, float deltaPositionX)
	{
		objectTransform.position = lastObjectPosition + new Vector3(deltaPositionX, 0, 0);
		lastObjectPosition = objectTransform.position;

		Debug.Log($"<color=yellow>Перемещение объекта (ID {objectTransform.name})</color>");
	}

	/// <summary>
	/// Установить позицию объекта
	/// </summary>
	/// <param name="objectTransform">Transform объекта.</param>
	/// <param name="newPosition">Новая позиция.</param>
	public static void setNewPosition(ref Transform objectTransform, Vector3 newPosition)
	{
		objectTransform.position = newPosition;
	}
}