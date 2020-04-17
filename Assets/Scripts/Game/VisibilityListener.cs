using UnityEngine;

/// <summary>
/// Класс имеет единственное поле visibleStatement
/// </summary>
public class VisibilityListener : MonoBehaviour
{
	/// <summary>
	/// Состояние видимости объекта. True, если объект попал в зону видимости камеры. False, если объект вышел из зоны видимости камеры
	/// </summary>
	public bool visibleStatement { get; private set; } = false;

    void OnBecameVisible()
	{
		visibleStatement = true;
	}

	void OnBecameInvisible()
	{
		visibleStatement = false;
	}
}
