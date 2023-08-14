using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int endCoordinates;

    Node startNode;
    Node endNode;
    Node currentNode;

    Dictionary<Vector2Int, Node> reached =new Dictionary<Vector2Int,Node>();
    Queue<Node> queue = new Queue<Node>();

    Vector2Int[] directions = {Vector2Int.right,Vector2Int.left,Vector2Int.up,Vector2Int.down};
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid;

     void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if(gridManager!=null) 
        { grid=gridManager.Grid; }
        
        
    }
    void Start()
    {
        startNode = gridManager.GetNode(startCoordinates);
        endNode = gridManager.GetNode(endCoordinates);

        BreadthFirstSearch();
        Path();

    }

     void SearchForNeighbour()
    {
        List<Node> neighbourNodes= new List<Node>();
       
        foreach (Vector2Int direction in directions)
        {
            Vector2Int nodeToCheck = currentNode.coordinates + direction;
            if (grid.ContainsKey(nodeToCheck))
            {
                neighbourNodes.Add(grid[nodeToCheck]);
            }
        }
        foreach(Node neighbour in neighbourNodes)
        {
            if (!reached.ContainsKey(neighbour.coordinates) && neighbour.isWalkable)
            {
                neighbour.isConnected = currentNode;
                queue.Enqueue(neighbour);
                reached.Add(neighbour.coordinates, neighbour);
            }
        }
    }

    void BreadthFirstSearch()
    {
        bool isRunning = true;
        currentNode = startNode;
        reached.Add(startCoordinates, currentNode);
        queue.Enqueue(currentNode);

        while(isRunning && queue.Count>0)
        {
            currentNode= queue.Dequeue();
            currentNode.isExplored = true;
            if (currentNode.coordinates == endNode.coordinates)
            {
                isRunning = false;
            }
            SearchForNeighbour();
            
        }
    }
    List<Node> Path()
    {
        List<Node> path = new List<Node>();
        currentNode = endNode;

        while (currentNode.isConnected != null)
        {
            path.Add(currentNode);
            currentNode.isPath = true;
            currentNode = currentNode.isConnected;
        }
        path.Reverse();
        return path;
    }
}
