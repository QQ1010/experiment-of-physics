using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PowerSupplyMannager3D : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI voltage_text_2D;
    [SerializeField] TextMeshProUGUI ampere_text_2D;
    [SerializeField] TextMeshProUGUI voltage_text_3D;
    [SerializeField] TextMeshProUGUI ampere_text_3D;
    [SerializeField] WireManager wireA;
    [SerializeField] WireManager wireB;
    private float coefficient = 0.9987f;
    private float offset = 0.0003f;
    public float voltage
    {
        get { return voltage_; }
        set
        {
            voltage_ = value;
            voltage_text_2D.text = voltage_.ToString();
            voltage_text_3D.text = voltage_.ToString();
        }
    }
    public float ampere
    {
        get { return ampere_; }
        set
        {
            ampere_ = value;
            ampere_text_2D.text = Math.Round(ampere_,3).ToString();
            ampere_text_3D.text = Math.Round(ampere_,3).ToString();
        }
    }
    public float voltage_ = 0.0f;
    public float ampere_ = 0.0f;
    public float resistance_;
    public float unit = 0.5f;

    void Start() {
        CircuitUpdate();
    }
    public void IncreaseVoltage()
    {
        voltage += unit;
        CircuitUpdate();
    }
    public void DecreaseVoltage()
    {
        voltage -= unit;
        CircuitUpdate();
    }

    public void CircuitUpdate() {
        float total_voltage_ = voltage * UnityEngine.Random.Range(coefficient - offset, coefficient + offset);
        float total_resistance = resistance_ + wireA.resistance + wireB.resistance;
        float total_ampere = voltage / total_resistance;
        ampere = total_ampere;
        wireA.voltage = total_voltage_;
        wireA.ampere = total_ampere;
        wireB.voltage = total_voltage_;
        wireB.ampere = total_ampere;
    }
}
