using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireAManager : ElectronicComponent
{
    void Start()
    {
        tool_type = ToolType.WireA;
        // TODO: modify different materials shoulld have different resister
    }
    public override bool CheckPlace()
    {
        if(positives.Count > 1 || negetives.Count > 1)
        {
            return false;
        }
        if(positives.Count == 1)
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
        if(negetives.Count == 1)
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
