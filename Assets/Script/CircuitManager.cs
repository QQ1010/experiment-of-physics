using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitManager : MonoBehaviour
{
    static public CircuitManager instanse;
    public List<GameObject> tools = new List<GameObject>();

    private float total_voltage_;
    private float total_ampere_;
    private float coefficient = 0.9987f;
    private float offset = 0.0003f;
    void Start()
    {
        CircuitManager.instanse = this;
    }

    public static void CircuitUpdate()
    {
        CircuitManager cm = CircuitManager.instanse;
        ElectronicComponent power_ = null;
        ElectronicComponent ammeter_ = null;
        ElectronicComponent votmeter_ = null;
        ElectronicComponent resistor_ = null;
        ElectronicComponent wireA_ = null;
        ElectronicComponent wireB_ = null;
        power_ = cm.tools.Find( obj => obj.GetComponent<ElectronicComponent>().tool_type == ToolType.PowerSupply ).GetComponent<ElectronicComponent>();

        if(power_ == null)
            return;

        // find the circuit with dfs
        Stack<ElectronicComponent> stack = new Stack<ElectronicComponent>();
        stack.Push(power_);
        foreach(var o in power_.postives)
        {

        }
        while(stack.Count > 0)
        {
            ElectronicComponent node = stack.Pop();
            if(node.tool_type == ToolType.PowerSupply) {

                node.postives.ForEach( child => stack.Push(child) );
                node.postives.ForEach( child => print(child.tool_type) );
                continue;
            }
            print(node.tool_type);
            switch(node.tool_type)
            {
                case ToolType.Ammeter:
                    ammeter_ = node.GetComponent<ElectronicComponent>();
                    break;
                case ToolType.Votmeter:
                    votmeter_ = node.GetComponent<ElectronicComponent>();
                    break;
                case ToolType.WireA:
                    wireA_ = node.GetComponent<ElectronicComponent>();
                    break;
                case ToolType.WireB:
                    wireB_ = node.GetComponent<ElectronicComponent>();
                    break;
                case ToolType.PowerSupply:
                    power_ = node.GetComponent<ElectronicComponent>();
                    break;
                case ToolType.Resistor:
                    resistor_ = node.GetComponent<ElectronicComponent>();
                    break;
                default:
                    break;
            }
        } 
        print(cm.total_voltage_);


        cm.total_voltage_ = power_.voltage * Random.Range(cm.coefficient - cm.offset, cm.coefficient + cm.offset);
        cm.total_ampere_ = power_.voltage * Random.Range(cm.coefficient - cm.offset, cm.coefficient + cm.offset);
        if(votmeter_)
        {
            votmeter_.voltage = cm.total_voltage_;
        }
        if(ammeter_)
        {
            ammeter_.ampere = cm.total_voltage_ * resistor_.resistance;
        }
        if(resistor_)
        {
            resistor_.voltage = cm.total_voltage_;
            resistor_.ampere = cm.total_ampere_;
        }
    }
}

