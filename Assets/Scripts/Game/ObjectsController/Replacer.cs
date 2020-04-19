using UnityEngine;

/// <summary>
/// Перемещение объекта в пространстве
/// </summary>
public static class Replacer
{
	/// <summary>
	/// Установить позицию объекта
	/// </summary>
	/// <param name="objectTransform">Transform объекта.</param>
	/// <param name="newPosition">Новая позиция.</param>
	public static void setNewPosition(Transform objectTransform, Vector3 newPosition)
	{
		objectTransform.localPosition = newPosition;
	}
}