using UnityEngine;

/// <summary>
/// Контроль перемещения объектов Background
/// </summary>
public class BackgroundController : MonoBehaviour
{
	/// <summary>
	/// Контролируемый пул объектов
	/// </summary>
	static Pool pool { get; set; } = null;

	/// <summary>
	/// Ширина объекта
	/// </summary>
	static readonly float objWidth = 50;

	void Awake()
	{
		pool = GetComponent<Pool>();
	}

	void Start()
	{
		int objectsCount = pool.getCurrentSize();
		Debug.Log($"Взять {objectsCount} объектов из пула BackgroundsPool");
		for (; objectsCount > 0; objectsCount--)
		{
			getObjectFromPool();
		}
	}

	public void getObjectFromPool()
	{
		Debug.Log("Взять объект из пула BackgroundsPool");
		var obj = pool.getObject();

		if(obj != null)
		{
			Transform objTransform = obj.transform;
			setupRotation(objTransform);
			setupPosition(objTransform);
		}
	}

	/// <summary>
	/// Установить вращение Transform
	/// </summary>
	static void setupRotation(Transform objTransform)
	{
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
