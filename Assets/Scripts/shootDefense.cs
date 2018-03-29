using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootDefense : MonoBehaviour {


    public float fireRate;
    public GameObject bulletPrefab;
    public List<GameObject> defensesInRange; //create list of all defenses within range
    private float lastShotTime;
    private animalData animalData;




    void Start()
    {

        defensesInRange = new List<GameObject>();
        lastShotTime = Time.time;
      //  animalData = gameObject.GetComponentInChildren<animalData>();

    }


    void Update()
    {

        GameObject target = null;

        // Determine the target. Iterate over all defenses in range
        foreach (GameObject defense in defensesInRange)
        {
            
           
                target = defense;
        }

        // call shoot if time passed is longer than enemy fire rate
        if (target != null)
        {
            if (Time.time - lastShotTime > fireRate)
            {
                Shoot(target.GetComponent<Collider2D>());
                lastShotTime = Time.time;
            }

            // Calculate the rotation angle between the monster and its target.
            // TODO ANIMATION FOR Animals


        }

    }



    // remove enemies from list once destroyed
    void OnDefenseDestroy(GameObject defense)
    {
        defensesInRange.Remove(defense);
    }




    // add defenses that are in range to list
    void OnTriggerEnter2D(Collider2D other)
    {


    }




    // remove defenses from list once out of range 
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            defensesInRange.Remove(other.gameObject);

        }
    }




    void Shoot(Collider2D target)
    {
        

        // Get the start and target positions of the bullet. 
        // Set the z-Position to that of bulletPrefab. 

        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        startPosition.z = bulletPrefab.transform.position.z;
        targetPosition.z = bulletPrefab.transform.position.z;


        // Instantiate a new bullet
        // Assign the startPosition and targetPosition of the bullet.



        GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
        newBullet.transform.position = startPosition;
        BulletBehavior bulletComp = newBullet.GetComponent<BulletBehavior>();
        bulletComp.target = target.gameObject;
        bulletComp.startPosition = startPosition;
        bulletComp.targetPosition = targetPosition;



        // create animation and sound effects
        // TODO
        // Animator animator = animalData.CurrentLevel.visualization.GetComponent<Animator>();
        // animator.SetTrigger("fireShot");
        // AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        // audioSource.PlayOneShot(audioSource.clip);
    }

}
