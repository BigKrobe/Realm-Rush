﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        print("Enemy Hit");
    }
}