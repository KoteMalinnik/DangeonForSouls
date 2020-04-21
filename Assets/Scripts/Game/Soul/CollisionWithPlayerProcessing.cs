using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public class CollisionWithPlayerProcessing : MonoBehaviour
{
	PoolObject poolObject = null;

	void Awake()
	{
		poolObject = GetComponent<PoolObject>();
	}

    void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			ValuesController.incrementСolectedSoulsValue();
			AudioManager.playCollectingSoulSound();
			poolObject.returnToPool();

			return;
		}
	}
}
