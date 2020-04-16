/// <summary>
/// Контролирь состояния паузы
/// </summary>
public static class PauseListener
{
    /// <summary>
	/// Состояние паузы игрового процесса
	/// </summary>
	static bool pauseStatement { get; set; } = false;

	/// <summary>
	/// Возвращает состояние паузы
	/// </summary>
	public static bool getPauseStatement() { return pauseStatement;}

	/// <summary>
	/// Устанавливает состояние паузы как newPauseStatement
	/// </summary>
	/// <returns><c>true</c>, if pause statement was set, <c>false</c> otherwise.</returns>
	public static void setPauseStatement(bool newPauseStatement) { pauseStatement = newPauseStatement;}
}
