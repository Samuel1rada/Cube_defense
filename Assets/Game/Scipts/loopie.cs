using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class loopie : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 desti;
    // Start is called before the first frame update
    void Start()
    {
        desti = new Vector3(50, 0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(desti);
    }
}
