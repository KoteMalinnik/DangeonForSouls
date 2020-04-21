using UnityEngine;
using System.Collections;

/// <summary>
/// Проверка на касание платформы
/// </summary>
public class GroundCollisionDetector : MonoBehaviour
{
	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.layer != 9) return;
		Statements.setGrounded(true);
	}

	void OnCollisionExit(Collision coll)
	{
		if (coll.gameObject.layer != 9) return;
		StartCoroutine(delay());
	}

	/// <summary>
	/// Задержка перед изменением состояния. Защита от дребезга
	/// </summary>
	IEnumerator delay()
	{
		for (int i = 0; i < 5; i++)
		{
			yield return new WaitForFixedUpdate();
		}

		Statements.setGrounded(false);
	}
}