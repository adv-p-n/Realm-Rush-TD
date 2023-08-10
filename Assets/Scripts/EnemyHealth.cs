using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    int currentHitpoints;
    void OnEnable()
    {
        currentHitpoints = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

    }

    void ProcessHit()
    {
        if (currentHitpoints > 0) { currentHitpoints -= 1; }
        else if (currentHitpoints <= 0) { gameObject.SetActive(false); }
    }
}
