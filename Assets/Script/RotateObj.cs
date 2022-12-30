using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class RotateObj : MonoBehaviour
{
    bool rotate;
    bool button1;
    bool button2;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, -1); ;
            if (hit.collider)
            {
                print(hit.transform.name);
                if (hit.transform.name == "RulerRotate1")
                {
                    button1 = true;
                    button2 = false;
                    rotate = true;
                }
                else if (hit.transform.name == "RulerRotate2")
                {
                    button2 = true;
                    button1 = false;
                    rotate = true;
                }
            }
        }
        else if(Input.GetMouseButton(0))
        {
            if (rotate && button1)
            {
                Vector3 mouse = Input.mousePosition;
                Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 direction = mouse - obj;
                direction.z = 0f;
                direction = direction.normalized;
                transform.up = direction;
            }
            else if(rotate && button2)
            {
                Vector3 mouse = Input.mousePosition;
                Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 direction = obj - mouse;
                direction.z = 0f;
                direction = direction.normalized;
                transform.up = direction;
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            rotate = false;
        }
    }
}