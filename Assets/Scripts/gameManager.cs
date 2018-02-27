using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

	private int seeds;
	public Text seedsLabel;


	public int Seeds {
		get
		{ 
			return seeds;
		}
		set
		{
			seeds = value;
			seedsLabel.GetComponent<Text>().text = "Seeds: " + seeds;
		}
	}





	// Use this for initialization
	void Start () {

		seeds = 100;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
