using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

	public enum SpawnState {Spawning, Waiting, Counting};

	[System.Serializable]
	public class Wave
	{
		public string name;
		public Transform enemy;
		public Transform enemy2;
		public int count;
		public float rate;
	}

	public Wave[] waves;
	private int nextWave = 0;
	
	public Transform[] spawnPoints;
	
	public float timeBetweenWaves = 5f;
	private float waveCountdown;
	
	private float searchCountdown = 1f;
	
	private SpawnState state = SpawnState.Counting;

	private float randomizer = 0.0F;
	
	void Start()
	{
		if(spawnPoints.Length == 0)
		{
			Debug.LogError("No spawn points referenced");
		}
	
		waveCountdown = timeBetweenWaves;
	}
	
	void Update()
	{
		if (state == SpawnState.Waiting)
		{
			//Check if enemies still alive
			if(!EnemyIsAlive())
			{
				//Begin new round
				WaveCompleted();
			}
			else
			{
				return;
			}
		}
	
		if(waveCountdown <= 0)
		{
			if(state != SpawnState.Spawning)
			{
				//Start spawning
				StartCoroutine( SpawnWave ( waves[nextWave] ) );
			}
		}
		else
		{
			waveCountdown -= Time.deltaTime;
		}
	}
	
	void WaveCompleted()
	{
		Debug.Log ("Wave Completed");
		
		state = SpawnState.Counting;
		waveCountdown = timeBetweenWaves;
		
		if(nextWave + 1 > waves.Length -1)
		{
			nextWave = 0;
			Debug.Log("All waves complete. Looping...");
			//Can add finished screen or difficulty multiplier
		}
		else
		{
			nextWave++;
		}
	}
	
	bool EnemyIsAlive()
	{
		searchCountdown -= Time.deltaTime;
		if (searchCountdown <= 0f)
		{
			searchCountdown = 1f;
			if(GameObject.FindGameObjectWithTag("STEM") == null || 
			   GameObject.FindGameObjectWithTag("Humanities") == null)
			{
				return false;
			}
		}
		return true;
	}
	
	IEnumerator SpawnWave (Wave _wave)
	{
		Debug.Log("Spawning Wave: " + _wave.name);
		
		state = SpawnState.Spawning;
		
		//Spawn
		for (int i = 0; i < _wave.count; i++)
		{
			randomizer = Random.Range(-1.0F,1.0F);
			if (randomizer < 0.0F)
			{
				SpawnEnemy(_wave.enemy);
				yield return new WaitForSeconds( 1f / _wave.rate);	
			}
			else 
			{
				SpawnEnemy(_wave.enemy2);
				yield return new WaitForSeconds( 1f / _wave.rate);	
			}

		}
		
		state = SpawnState.Waiting;
		
		yield break;
	}
	
	void SpawnEnemy (Transform _enemy)
	{
		//Spawn enemy
		Debug.Log ("Spawning Enemy: " + _enemy.name);
		
		Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
		Instantiate (_enemy, _sp.position, _sp.rotation);
		
	}
}
