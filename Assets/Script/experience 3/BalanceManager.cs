using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceManager : MonoBehaviour
{
    public const float PI = 3.1415926535897931f;
    public const float G = 9.8f;
    public float min_rotation;
    public float max_rotation;
    public float frame_length;
    public float scale = 0.0001f;
    public WireManager wireA;
    public WireManager wireB;
    void Update()
    {
        float d = (wireB.transform.position.y - wireA.transform.position.y) * 2.5f;
        float L = wireA.length;
        wireA.force = wireA.ampere * wireB.ampere * (float)(4 * PI * 1e-1 /(4 * PI * d * d)) * L;
        wireB.force = -wireA.force;
        // print(wireA.force + " " + (wireB.mass / 1000 * G));
        float F = wireA.force - (wireB.mass / 1000 * G);
        float v = (F / wireB.mass);
        float omega = v / frame_length;
        // print(omega);
        // print("x: " + transform.rotation.x);
        float delta_angle = omega * Time.deltaTime * scale;
        float current_angleX = transform.localRotation.eulerAngles.x;
        if(current_angleX > 180) {
            current_angleX =  current_angleX - 360;
        }
        print(transform.localRotation.eulerAngles.x);

        if(current_angleX + delta_angle >= min_rotation && current_angleX + delta_angle <= max_rotation)
            transform.Rotate(new Vector3(delta_angle, 0, 0));
        else 
        {
            print("over angle");
            if(current_angleX > 0) {
                transform.localRotation = Quaternion.Euler(new Vector3(max_rotation, 0, 0));
            }
            else {
                transform.localRotation = Quaternion.Euler(new Vector3(min_rotation, 0, 0));
            }
        }
    }
}
