using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VoltmeterManager : ElectronicComponent
{
    void Start()
    {
        tool_type = ToolType.Voltmeter;
    }
    public override bool CheckPlace(bool from, bool to, ElectronicComponent component)
    {
        if (from)
        {
            switch (component.tool_type)
            {
                case ToolType.Resistor:
                    if (to) return true;
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
                    if (!to) return true;
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
                case ToolType.WireB:
                    if (to) return true;
                    break;
            }
        }
        return false;
        
    }
}
