using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMover : MonoBehaviour
{
    public PathGridManager pathGridManager;
    public Node node;

    protected virtual void Update()
    {
        node = pathGridManager.GetNodeFromWorldPos(transform.position);
    }
}
