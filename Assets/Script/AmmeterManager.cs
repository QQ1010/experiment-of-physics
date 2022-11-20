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
        if(positives.Count > 1 || negetives.Count > 1)       // �ˬd���p
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
                    // TODO
                    break;
            }
                

        }
        if(negetives.Count == 1)
        {
            neg = negetives[0];
        }
        
        return true;
        // ��ˬO���T����m �^��true
        // �ˬd���~��m �^�� false
    }
}
