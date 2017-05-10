using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int health;
	public int damage;
	public bool game_over;

	// Use this for initialization
	void Start () 
	{
		game_over = false;
		health = 100; 
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (health <= 0) 
		{
			health = 0;
			//right now, this bool value doesn't do anything
			//once a reset system is implemented, this will be useful
			game_over = true;
		}
	}

	void OnCollisionEnter(Collision collision)
	{

		//applies damage if colliding object has 'EnemyController' script
		//alternatively, tags can be added to the enemy prefabs to be used as identifiers
		if (collision.gameObject.GetComponent("EnemyController") != null && !game_over) 
		{
			health -= damage;
			print ("Collision");
		}
	}
}
