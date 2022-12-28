using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ResistorManager : ElectronicComponent
{
    public float max_resistance = 10.1f;
    public float min_resistance = 0.1f;
    public GameObject rightup_node;
    public GameObject leftup_node;
    public GameObject rightdown_node;
    public GameObject leftdown_node;
    void Start()
    {
        tool_type = ToolType.Resistor;
        resistance = min_resistance;
    }
    public override bool CheckPlace(bool from, bool to, ElectronicComponent component)
    {
        if(positives.Count > 2 || negetives.Count > 2) return false;
        if (from)
        {
            switch (component.tool_type)
            {
                case ToolType.Voltmeter:
                    if (to) return true;
                    break;
                case ToolType.Ammeter:
                    if(!to) return true;
                    break;
                case ToolType.PowerSupply:
                    if(to) return true;
                    break;
                case ToolType.WireA:
                    if(!to) return true;
                    break;
                case ToolType.WireB:
                    if(!to) return true;
                    break;
            }
        }
        else if (!from)
        {
            switch (component.tool_type)
            {
                case ToolType.Voltmeter:
                    if(!to) return true;
                    break;
                case ToolType.Ammeter:
                    if(to) return true;
                    break;
                case ToolType.PowerSupply:
                    if(!to) return true;
                    break;
                case ToolType.WireA:
                    if(to) return true;
                    break;
                case ToolType.WireB:
                    if(to) return true;
                    break;
            }
        }
        return false;
    }
}
