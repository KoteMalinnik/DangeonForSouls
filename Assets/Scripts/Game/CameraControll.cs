using UnityEngine;

public class CameraControll : MonoBehaviour
{
	[SerializeField, Tooltip("Цель камеры")]
	/// <summary>
	/// Цель камеры
	/// </summary>
	GameObject targetObject = null;


	/// <summary>
	/// Начальная дистанция (transform.position.z) камеры до цели
	/// </summary>
	const float startDistance = -5;

	/// <summary>
	/// Конечная дистанция (transform.position.z) камеры до цели
	/// </summary>
	const float endDistance = -13;

	/// <summary>
	/// Смещение камеры относительно цели
	/// </summary>
	const float offset = 6;

	/// <summary>
	/// Плавность следования камеры за целью
	/// </summary>
	const float smooth = 3;


	/// <summary>
	/// Начальная позиция камеры
	/// </summary>
	Vector3 startPosition;

	Transform cachedTransform = null;
	Transform targetTransform = null;

	void Awake()
	{
		cachedTransform = transform;
		targetTransform = targetObject.transform;
	}

	void Start()
	{
		//выставляем камеру на начальную позицию
		startPosition = targetTransform.localPosition;
		startPosition.z = startDistance;

		cachedTransform.localPosition = startPosition;
	}

	Vector3 newPosition = Vector3.zero;
	void Update()
	{
		newPosition.x = targetTransform.localPosition.x + offset;
		newPosition.z = endDistance;

		//С помощью Lerp камера плавно следует за объектом
		cachedTransform.localPosition = Vector3.Lerp(startPosition, newPosition, smooth * Time.deltaTime);

		//Обновляем значение начальной позиции для последующего Lerp-a
		startPosition = cachedTransform.localPosition;
	}
}
