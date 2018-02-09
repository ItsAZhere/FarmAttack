using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeAnimals : MonoBehaviour {

	public GameObject animalPrefab;
	private GameObject animal;



	void Start () {
		
	}
	

	void Update () {
		
	}


	//check to see if there is an animal already at the spot, if null == can place monster
	private bool CanPlaceAnimal()
	{
		return animal == null;
	}



	void OnMouseUp()
	{
		
		if (CanPlaceAnimal())
		{
			this.GetComponent<SpriteRenderer> ().color = Color.clear;
			animal = (GameObject)Instantiate(animalPrefab, transform.position, Quaternion.identity);

			
			// add audio upon creation of animal

		   // deduct seeds
		}
	}
}
