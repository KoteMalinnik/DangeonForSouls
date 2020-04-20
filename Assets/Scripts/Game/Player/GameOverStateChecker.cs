using UnityEngine;

/// <summary>
/// Проверка на конец игры
/// </summary>
public class GameOverStateChecker : MonoBehaviour
{
	Transform cachedTransform = null;

	void Awake()
	{
		cachedTransform = transform;
	}

    void Update()
    {
		if(!Statements.gameOver && !Statements.pause)
		{
			if (Mathf.Abs(cachedTransform.position.y) > 5)
			{
				Statements.setGameOver(true);
				AudioManager.playGameOverSound();
			}
		}
    }
}
