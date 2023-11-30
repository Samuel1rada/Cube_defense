using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WayPointMover : MonoBehaviour 
{   
    
    [SerializeField] private Waypoint waypoints;

    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float distanceThreshold = 0.1f;

    private Transform currentWaypoint;

    private bool actionStarted = false;

    public void StartButtonClicked()
    {
        if (!actionStarted)
        {
            StartCoroutine(DelayedAction());
            actionStarted = true;

          
           // waypoints = GetComponent<Waypoint>().WayPoints;
        }
    }
    private IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(1.0f); // Adjust the delay time as needed.
        // Your delayed action code here.
    }


    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            transform.LookAt(currentWaypoint);
        }
    }
}
