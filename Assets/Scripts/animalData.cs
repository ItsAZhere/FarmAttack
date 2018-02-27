using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]


public class animalLevel { // separate class to manage animal cost and visual 

	public int cost;
	public GameObject visualization;
}



public class animalData : MonoBehaviour {


	public List<animalLevel> levels;
	private animalLevel currentLevel;


	void Start()
	{

	}


	void Update()
	{

	}


	public animalLevel CurrentLevel {

		
		get {
			return currentLevel;
		}
	
		set {
			currentLevel = value;
			int currentLevelIndex = levels.IndexOf (currentLevel);

			GameObject levelVisualization = levels [currentLevelIndex].visualization;
			for (int i = 0; i < levels.Count; i++) {
				if (levelVisualization != null) {
					if (i == currentLevelIndex) {
						levels [i].visualization.SetActive(true);
					} 
					else {
						levels [i].visualization.SetActive(false);
					}
				}
			}
		}
	
	}



	void OnEnable (){

		currentLevel = levels[0];
	}



}
