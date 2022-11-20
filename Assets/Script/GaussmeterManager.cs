using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GaussmeterManager : ElectronicComponent
{
    public const double PI = 3.1415926535897931;
    [SerializeField] TextMeshProUGUI gauss_text_;
    void Start()
    {
        tool_type = ToolType.Gaussmeter;
        // Caculate the gauss value
        // need Distance r
        //double B = (Math.Pow(4 * PI, -7)/2*PI)*ampere/r;
        gauss_text_.text = 0.ToString();
    }
    public override bool CheckPlace()
    {
        return true;
        //  check when to return true when to return false
        // it seems no need to check
    }
}
