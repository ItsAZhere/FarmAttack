using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    public float speed = 10;
    public int damage;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    private float distance;
    private float startTime;
    private gameManager GameManager;


	
	void Start () {
        startTime = Time.time;
        distance = Vector2.Distance(startPosition, targetPosition);
        GameObject gm = GameObject.Find("gameManager");
        GameManager = gm.GetComponent<gameManager>();
		
	}
	
	
	void Update () {



        // calulate distance between bullet and target and move towards it
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);



        // confirm enemy still exists
        if (gameObject.transform.position.Equals(targetPosition))
        {
            if (target != null)
            {
                
                // retrieve enemy's healthbar and change it
                Transform healthBarTransform = target.transform.Find("HealthBar");
                enemyHealth healthBar = healthBarTransform.gameObject.GetComponent<enemyHealth>();
                healthBar.currentHealth -= Mathf.Max(damage, 0);


                // when enemy health reaches zero, destroy it
                if (healthBar.currentHealth <= 0)
                {
                    Destroy(target);
                    //TODO ADD AUDIO AudioSource audioSource = target.GetComponent<AudioSource>();
                    //TODO ADD AUDIO AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

                    GameManager.Gold += 50;
                }
            }
            Destroy(gameObject);
        }
	}
}
