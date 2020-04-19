using UnityEngine;

/// <summary>
/// Контроль перемещения объектов Background
/// </summary>
public class BackgroundController : ObjectsController
{
	/// <summary>
	/// Ширина объекта
	/// </summary>
	static readonly float objWidth = 50;

	public void getObjectFromPool()
	{
		Debug.Log($"Взять объект из пула {pool.name}");
		var obj = pool.getObject();

		if (obj == null) return;

		Transform objTransform = obj.transform;

		setupPosition(objTransform);

		Rotator.setRotation(objTransform, new Vector3(-90, 0, 0));
	}

	/// <summary>
	/// Позиция последнего объекта по оси Х
	/// </summary>
	static Vector3 lastObjectPosition = new Vector3(0, 0, 15);

	/// <summary>
	/// Установить позицию Transform
	/// </summary>
	static void setupPosition(Transform objTransform)
	{
		Replacer.setNewPosition(objTransform, lastObjectPosition);
		lastObjectPosition.x += objWidth;
	}
}
