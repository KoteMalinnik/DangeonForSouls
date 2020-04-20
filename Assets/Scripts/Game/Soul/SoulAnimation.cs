using UnityEngine;

/// <summary>
/// Анимация объекта Soul
/// </summary>
public class SoulAnimation : MonoBehaviour
{
	/// <summary>
	/// Свет, прикрепленный к дочернему объекту
	/// </summary>
	Light halo;

	Transform cachedTransform = null;

	void Awake()
	{
		halo = GetComponentInChildren<Light>();
		cachedTransform = transform;

		setStartParametrs();
	}

	[SerializeField, Tooltip("Скорость изменения размера ореола (halo)")]
	/// <summary>
	/// Скорость изменения размера ореола (halo)
	/// </summary>
	float haloRangeAnimationSpeed = 0.1f;

	[SerializeField, Tooltip("Cкорость анимации движения объекта")]
	/// <summary>
	/// Cкорость анимации движения объекта
	/// </summary>
	float moveAnimationSpeed = 0.1f;

	float startPositionY = 0;  //начальная позиция объекта по оси Y
	float maxPhase; //максимальная фаза для анимации

	void Update()
	{
		//Благодаря случайной фазе объекты двигаются по-разному и имеют разные размеры ореолов
		halo.range = getNewHaloRange();
		cachedTransform.position = getNewPosition();
	}

	/// <summary>
	/// Рассчитать новый range для света
	/// </summary>
	float getNewHaloRange()
	{
		var phase = Mathf.PingPong(haloRangeAnimationSpeed * Time.time, maxPhase);
		var newRange = 0.6f + phase;
		return newRange;
	}

	/// <summary>
	/// Рассчитать новую позицию
	/// </summary>
	Vector3 getNewPosition()
	{
		var phase = Mathf.PingPong(moveAnimationSpeed * Time.time, maxPhase);

		var newPosition = cachedTransform.localPosition;
		newPosition.y = startPositionY + phase;

		return newPosition;
	}

	public void setStartParametrs()
	{
		startPositionY = cachedTransform.position.y; //получаем позицию по оси Y
		maxPhase = Random.Range(0, 0.1f); //устанавливаем случайную фазу
	}
}
