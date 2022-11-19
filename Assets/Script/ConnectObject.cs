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
    Vector3[] line_positions = new Vector3[397];
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
    public void FixLine()
    {
        //print(myLineList.Count);
        foreach (GameObject line_object in myLineList)
        {
            LineRenderer line = line_object.GetComponent<LineRenderer>();
            var numberOfPositions = line.GetPositions(line_positions);
            //print(line_positions[0]); // start position
            //print(line_positions[1]); // end position
            //print(transform.position); // object postition
            //print(line.startColor);
            if(Math.Abs(line_positions[0].x - transform.position.x) + Math.Abs(line_positions[0].y - transform.position.y) > 1)
            {
                start_point = line_positions[1];
                end_point = line_positions[0];
                line.SetPosition(0, start_point);
                line.SetPosition(1, end_point);
            }
        }
    }
    public void UpdateConnection(Vector3 newpos)
    {
        foreach(GameObject line_object in myLineList)
        {
            LineRenderer line = line_object.GetComponent<LineRenderer>();
            line.SetPosition(0, newpos);
        }
    }
    public void Connect(GameObject line)
    {
        myLineList.Add(line);
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
        bool find = false;           // positive to positive and negative to negative
        hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if(hits.Length == 0)         // hit nothing
        {
            myLineList.Remove(line);
            Destroy(line);
        }
        foreach (RaycastHit2D hit in hits)
        {
            print("Hit:" + hit.transform.gameObject.name);
            //print(hit.transform.tag);
            if(gameObject.tag == "negative")
            {
                if(hit.transform.tag == "negative")
                {
                    find = true;
                    hit.transform.gameObject.GetComponentInChildren<ConnectObject>().Connect(line);
                    end_point = new Vector3(hit.transform.position.x, hit.transform.position.y);
                    break;
                }
            }
            else if(gameObject.tag == "positive")
            {
                if(hit.transform.tag == "positive")
                {
                    find = true;
                    hit.transform.gameObject.GetComponentInChildren<ConnectObject>().Connect(line);
                    end_point = new Vector3(hit.transform.position.x, hit.transform.position.y);
                    break;
                }
            }
        }
        if (gameObject.tag == "negative" & find)
        {
            DrawLine(start_point, end_point, Color.black);
        }
        else if (gameObject.tag == "positive" & find)
        {
            DrawLine(start_point, end_point, Color.red);
        }
        else
        {
            myLineList.Remove(line);
            Destroy(line);
        }
        return;
    }
}
