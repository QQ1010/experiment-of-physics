using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WireBManager : ElectronicComponent
{
    public float length;
    [SerializeField] private float resistance_;
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
    public override bool CheckPlace(bool from, bool to, ElectronicComponent component)
    {
        print(from);
        print(to);
        if (positives.Count > 1 || negetives.Count > 1)
        {
            return false;
        }
        if (from)
        {
            switch (component.tool_type)
            {
                case ToolType.Resistor:
                    if (reserve == true)
                    {
                        if (to) return true;
                    }
                    else if (!to) return true;
                    break;
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
                    if (!to)
                    {
                        component.reserve = false;
                        reserve = false;
                    }
                    if (to)
                    {
                        component.reserve = true;
                        reserve = true;
                    }
                    return true;
            }
        }
        else if (!from)
        {
            switch (component.tool_type)
            {
                case ToolType.Resistor:
                    if (reserve == true)
                    {
                        if (!to) return true;
                    }
                    else if (to) return true;
                    break;
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
                    if (!to)
                    {
                        component.reserve = true;
                        reserve = true;
                    }
                    if (to)
                    {
                        component.reserve = false;
                        reserve = false;
                    }
                    return true;
            }
        }
        return false;
    }
}
