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
    public override bool CheckPlace()
    {
        if (positives.Count >= 1)
        {
            foreach (ElectronicComponent pos in positives)
            {
                switch (pos.tool_type)
                {
                    case ToolType.Ammeter:
                        // PS pos to A neg => false
                        foreach(ElectronicComponent A_neg in pos.negetives)
                        {
                            if (A_neg.tool_type == ToolType.PowerSupply) return false;
                        }
                        break;
                    case ToolType.Voltmeter:
                        // PS pos to V neg => false
                        foreach(ElectronicComponent V_neg in pos.negetives)
                        {
                            if (V_neg.tool_type == ToolType.PowerSupply) return false;
                        }
                        break;
                    case ToolType.Resistor:
                        // PS pos to R pos => false
                        foreach(ElectronicComponent R_pos in pos.positives)
                        {
                            if (R_pos.tool_type == ToolType.PowerSupply) return false;
                        }
                        break;
                    case ToolType.Ruler:
                        return false;
                    case ToolType.WireA:
                        return false;
                    case ToolType.WireB:
                        return false;
                    case ToolType.Gaussmeter:
                        return false;
                    case ToolType.PowerSupply:
                        return false;
                }
            }
        }

        if (negetives.Count >= 1)
        {
            foreach (ElectronicComponent neg in negetives)
            {
                switch (neg.tool_type)
                {
                    case ToolType.Ammeter:
                        // PS neg to A pos => false
                        foreach (ElectronicComponent A_pos in neg.positives)
                        {
                            if (A_pos.tool_type == ToolType.PowerSupply) return false;
                        }
                        break;
                    case ToolType.Voltmeter:
                        // PS neg to V pos => false
                        foreach (ElectronicComponent V_pos in neg.positives)
                        {
                            if (V_pos.tool_type == ToolType.PowerSupply) return false;
                        }
                        break;
                    case ToolType.Resistor:
                        // PS neg to R neg => false
                        foreach (ElectronicComponent R_neg in neg.negetives)
                        {
                            if (R_neg.tool_type == ToolType.PowerSupply) return false;
                        }
                        break;
                    case ToolType.Ruler:
                        return false;
                    case ToolType.WireA:
                        return false;
                    case ToolType.WireB:
                        return false;
                    case ToolType.Gaussmeter:
                        return false;
                    case ToolType.PowerSupply:
                        return false;
                }
            }
        }
        return true;
    }
}
