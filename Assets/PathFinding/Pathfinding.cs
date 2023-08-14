using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    [SerializeField] Node currentNode;
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
        SearchForNeighbour();

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

                //removeeeeee
                grid[nodeToCheck].isExplored = true;
                grid[currentNode.coordinates].isPath= true;
            }
        }
    }
}
