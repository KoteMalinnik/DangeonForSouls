using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
	public float speed = 1f;
	Transform cachedTransform = null;

	void Awake()
	{
		cachedTransform = transform;
	}

	void Update()
	{
		var newPosition = cachedTransform.position;
		newPosition.x += speed * Time.deltaTime;

		cachedTransform.position = newPosition;
	}
}
