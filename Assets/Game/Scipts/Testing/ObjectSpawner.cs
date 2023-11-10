using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        // Check if the objectToSpawn is assigned in the Inspector
        if (objectToSpawn != null)
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Please assign a GameObject to objectToSpawn in the Inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CreatSpline()
    {


    }
}
