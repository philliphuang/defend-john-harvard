// Controls enemies

using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public Transform target;
	public float speed = 50f;

	// move toward the target
	void Update () 
	{
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position,step);
	}

	// interact with projectiles
	void OnTriggerEnter(Collider other)
	{
		if (gameObject.tag == "STEM")
		{
			if (other.gameObject.CompareTag ("Pset"))
			{
				Destroy(gameObject);
				Destroy(other.gameObject);
			}

			else if (other.gameObject.CompareTag ("Essay"))
			{
				speed = speed*2;
				Destroy(other.gameObject);
			}
		}
		else if (gameObject.tag == "Humanities")
		{

			if (other.gameObject.CompareTag ("Essay")) 
			{
				Destroy(gameObject);
				Destroy(other.gameObject);
			}

			else if (other.gameObject.CompareTag ("Pset")) 
			{
				speed = speed*2;
				Destroy(other.gameObject);
			}
		}

	}
}
