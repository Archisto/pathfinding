using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSeeker : GridMover
{
    public Transform targetTransform;

    private List<Node> path;
    private Pathfinding pathfinding;

    private void Start()
    {
        pathfinding = FindObjectOfType<Pathfinding>();

        node = pathGridManager.GetNodeFromWorldPos(transform.position);

        if (pathfinding == null)
        {
            Debug.LogError(
                "Could not find a Pathfinding object in the scene.");
        }
    }

    protected override void Update()
    {
        node = pathGridManager.GetNodeFromWorldPos(transform.position);

        path = pathfinding.FindPath(
                transform.position, targetTransform.position);

        //if (path.Count > 0)
        //{
        //    WalkPath();
        //}
    }

    private void WalkPath()
    {
        // TODO
    }

    private void OnDrawGizmos()
    {
        DrawPathGizmos();
    }

    private void DrawPathGizmos()
    {
        if (path != null)
        {
            foreach (Node node in path)
            {
                Gizmos.color = Color.yellow;
                pathGridManager.DrawNodeGizmo(node.position, 1);
            }
        }
    }
}
