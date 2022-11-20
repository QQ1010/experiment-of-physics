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
    public override bool CheckPlace()
    {
        // check when to return true when to return false
        if (positives.Count >= 1)
        {
            foreach(ElectronicComponent pos in positives)
            {
                switch (pos.tool_type)
                {
                    case ToolType.PowerSupply:
                        foreach (ElectronicComponent PS_neg in pos.negetives)
                        {
                            if (PS_neg.tool_type == ToolType.Voltmeter)         // V pos to PS neg
                            {
                                return false;
                            }
                        }
                        break;
                    case ToolType.Voltmeter:                                    // V to V
                        return false;
                    case ToolType.Gaussmeter:
                        return false;
                    case ToolType.Ruler:
                        return false;
                    case ToolType.Ammeter:
                        return false;
                    case ToolType.WireA:
                        return false;
                    case ToolType.WireB:
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
                    case ToolType.PowerSupply:
                        foreach (ElectronicComponent PS_pos in neg.positives)
                        {
                            if (PS_pos.tool_type == ToolType.Voltmeter)        // V neg to PS pos
                            {
                                return false;
                            }
                        }
                        break;
                    case ToolType.Voltmeter:                                   // V to V
                        return false;
                    case ToolType.Gaussmeter:
                        return false;
                    case ToolType.Ruler:
                        return false;
                    case ToolType.Ammeter:
                        return false;
                    case ToolType.WireA:
                        return false;
                    case ToolType.WireB:
                        return false;
                }
                
            }
        }
        return true;
        
    }
}
