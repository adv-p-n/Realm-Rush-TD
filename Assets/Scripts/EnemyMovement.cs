using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f,5f)] float moveSpeed = 1f;
    Enemy enemy;

     void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        FindPath();
        RetunToStart();
        StartCoroutine(FollowPath());
    }

     void FindPath()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parent.transform)
        {
            path.Add(child.GetComponent<Waypoint>());  
        }
    }
    void RetunToStart()
    {
        transform.position = path[0].transform.position;
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
        enemy.StealGold();
        gameObject.SetActive(false);
        

    }
    
}
