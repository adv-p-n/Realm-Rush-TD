using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Node> path = new List<Node>();
    [SerializeField] [Range(0f,5f)] float moveSpeed = 1f;
    Enemy enemy;
    GridManager gridManager;
    Pathfinding pathfinding;

     void Awake()
    {
        enemy = GetComponent<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathfinding = FindObjectOfType<Pathfinding>();

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
        path = pathfinding.GetPath();
    }
    void RetunToStart()
    {
        transform.position = gridManager.GetWorldPositionFromCoordinates(pathfinding.StartCoordinates);
    }

    IEnumerator FollowPath()
    {
        for(int i=0; i<path.Count; i++)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = gridManager.GetWorldPositionFromCoordinates(path[i].coordinates);
            float movePercent = 0f;

            transform.LookAt(endPos);

            while (movePercent < 1f)
            {
                movePercent += Time.deltaTime * moveSpeed;
                transform.position = Vector3.Lerp(startPos, endPos, movePercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }

     void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
}
