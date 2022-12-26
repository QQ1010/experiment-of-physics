using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BalanceManager : MonoBehaviour
{
    public const float PI = 3.1415926535897931f;
    public const float G = 9.8f;
    public float min_rotation;
    public float max_rotation;
    public float frame_length;
    public float scale = 0.0001f;
    public float v = 0.0f;
    public float f = 0.995f;
    public WireManager wireA;
    public WireManager wireB;
    void Update()
    {
        float d = (wireB.transform.position.y - wireA.transform.position.y) * 2.5f;
        float L = wireA.length;
        wireA.force = wireA.ampere * wireB.ampere * (float)(4 * PI * 1e-1 /(4 * PI * d * d)) * L;
        wireB.force = -wireA.force;
        float current_angleX = transform.localRotation.eulerAngles.x;
        if(current_angleX > 180) {
            current_angleX =  current_angleX - 360;
        }
        // print(wireA.force + " " + (wireB.mass / 1000 * G));
        print(Mathf.Cos(current_angleX * PI /180));
        float F = wireA.force - (wireB.mass / 1000 * G * Math.Abs(Mathf.Cos(current_angleX * PI /180)));
        float a = (F / wireB.mass);
        v = (v + a) * f;
        float omega = v / frame_length;
        // print(omega);
        // print("x: " + transform.rotation.x);
        float delta_angle = omega * Time.deltaTime * scale;
        // print(transform.localRotation.eulerAngles.x);

        if(current_angleX + delta_angle >= min_rotation && current_angleX + delta_angle <= max_rotation)
            transform.Rotate(new Vector3(delta_angle, 0, 0));
        else 
        {
            print("over angle");
            if(current_angleX > 0) {
                transform.localRotation = Quaternion.Euler(new Vector3(max_rotation, 0, 0));
                v = 0;
            }
            else {
                transform.localRotation = Quaternion.Euler(new Vector3(min_rotation, 0, 0));
                v = 0;
            }
        }
    }
}
