using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmeterManager : ElectronicComponent
{
    void Start()
    {
        tool_type = ToolType.Ammeter;
    }
    public override bool CheckPlace(bool from, bool to, ElectronicComponent component)
    {
        // check when can connect => list false situation
        if (positives.Count > 1 || negetives.Count > 1)
        {
            return false;
        }
        if(from)
        {
            switch (component.tool_type)
            {
                case ToolType.Resistor:
                    if (!to) return true;
                    break;
                case ToolType.Voltmeter:
                    if (!to) return true;
                    break;
                case ToolType.PowerSupply:
                    if (to) return true;
                    break;
                case ToolType.WireA:
                    if (!to) return true;
                    break;
                case ToolType.WireB:
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
                case ToolType.PowerSupply:
                    if (!to) return true;
                    break;
                case ToolType.WireA:
                    if (to) return true;
                    break;
                case ToolType.WireB:
                    if (to) return true;
                    break;
            }
        }
        return false;
    }
}
