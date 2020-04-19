using UnityEngine;

/// <summary>
/// Изменение размера объекта
/// </summary>
public static class Rescaler
{
	/// <summary>
	/// Установить размер объекта
	/// </summary>
	/// <param name="objectTransform">Transform объекта.</param>
	/// <param name="newScale">Новый размер.</param>
	public static void setNewScale(ref Transform objectTransform, Vector3 newScale)
	{
		objectTransform.localScale = newScale;
	}

	/// <summary>
	/// Установить размер объекта по оси Х
	/// </summary>
	/// <param name="objectTransform">Transform объекта.</param>
	/// <param name="newScaleX">Новый размер по оси Х.</param>
	public static void setNewScale(ref Transform objectTransform, float newScaleX)
	{
		var currentScale = objectTransform.localScale;
		objectTransform.localScale = new Vector3(newScaleX, currentScale.y, currentScale.z);
	}
}
