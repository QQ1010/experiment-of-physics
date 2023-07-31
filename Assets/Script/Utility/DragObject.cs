using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum DragMode {
    Move,
    LockX,
    LockY,
    Rotate,
}

public class DragObject : MonoBehaviour
{
    Vector3 StartPoint;
    Vector3 ScreenPoint;
    Vector3 offset;
    // Queue<SpriteRenderer> LastOnFocusSpriteRenderers;
    GameObject ToolBar;
    GameObject Canvas;
    public GameObject drag_target_;
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    public DragMode mode = DragMode.Move;
    public Transform lock_pivot = null;
    public float move_begin = 0.0f;
    public float move_end = 0.0f;
    float start_degree;
    // public Transform rotate_center;
    void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("UI Canvas");
        m_Raycaster = Canvas.GetComponent<GraphicRaycaster>();
        if(move_end < move_begin) (move_begin, move_end) = (move_end, move_begin);
        // ToolBar = GameObject.FindGameObjectsWithTag("ToolBar")[0];
        // m_Raycaster = ToolBar.GetComponentInParent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        // m_EventSystem = GetComponent<EventSystem>();
    }
    public void OnMouseDown()
    {
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
        drag_target_.transform.position = new Vector3(drag_target_.transform.position.x, drag_target_.transform.position.y);
        ScreenPoint = Camera.main.WorldToScreenPoint(drag_target_.transform.position);
        StartPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        offset = drag_target_.transform.position - Camera.main.ScreenToWorldPoint(StartPoint);
        start_degree = drag_target_.transform.rotation.eulerAngles.z;
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;
        // Set line render start and end position

    }
    public void OnMouseDrag()
    {
        Vector3 CurScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector3 CurPosition = Camera.main.ScreenToWorldPoint(CurScreenPoint) + offset;
        CurPosition.z = drag_target_.transform.position.z;
        switch(mode) {
            case DragMode.Move:
                drag_target_.transform.position = CurPosition;
                break;
            case DragMode.LockX:
                CurPosition.x = drag_target_.transform.position.x;
                if(lock_pivot){
                    if(CurPosition.y - lock_pivot.position.y < move_begin) CurPosition.y = lock_pivot.position.y + move_begin;
                    if(CurPosition.y - lock_pivot.position.y > move_end) CurPosition.y = lock_pivot.position.y + move_end;
                }
                else{
                    if(CurPosition.y < move_begin) CurPosition.y = move_begin;
                    if(CurPosition.y > move_end) CurPosition.y = move_end;
                }
                drag_target_.transform.position = CurPosition;
                break;
            case DragMode.LockY:
                CurPosition.y = drag_target_.transform.position.y;
                if(lock_pivot){
                    if(CurPosition.x - lock_pivot.position.x < move_begin) CurPosition.x = lock_pivot.position.x + move_begin;
                    if(CurPosition.x - lock_pivot.position.x > move_end) CurPosition.x = lock_pivot.position.x + move_end;
                }
                else{
                    if(CurPosition.x < move_begin) CurPosition.x = move_begin;
                    if(CurPosition.x > move_end) CurPosition.x = move_end;
                }
                drag_target_.transform.position = CurPosition;
                break;
            case DragMode.Rotate:
                Vector2 a = Camera.main.ScreenToWorldPoint(CurScreenPoint) - drag_target_.transform.position;
                // Vector2 b = Camera.main.ScreenToWorldPoint(StartPoint) - drag_target_.transform.position;
                Vector2 b = drag_target_.transform.rotation * Vector2.right;
                // print("a="+a);
                // print("b="+b);
                float degree = Vector2.SignedAngle(a, b);
                float to_rotate = drag_target_.transform.rotation.eulerAngles.z - degree - start_degree;
                
                // print("vector angle:" + degree);
                // print("to rotate:" + to_rotate);
                // drag_target_.transform.Rotate(new Vector3(0,0,-to_rotate));
                drag_target_.transform.Rotate(new Vector3(0,0,-degree));

            break;
        }
        
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
            //if (result.gameObject.tag == "ToolBar")
            //{
            //    CircuitManager.instanse.tools.Remove(gameObject);
            //    Destroy(gameObject);
            //    // LastOnFocusSpriteRenderers.Clear();
            //    break;
            //}
        }
    }

}