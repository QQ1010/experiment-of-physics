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
    public override bool CheckPlace()
    {
        // check when can connect => list false situation
        if (positives.Count > 1 || negetives.Count > 1)
        {
            return false;
        }
        ElectronicComponent pos;
        ElectronicComponent neg;
        if (positives.Count == 1)
        {
            pos = positives[0];
            switch (pos.tool_type)
            {
                case ToolType.PowerSupply:
                    if(pos.positives.Count >= 1)                    // A pos to PS pos and A neg to PS neg
                    {
                        foreach(ElectronicComponent PS_pos in pos.positives)
                        {
                            if(PS_pos.tool_type == ToolType.Ammeter)
                            {
                                if(negetives.Count == 1)
                                {
                                    if(negetives[0].tool_type == ToolType.PowerSupply)
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                    foreach (ElectronicComponent PS_neg in pos.negetives)           // A pos to PS neg
                    {
                        if (PS_neg.tool_type == ToolType.Ammeter)
                        {
                            return false;
                        }
                    }
                    break;
                case ToolType.Ammeter:
                    return false;
                case ToolType.Gaussmeter:
                    return false;
                case ToolType.Voltmeter:
                    return false;
                case ToolType.Resistor:
                    return false;
                case ToolType.Ruler:
                    return false;
            }       
        }
        if(negetives.Count == 1)
        {
            neg = negetives[0];
            switch (neg.tool_type)
            {
                case ToolType.PowerSupply:
                    if (neg.positives.Count >= 1)                    // A neg to PS neg and A pos to PS pos
                    {
                        foreach (ElectronicComponent PS_neg in neg.negetives)
                        {
                            if (PS_neg.tool_type == ToolType.Ammeter)
                            {
                                if (positives.Count == 1)
                                {
                                    if (positives[0].tool_type == ToolType.PowerSupply)
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                    foreach (ElectronicComponent PS_pos in neg.positives)           // A neg to PS pos
                    {
                        if(PS_pos.tool_type == ToolType.Ammeter)
                        {
                            return false;
                        }
                    }
                    break;
                case ToolType.Ammeter:
                    return false;
                case ToolType.Gaussmeter:
                    return false;
                case ToolType.Voltmeter:
                    return false;
                case ToolType.Resistor:
                    return false;
                case ToolType.Ruler:
                    return false;
            }
        }
        return true;
    }
}
