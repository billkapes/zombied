using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemy, obstacle, ammo;
	PlayerController thePlayer;
	int enemyCount, maxRange, centerRange;
	float enemyTimer, ammoTimer, obstacleTimer;
	public float enemySpawnTime, ammoSpawnTime, obstacleSpawnTime;


	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController>();
		enemyTimer = enemySpawnTime;
		ammoTimer = ammoSpawnTime;
		obstacleTimer = obstacleSpawnTime;
		enemyCount = 1;
		centerRange = 8;
		maxRange = 1;

	}
	
	// Update is called once per frame
	void Update () {
		enemyTimer -= Time.deltaTime;
		ammoTimer -= Time.deltaTime;
		obstacleTimer -= Time.deltaTime;

		if (enemyTimer < 0f) {
			StartCoroutine(SpawnEnemyCluster());
			enemyTimer = enemySpawnTime;
		
		}

		if (ammoTimer < 0f) {
			Instantiate(ammo, new Vector3(Random.Range(-10f, 10f), 0.5f, thePlayer.transform.position.z + 50f), Quaternion.Euler(0f, Random.Range(0, 360), 0f));
			//ammoTimer = Random.Range(ammoSpawnTime - 2f, ammoSpawnTime + 2f);
			ammoTimer = ammoSpawnTime;
		}

		if (obstacleTimer < 0f) {
			Instantiate(obstacle, new Vector3(Random.Range(-10f, 10f), 0.5f, thePlayer.transform.position.z + 90f), Quaternion.Euler(0f, Random.Range(0, 360), 0f));
			obstacleTimer = obstacleSpawnTime - Random.Range(0f, 5f);
		}
	}

	IEnumerator SpawnEnemyCluster() {
		float Xcenter = Random.Range(
			-Mathf.Max(0, centerRange), 
			Mathf.Max(0, centerRange--)
		);


		//int amount = Random.Range(1, enemyCount++);
		int amount = enemyCount++;
		for (int i = 0; i < amount; i++) {

			Vector3 pos = new Vector3(
										Random.Range(Xcenter - Mathf.Min(maxRange, 8), Xcenter + Mathf.Min(maxRange++, 8)),
									  	1f,
									  	thePlayer.transform.position.z + 75f + Random.Range(-5f, 5f) 
									 );

			Instantiate(enemy, pos, Quaternion.identity);
			yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
		}
	}
}
