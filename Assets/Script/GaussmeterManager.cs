using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GaussmeterManager : ElectronicComponent
{
    void Start()
    {
        tool_type = ToolType.Gaussmeter;
    }
    public override bool CheckPlace()
    {
        return true;
        // ��ˬO���T����m �^��true
        // �ˬd���~��m �^�� false
    }
}
