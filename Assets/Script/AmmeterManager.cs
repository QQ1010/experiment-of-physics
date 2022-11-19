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
        return true;
        // ��ˬO���T����m �^��true
        // �ˬd���~��m �^�� false
    }
}
