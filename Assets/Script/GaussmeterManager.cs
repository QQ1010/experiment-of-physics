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
        gauss_text_.text = 0.ToString();
    }
    public void CaculateGauss()
    {
        // Caculate the gauss value => write a function => in circuit update call this function => DragObject 
        CircuitManager cm = CircuitManager.instanse;
        ElectronicComponent wire_ = null;
        GameObject wire_o;
        if (wire_o = cm.tools.Find(obj => obj.GetComponent<ElectronicComponent>().tool_type == ToolType.WireA))
        {
            wire_ = wire_o.GetComponent<ElectronicComponent>();
        }
        else if (wire_o = cm.tools.Find(obj => obj.GetComponent<ElectronicComponent>().tool_type == ToolType.WireB))
        {
            wire_ = wire_o.GetComponent<ElectronicComponent>();
        }
        else
        {
            print("no wire_");
            return;
        }
        if (wire_ != null)
        {
            double R = Math.Abs(gameObject.transform.position.y - wire_.transform.position.y)/0.4;
            print(R);
            double a = (13.3 / 2) / 0.4;
            double u = (4 * PI / 100);
            double B = (u * wire_.ampere * a * a) / (2*Math.Pow((a*a + R*R),3/2));
            print(wire_.ampere);
            print(PI);
            print(B);
            gauss_text_.text = Math.Round(B, 3).ToString();
            return;
        }
        gauss_text_.text = 0.ToString();
        return;
    }
    public void OnMouseDrag()
    {
        CaculateGauss();
    }
    public override bool CheckPlace(bool from, bool to, ElectronicComponent component)
    {
        return true;
        //  check when to return true when to return false
        // it seems no need to check
    }
}
