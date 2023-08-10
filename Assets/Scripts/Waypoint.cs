using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    [SerializeField] Tower tower;


    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = tower.PlaceTower(tower,transform);
            isPlaceable= !isPlaced;
            //Debug.Log(transform.name);

        }
    }
}
