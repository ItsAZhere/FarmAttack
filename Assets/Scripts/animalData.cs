using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class animalLevel { // separate class to manage animal cost and visual 

	public int cost;
	public GameObject visualization;
    public GameObject bullet;
    public float fireRate;
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


    // getting current level and setting current level to active
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

		CurrentLevel = levels[0];
	}


    // return next level and check if animal is upgradable
    public animalLevel GetNextLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        int maxLevelIndex = levels.Count - 1;
        if (currentLevelIndex < maxLevelIndex)
        {
            return levels[currentLevelIndex + 1];
        }
        else
        {
            return null;
        }
    }




    // actually increasing and upgrading the animal
    public void IncreaseLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        if (currentLevelIndex < levels.Count - 1)
        {
            CurrentLevel = levels[currentLevelIndex + 1];
        }
    }



}
