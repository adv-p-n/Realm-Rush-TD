using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    int currentHitpoints;
    void Start()
    {
        currentHitpoints = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

    }

    private void ProcessHit()
    {
        if (currentHitpoints > 0) { currentHitpoints -= 1; }
        else if (currentHitpoints <= 0) { Destroy(gameObject); }
    }
}
