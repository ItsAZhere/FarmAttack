using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coyoteBehavior : MonoBehaviour {

	 // dont want to be editable from inspector
	public GameObject[] waypoints;
	private int currentWaypoint = 0;
	private float lastWaypointSwitchTime;
	public float speed = 3.0f;

	private float step = 0.0f;

	void Start () {
		
		lastWaypointSwitchTime = Time.time;
	}
	

	void Update () {

		// 1 
		Vector3 startPosition = waypoints [currentWaypoint].transform.position;
		Vector3 endPosition = waypoints [currentWaypoint + 1].transform.position;
		step += speed * Time.deltaTime;
		gameObject.transform.position = Vector3.MoveTowards (startPosition, endPosition, step); 
		//Debug.Log ("This happened" + startPosition + "Endpos" + endPosition);

		// 2 
	//	float pathLength = Vector3.Distance (startPosition, endPosition);
	//	float totalTimeForPath = pathLength / speed;
	//	float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
	//	gameObject.transform.position =Vector2.Lerp (startPosition, endPosition, currentTimeOnPath / totalTimeForPath);

		//Debug.Log (gameObject.transform.position);
		
	}


	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log ("Collided");
		if (other.tag == "Waypoint") {

		//	if (currentWaypoint < waypoints.Length - 2) {
				
				currentWaypoint++;
				lastWaypointSwitchTime = Time.time;
				// TODO: Rotate into move direction

		//	} else {
				// 3.b 
			//	Destroy (gameObject);


				// TODO: deduct health
			//}
		}
	}
}
