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
        // 怎樣是正確的位置 回傳true
        // 檢查錯誤位置 回傳 false
    }
}
