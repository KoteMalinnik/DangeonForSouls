using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
	//объект-цель для следования камеры
	public GameObject sphere;
	//плавность следования камеры
	public float animSpeed = 3;
	//начальная позиция камеры
	Vector3 startCameraPos;

	void Start()
	{
		//выставляем камеру на начальную позицию
		startCameraPos = new Vector3(sphere.transform.position.x, sphere.transform.position.y, -5);
		transform.position = startCameraPos;
	}

	void Update()
	{
		//С помощью Lerp камера плавно следует за объектом
		transform.position = Vector3.Lerp(startCameraPos, new Vector3(sphere.transform.position.x + 6, 0, -13), animSpeed * Time.deltaTime);
		//Обновляем значение начальной позиции для последующего Lerp-a
		startCameraPos = transform.position;
	}
}
