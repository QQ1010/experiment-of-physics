using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public float volume = 0f;
    private void Awake() {
        instance = this;    
    }

    void Update()
    {
        print("Volume: " + volume);
    }
}
