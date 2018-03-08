using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootDefense : MonoBehaviour {



    public List<GameObject> enemiesInRange; //create list of all enemies within range
    private float lastShotTime;
    private animalData animalData;



    void Start()
    {

        enemiesInRange = new List<GameObject>();
        lastShotTime = Time.time;
        animalData = gameObject.GetComponentInChildren<animalData>();

    }


    void Update()
    {

        GameObject target = null;

        // Determine the target of the animal. Iterate over all enemies in range
        float minimalEnemyDistance = float.MaxValue;
        foreach (GameObject enemy in enemiesInRange)
        {
            float distanceToGoal = enemy.GetComponent<moveEnemy>().DistanceToGoal();
            if (distanceToGoal < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToGoal;
            }
        }

        // call shoot if time passed is longer than chicken fire rate
        if (target != null)
        {
            if (Time.time - lastShotTime > animalData.CurrentLevel.fireRate)
            {
                Shoot(target.GetComponent<Collider2D>());
                lastShotTime = Time.time;
            }

            // Calculate the rotation angle between the monster and its target.
            // TODO ANIMATION FOR MONSTERS


        }

    }



    // remove enemies from list once destroyed
    void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }




    // add enemies that are in range to list
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("Enemy"))
        {
            // make sure chicken doesn't shoot dead enemies
            enemiesInRange.Add(other.gameObject);
            EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }




    // remove enemies from list once out of range 
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            EnemyDestructionDelegate del =
                other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }




    void Shoot(Collider2D target)
    {
        GameObject bulletPrefab = animalData.CurrentLevel.bullet;

        // Get the start and target positions of the bullet. 
        // Set the z-Position to that of bulletPrefab. 

        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        startPosition.z = bulletPrefab.transform.position.z;
        targetPosition.z = bulletPrefab.transform.position.z;


        // Instantiate a new bullet using the bulletPrefab for MonsterLevel. 
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
