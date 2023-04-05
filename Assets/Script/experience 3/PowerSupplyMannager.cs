using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerSupplyMannager : ElectronicComponent
{
    public float unit = 0.5f;
    void Start()
    {
        tool_type = ToolType.PowerSupply;
    }
    public void IncreaseVoltage()
    {
        voltage += unit;
        CircuitManager.CircuitUpdate();
    }
    public void DecreaseVoltage()
    {
        voltage -= unit;
        CircuitManager.CircuitUpdate();
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
                case ToolType.Voltmeter:
                    if(to) return true;
                    break;
                case ToolType.Ammeter:
                    if(to) return true;
                    break;
                case ToolType.WireA:
                    return true;
                case ToolType.WireB:
                    return true;
            }
        }
        else if (!from)
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
                case ToolType.WireA:
                    return true;
                case ToolType.WireB:
                    return true;
            }
        }
        return false;
    }
}
