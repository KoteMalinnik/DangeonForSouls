using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsController : MonoBehaviour
{
    [SerializeField]
	/// <summary>
	/// Разница позиции по оси Х
	/// </summary>
	float deltaPositionX = 50;

	[SerializeField]
	/// <summary>
	/// Вращение объекта в эйлеровских углах
	/// </summary>
	Vector3 rotation = Vector3.zero;

	/// <summary>
	/// Позиция предыдущего объекта
	/// </summary>
	Vector3 lastObjectPosition = Vector3.zero;

	void Awake()
	{
		lastObjectPosition = new Vector3(-deltaPositionX, 0, 0);
	}

	public void newObjectInThePoolEvent(Pool pool)
	{
		Debug.Log("Свободен объект в пуле");

		Transform currentPoolObjectTransform = pool.getObject().transform;

		Replacer.setNewPosition(ref currentPoolObjectTransform, ref lastObjectPosition, deltaPositionX);
		if (rotation != Vector3.zero) Rotator.setRotation(ref currentPoolObjectTransform, rotation);
	}

	//public void setObjectPositionAndScale(GameObject[,] pull)
	//{
	//	int newScaleX = Random.Range(minObjectSize, maxObjectSize);

	//	getGround(pull).transform.localScale = new Vector3(newScaleX, 1, 1);
	//	getHole(pull).transform.localScale = new Vector3(newScaleX, 1, 1);

	//	//новая позиция определяется как current = last + last.size/2 + current.size/2
	//	Vector3 newGroundPosition,newHolePosition;  

	//	if(placeUpper)
	//	{
	//		newGroundPosition = new Vector3(lastHigherObj.x + lastHigherObj.y / 2 + (float)newScaleX / 2, 5, 0);
	//		newHolePosition = new Vector3(lastLowerObj.x + lastLowerObj.y / 2 + (float)newScaleX / 2, -5, 0);

	//		lastHigherObj = new Vector2(newGroundPosition.x, newScaleX);
	//		lastLowerObj = new Vector2(newHolePosition.x, newScaleX);
	//	}
	//	else
	//	{
	//		newHolePosition = new Vector3(lastHigherObj.x + lastHigherObj.y / 2 + (float)newScaleX / 2, 5, 0);
	//		newGroundPosition = new Vector3(lastLowerObj.x + lastLowerObj.y / 2 + (float)newScaleX / 2, -5, 0);

	//		lastHigherObj = new Vector2(newHolePosition.x, newScaleX);
	//		lastLowerObj = new Vector2(newGroundPosition.x, newScaleX);
	//	}

	//	getGround(pull).transform.position = newGroundPosition;

	//	for (int i = 0; i < newScaleX - 1; i++)
	//	{
	//		GameObject soul = Instantiate(soulPrefab);

	//		soul.transform.position = newGroundPosition.y > 0 ?
	//			new Vector3(newGroundPosition.x - newScaleX / 2 + 1 + i, 4, 0)
	//			: new Vector3(newGroundPosition.x - newScaleX / 2 + 1 + i, -4, 0);
	//	}

	//	getHole(pull).transform.position = newHolePosition;

	//	updatePull(pull);

	//	//переключение размещения на другую сторону
	//	placeUpper = !placeUpper;
	//}
}
