using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class ScaleManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI wegith_text;
    List<ElectronicComponent> items;
    List<Collider2D> items_collider;

    private void Start()
    {
        items_collider = new List<Collider2D>();
        items = new List<ElectronicComponent>();
    }
    void Update() {
        float total_mass = 0.0f;
        if (items.Count > 0)
        {
            foreach (ElectronicComponent e in items)
            {
                total_mass += e.mass + e.force;
            }
            if (total_mass < 0.0f)
                total_mass = 0.0f;
            wegith_text.text = Math.Round(total_mass, 3).ToString();
        }
        else
            wegith_text.text = "0.0";
    }
    private void OnTriggerEnter2D(Collider2D other) {
        try
        {
            ElectronicComponent item = other.GetComponent<ElectronicComponent>();
            if (item == null) return;
            items_collider.Add(other);
            items.Add(item);
            if (item.tool_type == ToolType.WireA)
            {
                item.gameObject.GetComponent<WireAManager>().UnShowPin();
            }
            else if (item.tool_type == ToolType.WireB)
            {
                item.gameObject.GetComponent<WireBManager>().UnShowPin();
            }
        }
        catch (Exception e) { }
    }
    private void OnTriggerExit2D(Collider2D other) {
        try
        {
            ElectronicComponent item = other.GetComponent<ElectronicComponent>();
            if (item == null) return;
            if (item.tool_type == ToolType.WireA)
            {
                item.gameObject.GetComponent<WireAManager>().ShowPin();
            }
            else if (item.tool_type == ToolType.WireB)
            {
                item.gameObject.GetComponent<WireBManager>().ShowPin();
            }
            items_collider.Remove(other);
            items.Remove(item);
        }
        catch (Exception e) { }
    }
}
