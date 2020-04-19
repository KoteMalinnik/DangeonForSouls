using UnityEngine;

/// <summary>
/// Вращение объекта
/// </summary>
public class Rotator : MonoBehaviour
{
    /// <summary>
	/// Установить вращение объекта в эйлеровских углах
	/// </summary>
	public static void setRotation(Transform objectTransform, Vector3 newEulerAngles)
	{
		objectTransform.localEulerAngles = newEulerAngles;
	}
}
