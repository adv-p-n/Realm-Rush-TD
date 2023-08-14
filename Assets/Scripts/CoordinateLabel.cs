using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabel : MonoBehaviour
{
    [SerializeField] Color defaultColor= Color.white;
    [SerializeField] Color isBlockedColor = Color.gray;
    [SerializeField] Color isExploredColor = Color.yellow;
    [SerializeField] Color isPathColor =new Color(1f,0f,0.5f);
    TextMeshPro label;
    Vector2Int coordinates=new Vector2Int();
    GridManager gridManager;
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label= GetComponent<TextMeshPro>();
        label.enabled = true;
        DisplayCoordinates();

    }

    void Update()
    {
        if (!Application.isPlaying) 
        {
            DisplayCoordinates();
            UpdateName();
            
        }
        ColorCoordinates();
        ToggleLables();
    }

     void ToggleLables()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled= !label.enabled;
        }
    }

    void ColorCoordinates()
    {
        if(gridManager== null) { return; }
        Node node= gridManager.GetNode(coordinates);

        if (node == null) { return; }
        if(!node.isWalkable)
        {
            label.color = isBlockedColor;
        }
        else if(node.isPath)
        {
            label.color = isPathColor;
        }
        else if (node.isExplored)
        {
            label.color = isExploredColor;
        }
        else
        {
            label.color = defaultColor;
        }

    }

    void UpdateName()
    {
        transform.parent.name = ($"({coordinates.x},{coordinates.y})");
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = ($"({coordinates.x},{coordinates.y})");
    }
}
