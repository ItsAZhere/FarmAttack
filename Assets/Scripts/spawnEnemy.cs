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
	public Wave[] waves;
	public int timeBetweenWaves = 5; // 5 seconds
    private gameManager GameManager;
    private float lastSpawnTime;
    private int enemiesSpawned = 0;


	void Start () {

        lastSpawnTime = Time.time;
        GameManager = GameObject.Find("gameManager").GetComponent<gameManager>();
  
	}


	
	
	void Update () {


        int currentWave = GameManager.Wave;
        if (currentWave < waves.Length)
        {
            
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentWave].spawnInterval;




            //checking time between spawns and time interval to determine wave & enemy spawn
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
                 timeInterval > spawnInterval) &&
                enemiesSpawned < waves[currentWave].maxEnemies)
            {
                
                lastSpawnTime = Time.time;
                GameObject newEnemy = (GameObject)
                    Instantiate(waves[currentWave].enemyPrefab);
                newEnemy.transform.position = waypoints[0].transform.position;
                newEnemy.GetComponent<moveEnemy>().waypoints = waypoints;
                enemiesSpawned++;
            }




            // check if max number of waves is met, if not progress to next wave
            if (enemiesSpawned == waves[currentWave].maxEnemies &&
                GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                GameManager.Wave++;
                GameManager.Gold = Mathf.RoundToInt(GameManager.Gold * 1.1f);
                enemiesSpawned = 0;
                lastSpawnTime = Time.time;
            }

        }
        else
        {   
            GameManager.gameOver = true;
            //  GameObject gameOverText = GameObject.FindGameObjectWithTag("GameWon");
            //  gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
        }
		
	}
}
