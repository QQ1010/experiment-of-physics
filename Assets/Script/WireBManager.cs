using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireBManager : ElectronicComponent
{
    void Start()
    {
        tool_type = ToolType.WireB;
        resistance = 0.0008f;
    }
    public void OnMouseDrag()
    {
        CircuitManager cm = CircuitManager.instanse;
        GameObject gaussmeter_o;
        ElectronicComponent gaussmeter = null;
        gaussmeter_o = cm.tools.Find(obj => obj.GetComponent<ElectronicComponent>().tool_type == ToolType.Gaussmeter);
        if (gaussmeter_o != null)
        {
            gaussmeter = gaussmeter_o.GetComponent<ElectronicComponent>();
            gaussmeter.gameObject.GetComponent<GaussmeterManager>().CaculateGauss();
        }
    }
    public override bool CheckPlace(bool from, bool to, ElectronicComponent component)
    {
        if (positives.Count > 1 || negetives.Count > 1)
        {
            return false;
        }
        if (from)
        {
            switch (component.tool_type)
            {
                case ToolType.Resistor:
                    if (!to) return true;
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
                    if (!to) return true;
                    break;
            }
        }
        else if (!from)
        {
            switch (component.tool_type)
            {
                case ToolType.Resistor:
                    if (to) return true;
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
                    if (to) return true;
                    break;
            }
        }
        return false;
    }
}
