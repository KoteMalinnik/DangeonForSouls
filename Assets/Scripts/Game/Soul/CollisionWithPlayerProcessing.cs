using UnityEngine;

[RequireComponent(typeof(PoolObject))]
/// <summary>
/// Обработка столкновения Soul с Player
/// </summary>
public class CollisionWithPlayerProcessing : MonoBehaviour
{
	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			ValuesController.incrementСolectedSoulsValue();
			AudioManager.playCollectingSoulSound();

			gameObject.layer = 4; //Сокрытие объекта от камеры, чтобы вызвать PoolObject.OnBecameInvisible()

			return;
		}
	}
}
