using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] 
    private float ScrollSpeed = 10;
    
    private Camera Zoomcamera;
    // Start is called before the first frame update
    void Start()
    {
        Zoomcamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Zoomcamera.orthographic)
        {
            Zoomcamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        }
        else
        {
            Zoomcamera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        }
    }

}
