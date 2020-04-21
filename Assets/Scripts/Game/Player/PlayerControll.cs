using UnityEngine;

[RequireComponent(typeof(GameOverStateChecker))]
[RequireComponent(typeof(GroundCollisionProcessing))]
[RequireComponent(typeof(InputController))]
[RequireComponent(typeof(ScoreEnumerator))]
[RequireComponent(typeof(Movement))]
/// <summary>
/// Контроль Player-a
/// </summary>
public class PlayerControll : MonoBehaviour
{
	void Awake()
	{
		//обязательно устанавливаем состояние первого свайпа и касания платформы в false
		Statements.setFirstSwipe(false);
		Statements.setGrounded(false);
	}
}