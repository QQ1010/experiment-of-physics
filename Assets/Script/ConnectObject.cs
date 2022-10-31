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
    GameObject ToolBar;
    GameObject Canvas;
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    void DrawLine(Vector3 start, Vector3 end)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        // Edit->ProjectSettings->Graphics 在Always Included Shaders中，更改size，并將所需用到的Shader拖入其中
        lr.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply")); 
        lr.startColor = Color.red;
        lr.endColor = Color.red;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine,0.1f);
    }

    void OnMouseDown()
    {
        SpriteRenderer[] s_list = GetComponentsInChildren<SpriteRenderer>();
        transform.position = new Vector3(transform.position.x, transform.position.y);
        ScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;
        start_point = new Vector3(transform.position.x, transform.position.y);
    }

    void OnMouseDrag()
    {
        Vector3 CurScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector3 CurPosition = Camera.main.ScreenToWorldPoint(CurScreenPoint) + offset;
        end_point = new Vector3(CurPosition.x, CurPosition.y);
        DrawLine(start_point, end_point);
    }
}
