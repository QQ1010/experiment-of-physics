using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowRotation : MonoBehaviour
{
    public TMP_Text rotation_text;
    void Start()
    {
        UpdateText();
    }
    public void OnMouseDrag()
    {
        UpdateText();
    }
    void UpdateText()
    {
        float z = transform.eulerAngles.z;
        print("z:"+z);
        if(z < 0) z += 360.0f;
        if(z >= 360) z -= 360.0f;
        rotation_text.text = z.ToString("0.0°");
    }
}
