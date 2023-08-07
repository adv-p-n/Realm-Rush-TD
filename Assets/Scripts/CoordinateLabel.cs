using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabel : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates=new Vector2Int();
    void Awake()
    {
        label= GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying) 
        {
            DisplayCoordinates();
            UpdateName();
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
