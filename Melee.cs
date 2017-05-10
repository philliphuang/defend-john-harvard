using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent("EnemyController") != null) 
		{
			Destroy(collision.gameObject);
		}
	}
}
