using UnityEngine;

/// <summary>
/// Контроль перемещения Soul в очереди
/// </summary>
public class SoulRaplacer : MonoBehaviour
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

		//Если игра не находится в состоянии Конеца Игры
		//Если игра не находится в состоянии Пауза
		if (!Statements.gameOver && !Statements.pause)
		{
			replaceSoul();
		}
	}

	void replaceSoul()
	{
		Debug.Log("Перенос Soul");
	}
}
