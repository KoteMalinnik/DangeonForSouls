using UnityEngine;

public class backgroundObjectControll : MonoBehaviour
{
	backgroundControll bc;
	void Awake()
	{
		// получение родительского скрипта backgroundControll
		bc = GetComponentInParent<backgroundControll>();
	}

    void OnBecameInvisible()
	{
		//обновление позиции gameObject
		if(bc!=null) bc.setNewPosition(gameObject);	
	}
}
