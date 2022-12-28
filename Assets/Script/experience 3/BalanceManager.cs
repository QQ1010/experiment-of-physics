using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BalanceManager : MonoBehaviour
{
    public const float PI = 3.1415926535897931f;
    public const float G = 9.8f;
    public float balance_weight = 0.0f;
    public float weight = 0.0f;
    public float min_rotation;
    public float max_rotation;
    public float frame_length;
    public float scale = 0.0001f;
    public float v = 0.10f;
    public float f = 0.995f;
    public WireManager wireA;
    public WireManager wireB;

    public GameObject item1;
    public GameObject item2;
    public float item1_weight;
    public float item2_weight;
    void Update()
    {
        float d = (wireB.transform.position.y - wireA.transform.position.y) * 2.5f;
        wireA.force = wireA.ampere * wireB.ampere * (float)(4 * PI * 1e-1 /(4 * PI * d * d)) * wireA.length;
        // wireB.force = -wireA.force;
        float current_angleX = transform.localRotation.eulerAngles.x;
        if(current_angleX > 180) {
            current_angleX =  current_angleX - 360;
        }
        // // print(wireA.force + " " + (wireB.mass / 1000 * G));
        // print(Mathf.Cos(current_angleX * PI /180));
        // float F = wireA.force - (wireB.mass * G * Math.Abs(Mathf.Sin(current_angleX * PI /180))) + (balance_weight * G * Math.Abs(Mathf.Cos(current_angleX * PI /180)));
        // // float F = wireA.force - (wireB.mass / 1000 * G * Math.Abs(Mathf.Sin(current_angleX * PI /180)));
        // float a = (F / wireB.mass);
        // v = (float)Math.Round((v + a) * f, 4);
        // float omega = v / frame_length;
        // // print(omega);
        // // print("x: " + transform.rotation.x);
        // float delta_angle = omega * Time.deltaTime * scale;
        // // print(transform.localRotation.eulerAngles.x);

        // if(current_angleX + delta_angle >= min_rotation && current_angleX + delta_angle <= max_rotation)
        //     transform.Rotate(new Vector3(delta_angle, 0, 0));
        // else 
        // {
        //     print("over angle");
        //     if(current_angleX > 0) {
        //         transform.localRotation = Quaternion.Euler(new Vector3(max_rotation, 0, 0));
        //         v = 0;
        //     }
        //     else {
        //         transform.localRotation = Quaternion.Euler(new Vector3(min_rotation, 0, 0));
        //         v = 0;
        //     }
        // }
        if(wireA.force < weight) {
            if(current_angleX > min_rotation)
                transform.Rotate(new Vector3(-v, 0, 0));
            else
                transform.localRotation = Quaternion.Euler(new Vector3(min_rotation, 0, 0));
        }
        else if(wireA.force == weight) {
            print("zero");
            if(current_angleX > 0.05)
                transform.Rotate(new Vector3(-v, 0, 0));
            else if(current_angleX < 0.05)
                transform.Rotate(new Vector3(v, 0, 0));
            else
                transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
        else {
            if(current_angleX < max_rotation)
                transform.Rotate(new Vector3(v, 0, 0));
            else
                transform.localRotation = Quaternion.Euler(new Vector3(max_rotation, 0, 0));
            
        }
    }

    public void SwitchItem(int index) {
        if(index == 1) {
            item1.gameObject.SetActive(!item1.activeSelf);
            item2.gameObject.SetActive(false);
            weight = (item1.activeSelf) ? item1_weight : 0;
        }
        else if(index == 2) {
            item1.gameObject.SetActive(false);
            item2.gameObject.SetActive(!item2.activeSelf);
            weight = (item2.activeSelf) ? item2_weight : 0;
        }
    }
}
