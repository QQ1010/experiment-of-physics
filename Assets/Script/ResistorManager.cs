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
        bool error = false;
        // if positives or negetives have 2 connections, then there should be one voltmeter. Otherwise, error = true, return false.
        if(positives.Count == 2) 
            error |= !(positives[0].tool_type == ToolType.Voltmeter | positives[1].tool_type == ToolType.Voltmeter);
        if(negetives.Count == 2) 
            error |= !(negetives[0].tool_type == ToolType.Voltmeter | negetives[1].tool_type == ToolType.Voltmeter);
        return !error;
    }
}
