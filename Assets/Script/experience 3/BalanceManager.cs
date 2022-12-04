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
        print(wireA.force + " " + (wireB.mass / 1000 * G));
        float F = wireA.force - (wireB.mass / 1000 * G);
        float v = (F / wireB.mass);
        float omega = v / frame_length;
        // print(omega);
        // print("x: " + transform.rotation.x);
        if(transform.rotation.x > min_rotation && transform.rotation.x < max_rotation)
            transform.Rotate(new Vector3(omega * Time.deltaTime * scale, 0, 0));
        else 
        {
            print("over angle");
            transform.Rotate(Vector3.zero);
        }
    }
}
