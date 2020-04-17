using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Перемещение объектов пула
/// </summary>
public class PoolObjectsReplacer : MonoBehaviour
{
	public Pool pool { get; private set; } = null; 

	public PoolObjectsReplacer(int newPoolSize)
	{
		pool = new Pool(newPoolSize);
	}

	public void returnObjectToThePool(PoolObject poolObject)
	{
		Debug.Log("Возвращение объекта в пул");
		pool.addObject(poolObject);
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

	////обновляет пулл объектов и возвращает старый первый (новый последний)
	//void updatePull(GameObject[,] pull)
	//{
	//	GameObject temp1 = getGround(pull), temp2 = getHole(pull);
	//	for (int i = 1; i < pull.Length/2; i++)
	//	{
	//		pull[i - 1, 0] = pull[i, 0];
	//		pull[i - 1, 1] = pull[i, 1];
	//	}

	//	pull[pull.Length/2 - 1, 0] = temp1;
	//	pull[pull.Length/2 - 1, 1] = temp2;
	//}

	//GameObject getGround(GameObject[,] pull)
	//{
	//	return pull[0,0];
	//}

	//GameObject getHole(GameObject[,] pull)
	//{
	//	return pull[0, 1];
	//}
}