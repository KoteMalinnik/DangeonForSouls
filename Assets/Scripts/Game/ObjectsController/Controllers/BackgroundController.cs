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
		setupRotation(objTransform);
	}

	/// <summary>
	/// Ширина объекта
	/// </summary>
	readonly float objWidth = 50;

	protected override void setupPosition(Transform objTransform)
	{
		objTransform.localPosition = lastObjectPosition;
		lastObjectPosition.x += objWidth;
	}

	protected override void setupRotation(Transform objTransform)
	{
		objTransform.localEulerAngles = new Vector3(-90, 0, 0);
	}
}
