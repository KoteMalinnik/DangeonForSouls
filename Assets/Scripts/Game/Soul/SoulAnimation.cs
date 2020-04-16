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
	SoulVisibilityListener visibilityListener;

	void Awake()
	{
		halo = GetComponentInChildren<Light>();
		visibilityListener = GetComponent<SoulVisibilityListener>();
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

	float startPositionY;  //начальная позиция объекта по оси Y
	float haloRangeStartPhase; //начальная фаза для анимации светимости

	void Start()
	{
		startPositionY = transform.position.y; //получаем позицию по оси Y
		haloRangeStartPhase = Random.Range(0, 0.1f); //устанавливаем случайную фазу
	}

	void Update()
	{
		//если объект в зоне видимости камеры
		if(visibilityListener.visibleStatement)
		{
			//Благодаря случайной фазе объекты двигаются по-разному и имеют разные размеры ореолов
			var newRange = 0.6f + Mathf.PingPong(haloRangeAnimationSpeed * Time.time, haloRangeStartPhase);
			halo.range = newRange;

			var phaseY = Mathf.PingPong(moveAnimationSpeed * Time.time, haloRangeStartPhase);
			var newPosition = new Vector3(transform.position.x, startPositionY + phaseY, 0);
			transform.position = newPosition;
		}
	}
}
