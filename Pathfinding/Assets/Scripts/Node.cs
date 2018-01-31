using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IHeapItem<Node>
{
    public bool isBlocked;
    public bool isInClosedSet;
    public Vector3 position;

    public int gridX, gridY;

    /// <summary>
    /// The distance from start to this node
    /// </summary>
    public int gCost;

    /// <summary>
    /// The distance from this node to target
    /// </summary>
    public int hCost;

    public int FCost
    {
        get
        {
            return gCost + hCost;
        }
    }

    public Node prevNode;
    public Node[] neighbours;

    private int heapIndex;

    public Node(bool isBlocked, Vector3 position, int gridX, int gridY)
    {
        this.isBlocked = isBlocked;
        this.position = position;

        this.gridX = gridX;
        this.gridY = gridY;

        neighbours = new Node[8];
    }

    public int HeapIndex
    {
        get
        {
            return heapIndex;
        }

        set
        {
            heapIndex = value;
        }
    }

    public int CompareTo(Node node)
    {
        int comp = FCost.CompareTo(node.FCost);
        if (comp == 0)
        {
            comp = hCost.CompareTo(node.hCost);
        }
        return ~comp;
    }
}
