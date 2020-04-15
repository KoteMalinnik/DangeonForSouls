using System.Collections;
using UnityEngine;

public class soulAnim : MonoBehaviour
{
	Light _light; //компонент light на объекте
	public float rangeSpeed = 1; //скорость анимации изменения светимости (изменение размера ореола (numb))
	public float transformSpeed = 1; //скорость анимации движения объекта
	bool isVisible = false; //переменная видимости. Нет необходимости анимировать объект, если он не виден

	void Awake()
	{
		//получение компонента
		_light = GetComponentInChildren<Light>();
	}

	float posY;  //начальная позиция объекта по оси Y
	float phase; //начальная фаза для анимации светимости

	void Start()
	{
		posY = transform.position.y; //получаем позицию по оси Y
		phase = Random.Range(0, 0.1f); //устанавливаем случайную фазу
	}

	void Update()
	{
		//если объект в зоне обзора камеры
		if(isVisible)
		{
			//установка значений. Благодаря случайной фазе объекты двигаются по-разному и имеют разные размеры ореолов
			_light.range = 0.6f + Mathf.PingPong(rangeSpeed * Time.time, phase);
			transform.position = new Vector3(transform.position.x, posY + Mathf.PingPong(transformSpeed * Time.time, phase), 0);
		}
	}

    void OnBecameVisible()
	{
		//объект попал в зону видимости камеры
		isVisible = true;
	}

	void OnBecameInvisible()
	{
		//уничтожаем, если объект вышел за пределы видимости камеры
		Destroy(this);
	}
}
