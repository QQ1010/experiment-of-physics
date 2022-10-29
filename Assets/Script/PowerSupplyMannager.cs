using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerSupplyMannager : ElectronicComponent
{
    public float unit = 0.5f;
    [SerializeField] TextMeshProUGUI voltage_text;
    [SerializeField] TextMeshProUGUI ampere_text;

    public void IncreaseVoltage()
    {
        voltage += unit;
        voltage_text.text = voltage.ToString();
    }
    public void DecreaseVoltage()
    {
        voltage -= unit;
        voltage_text.text = voltage.ToString();
    }
    public void IncreaseAmpere()
    {
        ampere += unit;
        ampere_text.text = ampere.ToString();
    }
    public void DecreaseAmpere()
    {
        ampere -= unit;
        ampere_text.text = ampere.ToString();
    }
}
