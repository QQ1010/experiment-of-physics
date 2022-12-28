using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] 
    private float ScrollSpeed = 10;
    private float CameraSpeed_X = 0.5f;
    private float CameraSpeed_Y = 0.5f;
    private Camera Zoomcamera;
    Vector3 Origin = new Vector3(0,1,-10);
    
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
            if (Zoomcamera.orthographicSize < 1)
                Zoomcamera.orthographicSize = 1;
        }
        else
        {
            Zoomcamera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        }
        if(Input.GetMouseButton(1)) {
            float dx = Input.GetAxis("Mouse X") * CameraSpeed_X;
            float dy = Input.GetAxis("Mouse Y") * CameraSpeed_Y;
            transform.position -= new Vector3(dx, dy, 0);

        }
    }

}
