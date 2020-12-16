using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int _hitPoints = 10;

    [SerializeField] ParticleSystem _hitParticlePrefab;
    [SerializeField] ParticleSystem _deathParticlePrefab;
        
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
        _hitParticlePrefab.Play();
    }

    private void KillEnemy()
    {

        var vfx = Instantiate(_deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;

        Destroy(vfx.gameObject, destroyDelay);

        Destroy(gameObject);
    }
}
