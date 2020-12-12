using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int _hitPoints = 10;
    [SerializeField] GameObject _deathFX;
    [SerializeField] Transform parent;
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (_hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        _hitPoints--;
    }

    private void KillEnemy()
    {
     //   GameObject fx = Instantiate(_deathFX, transform.position, Quaternion.identity);
     //   fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
