using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WayPointMover : MonoBehaviour 
{   
    
    private Waypoint waypoints;

    [SerializeField] private float MoveSpeed = 5f;

    [SerializeField] private float distanceThreshold = 0.1f;

    private Transform currentWaypoint;

    private bool actionStarted = false;

    public void StartButtonClicked()
    {
        if (!actionStarted)
        {
            StartCoroutine(DelayedAction());
            actionStarted = true;
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            transform.LookAt(currentWaypoint);
            waypoints = GetComponent<Waypoint>().WayPoints;
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

    }

    // Update is called once per frame
    void Update()
    {
        
        waypoints.transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, MoveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            transform.LookAt(currentWaypoint);
        }
    }
}
