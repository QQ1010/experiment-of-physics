using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class ScaleManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI wegith_text;
    ElectronicComponent item = null;
    Collider2D item_collider = null;

    void Update() {
        if(item != null)
            wegith_text.text = Math.Round(item.mass + item.force, 3).ToString();
        else
            wegith_text.text = "0.0";
    }
    private void OnTriggerEnter2D(Collider2D other) {
        item_collider = other;
        item = item_collider.GetComponent<ElectronicComponent>();
        if(item.tool_type == ToolType.WireA)
        {
            item.gameObject.GetComponent<WireAManager>().UnShowPin();
        }
        else if(item.tool_type == ToolType.WireB)
        {
            item.gameObject.GetComponent<WireBManager>().UnShowPin();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (item.tool_type == ToolType.WireA)
        {
            item.gameObject.GetComponent<WireAManager>().ShowPin();
        }
        else if (item.tool_type == ToolType.WireB)
        {
            item.gameObject.GetComponent<WireBManager>().ShowPin();
        }
        item_collider = null;
        item = null;
    }
}
