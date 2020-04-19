using UnityEngine;

/// <summary>
/// Контроль перемещения объектов Background
/// </summary>
public sealed class BackgroundController : ObjectsController
{
	void Start()
	{
		lastObjectPosition = new Vector3(0, 0, 15);
		getObjects(pool.getCurrentSize());
	}

	protected override void setupObject(PoolObject obj)
	{
		Transform objTransform = obj.transform;

		setupPosition(objTransform);
		Rotator.setRotation(objTransform, new Vector3(-90, 0, 0));
	}

	/// <summary>
	/// Ширина объекта
	/// </summary>
	readonly float objWidth = 50;

	/// <summary>
	/// Установить позицию Transform
	/// </summary>
	protected override void setupPosition(Transform objTransform)
	{
		Replacer.setNewPosition(objTransform, lastObjectPosition);
		lastObjectPosition.x += objWidth;
	}
}
