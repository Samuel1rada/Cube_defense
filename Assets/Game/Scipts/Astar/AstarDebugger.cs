using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstarDebugger : MonoBehaviour
{
    [SerializeField]
    private NodeScript start, goal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Astar.GetPath(start.GridPosition);
            Debug.Log("Path created");
        }
    }


    public void DebugPath(HashSet<Node> openList)
    {
        foreach (Node node in openList)
        {

            if (node.NodeRef != start)
            {
                Debug.Log(" all nodes in openlist: " + openList.Count);
            }
        }
    }


    /* private void ClickNode()
     {
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

             if (Physics.Raycast(ray, out RaycastHit hit))
             {
                 NodeScript tmp = hit.collider.gameObject.GetComponent<NodeScript>();  

                 if (tmp != null)
                 {
                    if(start == null)
                    {
                         start = tmp;
                         Debug.Log("Start node selected: " + start.name);

                     }
                    else if (goal == null)
                    {
                         goal = tmp;
                         Debug.Log("Goal node selected: " + goal.name);
                     }
                 }
             }

     }*/
}
