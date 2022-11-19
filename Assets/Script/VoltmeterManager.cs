using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VoltmeterManager : ElectronicComponent
{
    [SerializeField] TextMeshProUGUI voltmeter_text;
    public void AssignVoltmeterValue()
    {
        voltmeter_text.text = voltage.ToString();
    }
}
