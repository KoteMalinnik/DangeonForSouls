using UnityEngine;

/// <summary>
/// Движение
/// </summary>
public class Movement : MonoBehaviour
{
	/// <summary>
	/// Кешированный Transform
	/// </summary>
	static Transform cachedTransform = null;

	[SerializeField, Range(1, 20)]
	/// <summary>
	///  Вертикальная скорость
	/// </summary>
	float verticalSpeed = 7;

	/// <summary>
	/// Вертикальное направление. 1 - вверх.
	/// </summary>
	public static int verticalDirection { get; private set; } = 0;

	/// <summary>
	/// Обнулить вертикальное направление
	/// </summary>
	public static void resetVerticalDirection() { verticalDirection = 0; }

	/// <summary>
	/// Установить вертикальное направление. 1 - вверх, -1 - вниз
	/// </summary>
	public static void setVerticalDirection(int direction)
	{
		if (Mathf.Abs(direction) > 1) resetVerticalDirection();

		verticalDirection = direction;
		Statements.setGrounded(false);
	}

	[SerializeField, Range(1, 10)]
	/// <summary>
	/// Горизонтальная скорость
	/// </summary>
	float horizontalSpeed = 7;

	void Awake()
	{
		cachedTransform = transform;
		verticalDirection = 0;

		cachedTransform.localPosition = Vector3.zero;
	}

	void Update()
	{
		if (!Statements.gameOver && !Statements.pause)
		{
			Vector3 newPosition = cachedTransform.localPosition;

			newPosition.x += horizontalSpeed * Time.deltaTime;
			if (verticalDirection != 0 && !Statements.grounded) newPosition.y += verticalSpeed * verticalDirection * Time.deltaTime;

			cachedTransform.localPosition = newPosition;
		}
	}
}
