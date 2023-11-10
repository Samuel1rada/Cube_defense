using UnityEngine;
using System.Collections;

public class ArcherTower : MonoBehaviour{
    private Transform target;

    [Header("Attributes")]

    public float range = 15f; //30f or 45f for ballista
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    
    public string enemyTag = "Enemy";

    //Rotation is missing

    public GameObject arrowPrefab;
    public GameObject firePoint;

    //Use this for initialization
    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    //Enemy detection
    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }


    }
    
    
    //Update is called once per frame
    void Update () {
        if (target == null)
            return;


        if (fireCountdown <= 0f) 
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;


    }

    void Shoot()
    {
        //Debug.Log("SHOOT!");
        GameObject arrowGO = (GameObject)Instantiate(arrowPrefab, firePoint.transform);
        Arrow arrow = arrowGO.GetComponent<Arrow>();
        
        if (arrow != null)
            arrow.Seek(target);
        

    }


    //Visual LineOfSight
    void OnDrawGizmosSelected () 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }


}