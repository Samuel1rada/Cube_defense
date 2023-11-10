using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class Astar
{


    private static float radius = 1.0f;

    private static Dictionary<Point, Node> nodes;


    //create an invisible node for each node in the game.
    private static void createNodes()
    {

        //instantiates the dictionary 
        nodes = new Dictionary<Point, Node>();

        foreach (NodeScript node in LevelManager.Instance.Nodes.Values)
        {
            nodes.Add(node.GridPosition, new Node(node));
        }
    }


    public static void GetPath(Point start)
    {
        if(nodes == null)
        {
            createNodes();
        }

        HashSet<Node> openList = new HashSet<Node>();

        Node currentNode = nodes[start];

        openList.Add(currentNode);

       

        for (int x = -1; x <= 1; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                Point neighbourPos = new Point(currentNode.GridPosition.X - x, currentNode.GridPosition.Z - z);

                if (LevelManager.Instance.InBounds(neighbourPos) && LevelManager.Instance.Nodes[neighbourPos].Walkable && neighbourPos != currentNode.GridPosition)
                {
                    Node neigbour = nodes[neighbourPos];

                    if (!openList.Contains(neigbour))
                    {
                        openList.Add(neigbour);
                    }

                    neigbour.CalcValues(currentNode);
                }
             

            }
           
        }



        GameObject.Find("AstarDebugger").GetComponent<AstarDebugger>().DebugPath(openList);
    }
}
