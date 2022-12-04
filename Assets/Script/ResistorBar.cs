using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistorBar : MonoBehaviour
{
    [SerializeField] float bar_offset = 3.6f;
    Vector3 ScreenPoint;
    Vector3 offset;
    ResistorManager resistor_;
    void Start()
    {
        resistor_ = gameObject.GetComponentInParent<ResistorManager>();
    }
    void OnMouseDown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y);
        ScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
    }
    void OnMouseDrag()
    {
        Vector3 CurScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector3 CurPosition = Camera.main.ScreenToWorldPoint(CurScreenPoint) + offset;
        CurPosition.x = transform.position.x;
        CurPosition.z = 0;
        transform.position = CurPosition;
        if(transform.localPosition.y > bar_offset) 
            transform.localPosition = new Vector3(transform.localPosition.x, bar_offset , transform.localPosition.z);
        else if(transform.localPosition.y < -bar_offset) 
            transform.localPosition = new Vector3(transform.localPosition.x, -bar_offset, transform.localPosition.z);
        resistor_.resistance = resistor_.min_resistance + (resistor_.max_resistance - resistor_.min_resistance) * (transform.localPosition.y + bar_offset) / (2 * bar_offset);
        CircuitManager.CircuitUpdate();
    }
}
