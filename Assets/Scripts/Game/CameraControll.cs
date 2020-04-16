using UnityEngine;

public class CameraControll : MonoBehaviour
{
	[SerializeField, Tooltip("Цель камеры")]
	/// <summary>
	/// Цель камеры
	/// </summary>
	GameObject targetObject = null;

	[SerializeField, Tooltip("Плавность следования камеры за целью")]
	/// <summary>
	/// Плавность следования камеры за целью
	/// </summary>
	float smooth = 3;


	/// <summary>
	/// Начальная позиция камеры
	/// </summary>
	Vector3 startPosition;

	[SerializeField, Tooltip("Начальная дистанция (transform.position.z) камеры до цели")]
	/// <summary>
	/// Начальная дистанция (transform.position.z) камеры до цели
	/// </summary>
	float startDistance = -5;

	[SerializeField, Tooltip("Конечная дистанция (transform.position.z) камеры до цели")]
	/// <summary>
	/// Конечная дистанция (transform.position.z) камеры до цели
	/// </summary>
	float endDistance = -13;

	[SerializeField, Tooltip("Смещение камеры относительно цели")]
	/// <summary>
	/// Смещение камеры относительно цели
	/// </summary>
	float offset = 6;

	void Start()
	{
		//выставляем камеру на начальную позицию
		startPosition = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y, startDistance);
		transform.position = startPosition;
	}

	void Update()
	{
		var newPotition = new Vector3(targetObject.transform.position.x + offset, 0, endDistance);
		//С помощью Lerp камера плавно следует за объектом
		transform.position = Vector3.Lerp(startPosition, newPotition, smooth * Time.deltaTime);
		//Обновляем значение начальной позиции для последующего Lerp-a
		startPosition = transform.position;
	}
}
