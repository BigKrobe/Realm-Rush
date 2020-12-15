using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower _towerPrefab;
    [SerializeField] int _towerLimit = 5;

    int towersPlaced = 0;

    public void AddTower(Waypoint baseWaypoint)
    {
        
        if (towersPlaced < _towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower();
        }
    }

    private static void MoveExistingTower()
    {
        print("No more towers may be placed!");
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Instantiate(_towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint._isPlaceable = false;
        towersPlaced++;
    }
}
