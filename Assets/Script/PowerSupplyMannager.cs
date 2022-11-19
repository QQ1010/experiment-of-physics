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

}
