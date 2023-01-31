using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WireBManager : ElectronicComponent
{
    public float length;
    [SerializeField] private float resistance_;
    [SerializeField] private GameObject pin1, pin2;
    void Start()
    {
        //tool_type = ToolType.WireB;
        resistance = resistance_;
    }
    public void OnMouseDrag()
    {
        CircuitManager cm = CircuitManager.instanse;
        GameObject gaussmeter_o;
        ElectronicComponent gaussmeter = null;
        try
        {
            gaussmeter_o = cm.tools.Find(obj => obj.GetComponent<ElectronicComponent>().tool_type == ToolType.Gaussmeter);
            if (gaussmeter_o != null)
            {
                gaussmeter = gaussmeter_o.GetComponent<ElectronicComponent>();
                gaussmeter.gameObject.GetComponent<GaussmeterManager>().CaculateGauss();
            }
        }
        catch (Exception ex) { }
    }
    public void ShowPin()
    {
        pin1.SetActive(true);
        pin2.SetActive(true);
    }
    public void UnShowPin()
    {
        pin1.SetActive(false);
        pin2.SetActive(false);
    }
    public override bool CheckPlace(bool from, bool to, ElectronicComponent component)
    {
        print(component);
        if (positives.Count > 1 || negetives.Count > 1)
        {
            return false;
        }
        if (from)
        {
            switch (component.tool_type)
            {
                case ToolType.Resistor:
                    //if (reverse == true)
                    //{
                    //    if (to) return true;
                    //}
                    //else if (!to) return true;
                    return true;
                    //break;
                case ToolType.Voltmeter:
                    if (!to) return true;
                    break;
                case ToolType.Ammeter:
                    if (!to) return true;
                    break;
                case ToolType.PowerSupply:
                    if (to) return true;
                    break;
                case ToolType.WireA:
                    //if (!to)
                    //{
                    //    component.reverse = false;
                    //    reverse = false;
                    //}
                    //if (to)
                    //{
                    //    component.reverse = true;
                    //    reverse = true;
                    //}
                    return true;
            }
        }
        else if (!from)
        {
            switch (component.tool_type)
            {
                case ToolType.Resistor:
                    //if (reverse == true)
                    //{
                    //    if (!to) return true;
                    //}
                    //else if (to) return true;
                    //break;
                    return true;
                case ToolType.Voltmeter:
                    if (to) return true;
                    break;
                case ToolType.Ammeter:
                    if (to) return true;
                    break;
                case ToolType.PowerSupply:
                    if (!to) return true;
                    break;
                case ToolType.WireA:
                    //if (!to)
                    //{
                    //    component.reverse = true;
                    //    reverse = true;
                    //    print("change = " + reverse);
                    //}
                    //if (to)
                    //{
                    //    component.reverse = false;
                    //    reverse = false;
                    //}
                    return true;
            }
        }
        return false;
    }
}
