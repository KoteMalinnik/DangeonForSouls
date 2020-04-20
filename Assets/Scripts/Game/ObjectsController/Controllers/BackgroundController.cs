using UnityEngine;

/// <summary>
/// Контроль перемещения объектов Background
/// </summary>
public sealed class BackgroundController : ObjectsController
{
	[SerializeField, Range(1, 4)]
	int objectsAtStartCount = 2;

	void Start()
	{
		lastObjectPosition = new Vector3(0, 0, 15);
		getObjects(objectsAtStartCount);
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
