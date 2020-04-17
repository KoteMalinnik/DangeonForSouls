using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    /// <summary>
	/// Установить начальное вращение объекта в эйлеровских углах
	/// </summary>
	public static void setInitialRotation(ref Transform poolObjectTransform, Vector3 newEulerAngles)
	{
		poolObjectTransform.eulerAngles = newEulerAngles;
	}
}
