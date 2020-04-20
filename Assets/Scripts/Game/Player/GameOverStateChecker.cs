using UnityEngine;

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
			if (Mathf.Abs(cachedTransform.position.y) > 5)
				Statements.setGameOver(true);
    }
}
