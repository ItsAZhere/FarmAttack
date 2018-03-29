﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeAnimals : MonoBehaviour {

	public GameObject animalPrefab;
	private GameObject animal;
    private gameManager GameManager;



	void Start () {

        GameManager = GameObject.Find("gameManager").GetComponent<gameManager>();
		
	}
	

	void Update () {
		
	}


	//check to see if there is an animal already at the spot, if null == can place monster
	private bool CanPlaceAnimal()
	{
        int cost = animalPrefab.GetComponent<animalData>().levels[0].cost;
        return animal == null && GameManager.Gold >= cost;
	}



	void OnMouseUp()
	{
		
		if (CanPlaceAnimal ()) {

            animal = (GameObject)Instantiate(animalPrefab, transform.position, Quaternion.identity);
			this.GetComponent<SpriteRenderer> ().color = Color.clear;
			
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

            GameManager.Gold -= animal.GetComponent<animalData>().CurrentLevel.cost;


		}

        else if (CanUpgradeMonster()){

            animal.GetComponent<animalData>().IncreaseLevel();

            // play place_animal audio
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

            //update gold amount
            GameManager.Gold -= animal.GetComponent<animalData>().CurrentLevel.cost;
        }
	}



    // check if there is an animal at the spot and see if it is upgradable
    private bool CanUpgradeMonster()
    {
        if (animal != null)
        {
            animalData animalData = animal.GetComponent<animalData>();
            animalLevel nextLevel = animalData.GetNextLevel();
            if (nextLevel != null)
            {
                return GameManager.Gold >= nextLevel.cost;
            }


        }

       
        return false;
    }



}