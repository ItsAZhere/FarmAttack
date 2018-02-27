using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
	public GameObject enemyPrefab;
	public float spawnInterval = 2;
	public int maxEnemies = 20;
}




public class spawnEnemy : MonoBehaviour {

	public GameObject[] waypoints;
	public GameObject testEnemyPrefab;

	public Wave[] waves;
	public int timeBetweenWaves = 5;

	//private gameManager gameManager;

//	private float lastSpawnTime;
	//private int enemiesSpawned = 0;


	// Use this for initialization
	void Start () {
		Instantiate(testEnemyPrefab).GetComponent<coyoteBehavior>().waypoints = waypoints;

		//lastSpawnTime = Time.time;
		//gameManager =
		//	GameObject.Find("GameManager").GetComponent<gameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
