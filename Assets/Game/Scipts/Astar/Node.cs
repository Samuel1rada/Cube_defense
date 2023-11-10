using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{

    public Point GridPosition { get; private set; } 

    public NodeScript NodeRef { get; private set; }
    public Node Parent { get; private   set; }


    public Node(NodeScript nodeRef) 
    {
        this.NodeRef = nodeRef;


        this.GridPosition = nodeRef.GridPosition;
    }


    public void CalcValues(Node parent)
    {
        this.Parent = parent;
    }
}
