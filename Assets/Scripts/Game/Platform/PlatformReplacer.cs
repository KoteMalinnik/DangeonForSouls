using UnityEngine;

/// <summary>
/// Контроль перемещения платформы в очереди
/// </summary>
public class PlatformReplacer : MonoBehaviour
{
    void OnBecameInvisible()
	{
		//Если игра не находится в состоянии Конеца Игры
		//Если игра не находится в состоянии Пауза
		if (!Statements.gameOver && !Statements.pause)
		{
			replacePlatform();
		}
	}

	void replacePlatform()
	{
		Debug.Log("Перенос платформы");
	}
}
