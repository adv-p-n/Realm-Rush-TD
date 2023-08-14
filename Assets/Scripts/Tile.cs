using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    [SerializeField] Tower tower;

    GridManager gridManager;
    Vector2Int coordinates;

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
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
        if (isPlaceable)
        {
            bool isPlaced = tower.PlaceTower(tower,transform);
            isPlaceable= !isPlaced;
        }
    }
}
