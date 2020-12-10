using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint _startWaypoint, _endWaypoint;
    
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool _isRunning = true;
    Waypoint searchCenter;
    List<Waypoint> path = new List<Waypoint>(); 

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
        return path;
    }

    private void CreatePath()
    {
        path.Add(_endWaypoint);

        Waypoint previous = _endWaypoint.exploredFrom;
        while (previous != _startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }

        path.Add(_startWaypoint);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {

        queue.Enqueue(_startWaypoint);

        while (queue.Count > 0 && _isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter._isExplored = true;
            HaltIfEndFound();
            ExploreNeighbours();
        }
        print("Finished pathfinding?");
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == _endWaypoint)
        {
            _isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!_isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour._isExplored  || queue.Contains(neighbour))
        {
            // do nothing
        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }

    private void ColorStartAndEnd()
    {
        _startWaypoint.SetTopColor(Color.green);
        _endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }
}
