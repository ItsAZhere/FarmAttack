using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

	[SerializeField]
	private float cameraSpeed = 0;

	private float xMax, yMin;



	private void Update () {

		GetInput (); 
		
	}


	//method used to move camera with WASD buttons
	private void GetInput(){
	
		if (Input.GetKey (KeyCode.W)) { 	// move up
			transform.Translate (Vector3.up * cameraSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S)) { 	// move down 
			transform.Translate (Vector3.down * cameraSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) {	 	// move left
			transform.Translate (Vector3.left * cameraSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.D)) { 	// move right
			transform.Translate (Vector3.right * cameraSpeed * Time.deltaTime);
		}

		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, 0, xMax), Mathf.Clamp (transform.position.y, yMin, 0), -10);
	}


	// method to set camera bounds 
	public void setLimits( Vector3 maxTile){

		Vector3 wp = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0));
		xMax = maxTile.x - wp.x;
		yMin = maxTile.y - wp.y;
	}

}
