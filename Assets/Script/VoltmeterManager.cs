using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VoltmeterManager : ElectronicComponent
{
    [SerializeField] TextMeshProUGUI voltmeter_text;
    void Start()
    {
        voltage = 10;
    }
    public void AssignVoltmeterValue()
    {
        voltmeter_text.text = voltage.ToString();
    }
    public override bool CheckPlace()
    {
        return true;
        // 怎樣是正確的位置 回傳true
        // 檢查錯誤位置 回傳 false
    }
}
