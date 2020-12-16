using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower _towerPrefab;
    [SerializeField] int _towerLimit = 5;
    [SerializeField] GameObject _towerParent;

    Queue<Tower> _towerQueue = new Queue<Tower>();
    // create an empty queue of towers

    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = _towerQueue.Count;

        if (numTowers < _towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(_towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = _towerParent.transform;
        baseWaypoint._isPlaceable = false;

        // set the baseWaypoints
        newTower._baseWaypoint = baseWaypoint;
        baseWaypoint._isPlaceable = false;

        _towerQueue.Enqueue(newTower);

    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldTower = _towerQueue.Dequeue();

        oldTower._baseWaypoint._isPlaceable = true;
        newBaseWaypoint._isPlaceable = false;

        oldTower._baseWaypoint = newBaseWaypoint;

        oldTower.transform.position = newBaseWaypoint.transform.position;

        _towerQueue.Enqueue(oldTower);
    }
}
