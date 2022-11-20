using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmeterManager : ElectronicComponent
{
    private void Start()
    {
        tool_type = ToolType.Ammeter;
    }
    public override bool CheckPlace()
    {
        if(positives.Count > 1 || negetives.Count > 1)       // 檢查串聯
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
        // 怎樣是正確的位置 回傳true
        // 檢查錯誤位置 回傳 false
    }
}
