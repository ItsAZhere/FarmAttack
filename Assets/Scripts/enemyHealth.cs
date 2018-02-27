using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour {


    public float maxHealth = 100;
    public float currentHealth = 100;
    private float originalScale;


	
	void Start () {
		// adjusting healthbar to max
        originalScale = gameObject.transform.localScale.x;
	}
	
	
	void Update () {
        
        //adjusting healthbar depending on actual health levels
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x = currentHealth / maxHealth * originalScale;
        gameObject.transform.localScale = tmpScale;
		
	}
}
