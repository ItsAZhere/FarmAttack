using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

    private int gold, wave, health;
    public bool gameOver = false;
    public TextMesh waveLabel, healthLabel, goldLabel;
    public GameObject[] nextWaveLabels, healthIndicator;




	void Start () {

        //set starting amount of gold
        Gold = 100;
      

        // set beginning wave level
        Wave = 0;


        //set health
        Health = 5;
		
	}
	

	void Update () {
        
		if (wave == 3) {
			SceneManager.LoadScene (3); 
            // win screen
		}

		
	} 




    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            
            gold = value;
            goldLabel.text = "GOLD :  " + gold;

        }


    }




    public int Wave
    {
        get
        {
            return wave;
        }
        set
        {
            wave = value;
            if (!gameOver)
            {
               
            }
            waveLabel.text = "WAVE :  " + (wave + 1);
        }
	
    }



    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            // 1
            if (value < health)
            {
              Camera.main.GetComponent<CameraShake>().Shake();

            }

            health = value;
            healthLabel.text = "HEALTH :  " + health;


            if (health <= 0 && !gameOver)
            {
                gameOver = true;
				SceneManager.LoadScene (4); //if health is out, go to end screen


            }


            for (int i = 0; i < healthIndicator.Length; i++)
            {
                if (i < Health)
                {
                    healthIndicator[i].SetActive(true);
                }
                else
                {
                    healthIndicator[i].SetActive(false);
                }
            }
        }
    }



}
