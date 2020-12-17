using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float _secondsBetweenSpawns = 2f;
    [SerializeField] int _enemiesToSpawn = 10;
    [SerializeField] EnemyMovement _enemyPrefab;
    [SerializeField] GameObject _enemyParent;
    [SerializeField] int _numEnemySpawned;
    [SerializeField] Text _enemySpawned;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        _numEnemySpawned = _enemiesToSpawn;
        _enemySpawned.text = _numEnemySpawned.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnEnemy()
    {
        for (int i = _enemiesToSpawn; i > 0; i--)
        {
            AddScore();
            var newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = _enemyParent.transform;
            yield return new WaitForSeconds(_secondsBetweenSpawns);

        }
    }

    private void AddScore()
    {
        _numEnemySpawned--;
        _enemySpawned.text = _numEnemySpawned.ToString();
    }
}
