using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NodeScript : MonoBehaviour
{

    // the Nodes grid position
    public Point GridPosition { get; private set; }


    public bool Walkable { get; set; }

   /* public Vector3 WordlPosition
    {
        get
        {
            return new Vector3(transform.position.x + transform.position.x/2, transform.position.y - transform.position.z / 2);
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Setup(Point gridPos, Vector3 wordlPos, Transform parent)
    {
        Walkable = true;
        this.GridPosition = gridPos;
        transform.position = wordlPos;
        transform.SetParent(parent);
        LevelManager.Instance.Nodes.Add(gridPos, this);
 
    }
}
