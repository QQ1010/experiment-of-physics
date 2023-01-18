using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistorBar : MonoBehaviour
{
    [SerializeField] float bar_offset = 3.6f;
    Vector3 ScreenPoint;
    Vector3 offset;
    ResistorManager resistor_;
    public bool rightup_node;
    public bool leftup_node;
    public bool rightdown_node;
    public bool leftdown_node;
    bool hold = false;
    void Start()
    {
        resistor_ = gameObject.GetComponentInParent<ResistorManager>();
        
    }
    void Update() {
        rightup_node = resistor_.rightup_node.GetComponent<ConnectObject>().countLine() > 0;
        leftup_node = resistor_.leftup_node.GetComponent<ConnectObject>().countLine() > 0;
        rightdown_node = resistor_.rightdown_node.GetComponent<ConnectObject>().countLine() > 0;
        leftdown_node = resistor_.leftdown_node.GetComponent<ConnectObject>().countLine() > 0;
    }
    void OnMouseDown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y);
        ScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        hold = true;
    }
    void OnMouseUp() {
        hold = false;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.white;
    }
    void OnMouseEnter() {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.yellow;
    }
    private void OnMouseExit() {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(!hold)
            sprite.color = Color.white;
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
        if(rightup_node && leftdown_node){
            resistor_.resistance = resistor_.min_resistance + (resistor_.max_resistance - resistor_.min_resistance) * (transform.localPosition.y + bar_offset) / (2 * bar_offset);
        }
        else if(rightdown_node && leftup_node){
            resistor_.resistance = resistor_.min_resistance + (resistor_.max_resistance - resistor_.min_resistance) * (bar_offset - transform.localPosition.y) / (2 * bar_offset);
        }
        else if(rightup_node && leftup_node) {
            resistor_.resistance = resistor_.min_resistance;
        }
        else if(rightdown_node && leftdown_node) {
            resistor_.resistance = resistor_.max_resistance;
        }
        CircuitManager.CircuitUpdate();
    }
}
