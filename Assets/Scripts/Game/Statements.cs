using UnityEngine;

/// <summary>
/// Состояния игрового процесса
/// </summary>
public static class Statements
{
    /// <summary>
	/// Состояние паузы
	/// </summary>
	public static bool pause { get; private set; } = false;

	/// <summary>
	/// Установить состояние паузы
	/// </summary>
	public static void setPause(bool state)
	{
		pause = state;
		Debug.Log($"Пауза: {pause}");
	}


	/// <summary>
	/// Состояние конца игры
	/// </summary>
	public static bool gameOver { get; private set; } = false;

	/// <summary>
	/// Установить состояние конца игры
	/// </summary>
	/// <returns><c>true</c>, if pause statement was set, <c>false</c> otherwise.</returns>
	public static void setGameOver(bool state)
	{
		gameOver = state;
		Debug.Log($"Конец игры: {gameOver}");
	}


	/// <summary>
	/// Состояние касания о платформу
	/// </summary>
	public static bool grounded { get; private set; } = false;

	/// <summary>
	/// Установить состояние паузы
	/// </summary>
	public static void setGrounded(bool state)
	{
		grounded = state;
		//Debug.Log($"Касание платформы: {grounded}");
	}
}
