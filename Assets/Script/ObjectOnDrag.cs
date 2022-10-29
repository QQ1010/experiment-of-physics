using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ObjectOnDrag : MonoBehaviour
{
    Vector3 ScreenPoint;
    Vector3 offset;
    // Queue<SpriteRenderer> LastOnFocusSpriteRenderers;
    GameObject ToolBar;
    GameObject Canvas;
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("UI Canvas");
        m_Raycaster = Canvas.GetComponent<GraphicRaycaster>();
        // ToolBar = GameObject.FindGameObjectsWithTag("ToolBar")[0];
        // m_Raycaster = ToolBar.GetComponentInParent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }
    public void OnMouseDown()
    {
        SpriteRenderer[] s_list = GetComponentsInChildren<SpriteRenderer>();
        //Reset Lost Focuses Object
        // while (LastOnFocusSpriteRenderers.Count > 0)
        // {
        //     // Debug.Log(LastOnFocusSpriteRenderers.Count);
        //     SpriteRenderer s = LastOnFocusSpriteRenderers.Dequeue();
        //     if (s != null)
        //     {
        //         s.sortingLayerName = "Default";
        //     }

        // }
        // foreach (SpriteRenderer s in s_list)
        // {
        //     s.sortingLayerName = "On Focus";
        //     LastOnFocusSpriteRenderers.Enqueue(s);
        // }
        transform.position = new Vector3(transform.position.x, transform.position.y);
        ScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;
    }
    public void OnMouseDrag()
    {
            
        Vector3 CurScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector3 CurPosition = Camera.main.ScreenToWorldPoint(CurScreenPoint) + offset;
        CurPosition.z = 0;
        transform.position = CurPosition;
    }
    public void OnMouseUp()
    {
        m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the game object
        m_PointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);
        if(results.Count == 0) return;
        //bool is_delete = false;
        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            //Debug.Log("Hit " + result.gameObject.name);
            //Debug.Log("Hit " + result.gameObject.tag);
            if (result.gameObject.tag == "ToolBar")
            {
                Destroy(gameObject);
                // LastOnFocusSpriteRenderers.Clear();
                break;
            }
        }
    }

}