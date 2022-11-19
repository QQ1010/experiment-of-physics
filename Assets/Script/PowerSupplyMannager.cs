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
    }
    public void DecreaseVoltage()
    {
        voltage -= unit;
    }
    public void IncreaseAmpere()
    {
        ampere += unit;
    }
    public void DecreaseAmpere()
    {
        ampere -= unit;
    }
    public override bool CheckPlace()
    {
        return true;
        // ��ˬO���T����m �^��true
        // �ˬd���~��m �^�� false
    }
}
