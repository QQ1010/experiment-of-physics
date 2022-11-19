using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmeterManager : ElectronicComponent
{
    [SerializeField] TextMeshProUGUI ammeter_text;
    public void AssignAmmeterValue()
    {
        ammeter_text.text = ampere.ToString();
    }
}
