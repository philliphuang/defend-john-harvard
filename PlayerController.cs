// Controls the player / statue
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// TURNING VARIABLES
	// turn toward this object
	public Transform target;
	// at this speed
	public float speed;
	
	// SHOOTING PROJECTILES
	// the projectile object
	public GameObject shot;
	public GameObject shot2;
	// where the projectile fires from
	public Transform shotSpawn;

	// GAMEOVER SIMPLE
	public Text Lives;


	// FIRING RATE STUFF
	// public float fireRate;
	// private float nextFire;

	// HEALTH
	public int health;
	public int damage;
	private GameObject[] gameObjects;
	public string[] enemies;

	void Start ()
	{
		Lives.text =  "Lives: " + health.ToString();
	}


	void Update () {

		// LOOK TOWARD TARGET
		Vector3 tempDir = target.position - transform.position;
		Vector3 targetDir = new Vector3(tempDir.x, 0, tempDir.z);
		float step = speed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);
		
		// SHOOT BULLETS
		// firing rate code commented out
		
		//if (Input.GetButton("Fire1") && Time.time > nextFire)
		if (Input.GetButtonDown ("Fire1"))
		{
			//nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
		
		//if (Input.GetButton("Fire1") && Time.time > nextFire)
		if (Input.GetButtonDown ("Fire2"))
		{
			//nextFire = Time.time + fireRate;
			Instantiate(shot2, shotSpawn.position, shotSpawn.rotation);
		}

		// DEATH
		if (health <= 0) 
		{
			gameObject.SetActive(false);
			Lives.text = "Game Over";

			foreach (string element in enemies)
			{
	  			gameObjects = GameObject.FindGameObjectsWithTag (element);

				for(var i = 0 ; i < gameObjects.Length ; i ++)
				{
					Destroy(gameObjects[i]);
				}
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent("EnemyController") != null) 
		{
			health -= damage;
			Lives.text =  "Lives: " + health.ToString();
			Destroy(collision.gameObject);
		}
	}
}
