using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    [SerializeField] Tower tower;

    GridManager gridManager;
    Pathfinding pathfinding;
    Vector2Int coordinates;

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinding= FindObjectOfType<Pathfinding>();
    }
     void Start()
    {
        BlockTiles();
    }

     void BlockTiles()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFormWorldPosistion(transform.position);
            if (!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    private void OnMouseDown()
    {
        if (gridManager.GetNode(coordinates).isWalkable && !pathfinding.WillBlockPath(coordinates))
        {
            bool isPlaced = tower.PlaceTower(tower,transform);
            isPlaceable= !isPlaced;
            gridManager.BlockNode(coordinates);
        }
    }
}
