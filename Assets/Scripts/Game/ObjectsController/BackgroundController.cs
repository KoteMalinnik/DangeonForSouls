using UnityEngine;

/// <summary>
/// Контроль перемещения объектов Background
/// </summary>
public class BackgroundController : MonoBehaviour
{
	//ObjectsAtStartCount = 2
	//Generator.ObjectsCount = 3

	[SerializeField, Range(1, 50)]
	/// <summary>
	/// Количество объектов, которые будут взяты из пула и помещены на сцену в методе Start()
	/// </summary>
	int objectsAtStartCount = 2;

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
		Debug.Log($"Взять {objectsAtStartCount} объектов из пула");
		for (int objectsCount = objectsAtStartCount; objectsCount > 0; objectsCount--)
		{
			getObjectFromPool();
		}
	}

	public void getObjectFromPool()
	{
		Debug.Log("Взять объект из пула");
		var obj = pool.getObject();

		if(obj != null)
		{
			Transform objTransform = obj.transform;
			setupRotation(ref objTransform);
			setupPosition(ref objTransform);
		}
	}

	/// <summary>
	/// Установить вращение Transform
	/// </summary>
	void setupRotation(ref Transform objTransform)
	{
		Rotator.setRotation(ref objTransform, new Vector3(-90, 0, 0));
	}

	/// <summary>
	/// Позиция последнего объекта по оси Х
	/// </summary>
	static Vector3 lastObjectPosition = new Vector3(0, 0, 15);

	/// <summary>
	/// Установить позицию Transform
	/// </summary>
	void setupPosition(ref Transform objTransform)
	{
		Replacer.setNewPosition(ref objTransform, lastObjectPosition);
		lastObjectPosition.x += objWidth;
	}
}
