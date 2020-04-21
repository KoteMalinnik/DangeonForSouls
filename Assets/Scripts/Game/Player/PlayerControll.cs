using UnityEngine;

[RequireComponent(typeof(GameOverStateChecker))]
[RequireComponent(typeof(GroundCollisionDetector))]
[RequireComponent(typeof(InputController))]
[RequireComponent(typeof(ScoreEnumerator))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Recovery))]

/// <summary>
/// Контроль первоночальных состояний для Player-a
/// </summary>
public class PlayerControll : MonoBehaviour
{
	void Awake()
	{
		Statements.setGrounded(false);
		Statements.setGameOver(false);
		Statements.setPause(false);
	}
}