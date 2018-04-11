using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour {

    [HideInInspector]
    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    private float lastWaypointSwitchTime;
    public float speed = 1.0f;



	void Start () {
        
        lastWaypointSwitchTime = Time.time;
	}
	

	void Update () {

        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;
       
        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);

        if (gameObject.transform.position.Equals(endPosition))
        {      
            // changing current waypoint to the next waypoint
            if (currentWaypoint < waypoints.Length - 2)
            {
             
                currentWaypoint++;
                lastWaypointSwitchTime = Time.time;
                // TODO: Rotate into move direction
            }
            else
            {
              
                Destroy(gameObject);
                AudioSource audioSource = this.GetComponent<AudioSource>();
                audioSource.PlayOneShot(audioSource.clip);

                // adjust health when enemy reaches farm
                gameManager GameManager = GameObject.Find("gameManager").GetComponent<gameManager>();
                AudioSource audioSource2 = GameObject.FindWithTag("gameManager").GetComponent<AudioSource>();
                GameManager.Health -= 1;
                audioSource2.PlayOneShot(audioSource.clip);
            }
        }
		
	}



    // method to determine which enemy is closest to farm
    // calculates length of path left for enemy to travel
    public float DistanceToGoal()
    {
        float distance = 0;
        distance += Vector2.Distance(
            gameObject.transform.position,
            waypoints[currentWaypoint + 1].transform.position);
        for (int i = currentWaypoint + 1; i < waypoints.Length - 1; i++)
        {
            Vector3 startPosition = waypoints[i].transform.position;
            Vector3 endPosition = waypoints[i + 1].transform.position;
            distance += Vector2.Distance(startPosition, endPosition);
        }
        return distance;
    }
}
