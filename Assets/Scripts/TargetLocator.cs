using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    [SerializeField] ParticleSystem arrow;
    float maxRange = 15f;
    

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

     void FindClosestTarget()
    {
        Enemy[] enemy = FindObjectsOfType<Enemy>();
        Transform closestEnemy= null;
        float maxDistance = Mathf.Infinity;
        foreach(Enemy target in enemy) 
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if(distance<maxDistance)
            {
                closestEnemy = target.transform;
                maxDistance = distance;

            }
        }
        target= closestEnemy;
    }

    void AimWeapon()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        weapon.LookAt(target);
        if (distance < maxRange)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

     void Attack(bool isActive)
    {
        var emissionModule = arrow.emission;
        emissionModule.enabled=isActive;
    }
}
