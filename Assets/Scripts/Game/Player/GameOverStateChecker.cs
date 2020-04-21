using UnityEngine;

/// <summary>
/// Проверка на конец игры
/// </summary>
public class GameOverStateChecker : MonoBehaviour
{
	PauseMenuGUI pauseMenuGUI = null;

	Transform cachedTransform = null;

	void Awake()
	{
		cachedTransform = transform;

		Regular.checkObject(ref pauseMenuGUI);
	}

    void Update()
    {
		if(!Statements.gameOver && !Statements.pause)
		{
			if (Mathf.Abs(cachedTransform.position.y) > 6)
			{
				Movement.resetVerticalDirection();

				Statements.setGameOver(true);
				AudioManager.playGameOverSound();

				pauseMenuGUI.__Pause();
			}
		}
    }
}
