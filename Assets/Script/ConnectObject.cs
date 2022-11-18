using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConnectObject : MonoBehaviour
{
    Vector3 start_point;
    Vector3 end_point;
    Vector3 ScreenPoint;
    Vector3 offset;
    List<GameObject> myLineList;
    GameObject ToolbarManager;
    GameObject line;
    LineRenderer lr;
    void Start()
    {
        myLineList = new List<GameObject>();
        ToolbarManager = GameObject.Find("Tool");
        //Fetch the Event System from the Scene
    }
    void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        //set the line position
        lr.startColor = color;
        lr.endColor = color;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }

    void OnMouseDown()
    {
        // create a line gameobject and get the LineRenderer
        line = new GameObject();
        line.AddComponent<LineRenderer>();
        lr = line.GetComponent<LineRenderer>();
        // Edit->ProjectSettings->Graphics 在Always Included Shaders中，更改size，并將所需用到的Shader拖入其中
        lr.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
        // set line renderer's setting
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        // get the object position
        transform.position = new Vector3(transform.position.x, transform.position.y);
        ScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        // set start point position
        start_point = new Vector3(transform.position.x, transform.position.y);
        line.transform.position = start_point;
        // add the line into myLineList
        myLineList.Add(line);
        line.transform.SetParent(ToolbarManager.transform);
    }

    void OnMouseDrag()
    {
        // get the screen 
        Vector3 CurScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector3 CurPosition = Camera.main.ScreenToWorldPoint(CurScreenPoint) + offset;
        end_point = new Vector3(CurPosition.x, CurPosition.y);
        // draw line from start point to end point
        if(gameObject.tag == "negative")
        {
            DrawLine(start_point, end_point, Color.black);
        }
        else if(gameObject.tag == "positive")
        {
            DrawLine(start_point, end_point, Color.red);
        }
        
    }

    void OnMouseUp()
    {
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if(hits.Length == 0)
        {
            myLineList.Remove(line);
            Destroy(line);
        }
        foreach (RaycastHit2D hit in hits)
        {
            print("Hit:" + hit.transform.gameObject.name);
            end_point = new Vector3(hit.transform.position.x, hit.transform.position.y);
        }
        if (gameObject.tag == "negative")
        {
            DrawLine(start_point, end_point, Color.black);
        }
        else if (gameObject.tag == "positive")
        {
            DrawLine(start_point, end_point, Color.red);
        }
        return;
    }
}
