using UnityEngine;

/// <summary>
/// Переключает состояние видимости soulObject
/// </summary>
public class SoulVisibilityListener : MonoBehaviour
{
	/// <summary>
	/// Состояние видимости объекта
	/// </summary>
	public bool visibleStatement { get; private set; } = false;

    void OnBecameVisible()
	{
		//объект попал в зону видимости камеры;
		visibleStatement = true;
	}

	void OnBecameInvisible()
	{
		visibleStatement = false;
		//объект вышел за пределы видимости камеры
		Destroy(gameObject);
	}
}
