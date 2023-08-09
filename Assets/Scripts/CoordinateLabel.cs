using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabel : MonoBehaviour
{
    [SerializeField] Color defaultColor= Color.white;
    [SerializeField] Color inactiveColor = Color.gray;
    TextMeshPro label;
    Vector2Int coordinates=new Vector2Int();
    Waypoint waypoint;
    void Awake()
    {
        waypoint=GetComponentInParent<Waypoint>();
        label= GetComponent<TextMeshPro>();
        label.enabled = false;
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
        if (waypoint.IsPlaceable) { label.color = defaultColor; }
        else { label.color = inactiveColor; }
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
