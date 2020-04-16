using UnityEngine;

/// <summary>
/// Контроль состояний игрового процесса
/// </summary>
public static class Statements
{
    /// <summary>
	/// Состояние паузы игрового процесса
	/// </summary>
	public static bool pause { get; private set; } = true;

	/// <summary>
	/// Устанавливает состояние паузы как newPause
	/// </summary>
	public static void setPause(bool newPause)
	{
		pause = newPause;
		Debug.Log($"Пауза: {pause}");
	}


	/// <summary>
	/// Состояние конца игры. True, если Player проиграл
	/// </summary>
	public static bool gameOver { get; private set; } = false;

	/// <summary>
	/// Устанавливает состояние проигрыша как newGameOver
	/// </summary>
	/// <returns><c>true</c>, if pause statement was set, <c>false</c> otherwise.</returns>
	public static void setGameOver(bool newGameOver)
	{
		gameOver = newGameOver;
		Debug.Log($"Конец игры: {gameOver}");

		if(gameOver)
		{
			AudioManager.playGameOverSound();
		}
	}
}
