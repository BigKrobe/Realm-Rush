using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float _secondsBetweenSpawns = 2f;
    [SerializeField] int _enemiesToSpawn = 10;
    [SerializeField] EnemyMovement _enemyPrefab;
    [SerializeField] GameObject _enemyParent;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnEnemy()
    {
        for (int i = _enemiesToSpawn; i > 0; i--) 
        {
            var newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = _enemyParent.transform;
            yield return new WaitForSeconds(_secondsBetweenSpawns);
        }
    }
}
