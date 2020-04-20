using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionProcessing : MonoBehaviour
{
	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.layer == 9)
		{
			Debug.Log("Касание платформы");
			return;
		}
	}
}