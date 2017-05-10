// Controls projectiles
using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	// speed of bullet
	public float speed;

	// go forward at the same constant speed
	void Start () 
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}

}