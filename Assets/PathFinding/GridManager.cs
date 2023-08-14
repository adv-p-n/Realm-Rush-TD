using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    [Tooltip("Unity Grid size should match unity editor snap setting")]
    [SerializeField] int unityGridSize;
    Dictionary<Vector2Int,Node> grid = new Dictionary<Vector2Int,Node>();
    public Dictionary<Vector2Int,Node> Grid { get { return grid; } }

    public void BlockNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = false;
        }
    }
    public Vector2Int GetCoordinatesFormWorldPosistion(Vector3 position)
    {
        Vector2Int coordinates= new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);

        return coordinates;
    }

    public Vector3 GetWorldPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = coordinates.x * unityGridSize;
        position.z = coordinates.y * unityGridSize;

        return position;
    }

     void Awake()
    {
        CreateGrid();
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            return grid[coordinates];
        }
        return null;
    }

     void CreateGrid()
    {
        for(int x=0;x<gridSize.x;x++)
        {
            for(int y=0;y<gridSize.y;y++)
            {
                Vector2Int coodinates= new Vector2Int(x,y);
                grid.Add(coodinates,new Node(coodinates, true));
                
            }
        }
    }
}
