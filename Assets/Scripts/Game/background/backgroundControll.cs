using UnityEngine;

//!!! Рефакторить
public class backgroundControll : MonoBehaviour
{
	//два объекта фона в очереди
	public GameObject[] pull = new GameObject[2];
	
	//начальное значение прошлой позиции
	// -50, т.к. в этом случае первый фон выставится в позиции (0,0,0)
	float lastPosition = -50; 

	void Awake()
	{
		// Установка начальных позиций для объектов фона
		setNewPosition(pull[0]);
		setNewPosition(pull[1]);
	}

	// Установка новой позиции
	public void setNewPosition(GameObject obj)
	{
		// Получаем текущую позицию объекта
		Vector3 pos = obj.transform.position;
		// Рассчитываем новую позицию. Размер объекта фона по оси X 50 юнитов
		pos = new Vector3(lastPosition + 50, pos.y, pos.z);
		// Сохраняем значение этой позиции для последующего рассчета
		lastPosition = pos.x;
		// Применяем рассчитанное значение позиции
		obj.transform.position = pos;
	}
}
