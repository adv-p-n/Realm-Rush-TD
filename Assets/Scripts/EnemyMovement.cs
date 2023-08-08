using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f,5f)] float moveSpeed = 1f;
    

    
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path) 
        {
            Vector3 startPos=transform.position;
            Vector3 endPos=waypoint.transform.position;
            float movePercent=0f;

            transform.LookAt(endPos);

            while (movePercent<1f)
            {
                movePercent += Time.deltaTime * moveSpeed;
                transform.position = Vector3.Lerp(startPos, endPos, movePercent);
                yield return new WaitForEndOfFrame();
            }
            
        }
    }
    
}
