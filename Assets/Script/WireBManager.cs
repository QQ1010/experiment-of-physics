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
    public override bool CheckPlace()
    {
        if (positives.Count > 1 || negetives.Count > 1)
        {
            return false;
        }
        if (positives.Count == 1)
        {
            ElectronicComponent pos = positives[0];
            switch (pos.tool_type)
            {
                case ToolType.PowerSupply:
                    return false;
                case ToolType.Voltmeter:
                    return false;
                case ToolType.Ruler:
                    return false;
                case ToolType.Gaussmeter:
                    return false;
                case ToolType.WireB:
                    return false;
                case ToolType.WireA:
                    return false;
            }
        }
        if (negetives.Count == 1)
        {
            ElectronicComponent neg = negetives[0];
            switch (neg.tool_type)
            {
                case ToolType.PowerSupply:
                    return false;
                case ToolType.Voltmeter:
                    return false;
                case ToolType.Ruler:
                    return false;
                case ToolType.Gaussmeter:
                    return false;
                case ToolType.WireB:
                    return false;
                case ToolType.WireA:
                    return false;
            }
        }
        return true;
        // check when to return true when to return false
    }
}
