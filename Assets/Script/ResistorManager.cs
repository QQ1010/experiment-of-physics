using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ResistorManager : ElectronicComponent
{
    public float max_resistance = 10.1f;
    public float min_resistance = 0.1f;
    void Start()
    {
        tool_type = ToolType.Resistor;
        resistance = min_resistance;
    }
    public override bool CheckPlace()
    {
        if(positives.Count > 2 || negetives.Count > 2) return false;
        //R pos to PS pos => false
        if (positives.Count >= 1)
        {
            foreach (ElectronicComponent pos in positives)
            {
                if (pos.tool_type == ToolType.PowerSupply)
                {
                    print("R pos has PS: true");
                    foreach (ElectronicComponent PS_pos in pos.positives)
                    {
                        if (PS_pos.tool_type == ToolType.Resistor)
                        {
                            print("PS pos has R: true");
                            return false;
                        }
                    }
                }
            }
        }
        // R neg to PS neg => false
        if (negetives.Count >= 1)
        {
            foreach (ElectronicComponent neg in negetives)
            {   
                if (neg.tool_type == ToolType.PowerSupply)
                {
                    print("R neg has PS: true");
                    foreach (ElectronicComponent PS_neg in neg.negetives)
                    {
                        if (PS_neg.tool_type == ToolType.Resistor)
                        {
                            print("PS neg has R: true");
                            return false;
                        }
                    }
                }
            }
        }
        //R pos to V neg => false
        if (positives.Count >= 1)
        {
            foreach(ElectronicComponent pos in positives)
            {
                if(pos.tool_type == ToolType.Voltmeter)
                {
                    print("R pos has V: true");
                    foreach (ElectronicComponent V_neg in pos.negetives)
                    {
                        if(V_neg.tool_type == ToolType.Resistor)
                        {
                            print("V neg has R: true");
                            return false;
                        }
                    }
                }
            }
        }
        //R neg to V pos => false
        if (negetives.Count >= 1)
        {
            foreach (ElectronicComponent neg in negetives)
            {
                if (neg.tool_type == ToolType.Voltmeter)
                {
                    print("R neg has V: true");
                    foreach (ElectronicComponent V_pos in neg.positives)
                    {
                        if (V_pos.tool_type == ToolType.Resistor)
                        {
                            print("V pos has R: true");
                            return false;
                        }
                    }
                }
            }
        }
        // if positives or negetives have 2 connections, then there should be one voltmeter. Otherwise, error = true, return false.
        bool error = false;
        if (positives.Count == 2) 
            error |= !(positives[0].tool_type == ToolType.Voltmeter | positives[1].tool_type == ToolType.Voltmeter);
        if(negetives.Count == 2) 
            error |= !(negetives[0].tool_type == ToolType.Voltmeter | negetives[1].tool_type == ToolType.Voltmeter);
        return !error;
    }
}
