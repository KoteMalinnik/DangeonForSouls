using UnityEngine;

/// <summary>
/// Проверка на касание платформы
/// </summary>
public class GroundCollisionProcessing : MonoBehaviour
{
	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.layer == 9) Statements.setGrounded(true);
	}

	void OnTriggerExit(Collider collision)
	{
		if (collision.gameObject.layer == 9) Statements.setGrounded(false);
	}
}