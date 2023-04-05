using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CircuitManager : MonoBehaviour
{
    public const float PI = 3.1415926535897931f;
    static public CircuitManager instanse;
    public List<GameObject> tools = new List<GameObject>();

    private float total_voltage_;
    private float total_ampere_;
    private float coefficient = 0.99987f;
    private float offset = 0.0003f;
    void Start()
    {
        CircuitManager.instanse = this;
    }
    private void Update()
    {
        //CircuitUpdate();
    }

    private static bool FindPathv2(ElectronicComponent node, bool tag, List<ElectronicComponent> in_circuit, bool stop)
    {
        // go back to powersupply neg
        if (node.tool_type == ToolType.PowerSupply && stop == true)
        {
            print("END");
            return true;
        }
        bool to_power = false;
        if(node.tool_type == ToolType.PowerSupply && tag == true)
        {
            stop = true;
            for (int i = 0; i < node.positives.Count; i++)
            {
                //print(node.positives);
                print(node.positives[i]);
                print(!node.postag[i]);
                to_power |= FindPathv2(node.positives[i], !node.postag[i], in_circuit, stop);
                if (to_power) in_circuit.Add(node.positives[i]);
            }
        }
        else if (tag == true)
        {
            for (int i = 0; i < node.positives.Count; i++)
            {
                //print(node.positives);
                print(node.positives[i]);
                print(node.postag[i]);
                to_power |= FindPathv2(node.positives[i], !node.postag[i], in_circuit, stop);
                if (to_power) in_circuit.Add(node.positives[i]);
            }
        }
        else if (tag == false)
        {
            for (int i = 0; i < node.negetives.Count; i++)
            {
                print(node.negetives[i]);
                print(node.negtag[i]);
                to_power |= FindPathv2(node.negetives[i], !node.negtag[i], in_circuit, stop);
                if (to_power) in_circuit.Add(node.negetives[i]);
            }
        }
        return to_power;
    }
    // not work now
    private static bool FindPath(ElectronicComponent node, Dictionary<ElectronicComponent, bool> visisted, List<ElectronicComponent> in_circuit, bool pass) 
    {
        print("node = " + node.tool_type);
        //print("pass = " + pass);
        if (visisted.ContainsKey(node) && visisted[node]) return node.tool_type == ToolType.PowerSupply;
        visisted.Add(node, true);
        bool to_power = false;
        if(node.tool_type == ToolType.PowerSupply)
        {
            foreach(ElectronicComponent child in node.positives)
            {
                //print(child);
                to_power |= FindPath(child, visisted, in_circuit, pass);
                if (to_power)
                    in_circuit.Add(child);
            }
        }
        else if ((node.tool_type == ToolType.WireA || node.tool_type == ToolType.WireB) && node.reverse == true && pass == false)
        {
            //print("pass = first");
            pass = true;
            foreach (ElectronicComponent child in node.negetives)
            {
                to_power |= FindPath(child, visisted, in_circuit, pass);
                if (to_power)
                    in_circuit.Add(child);
            }
        }
        else if ((node.tool_type == ToolType.WireA || node.tool_type == ToolType.WireB) && node.reverse == true && pass == true)
        {
            pass = false;
            foreach (ElectronicComponent child in node.positives)
            {
                //print("child = " + child);
                to_power |= FindPath(child, visisted, in_circuit, pass);
                if (to_power)
                    in_circuit.Add(child);
            }
        }
        else
        {
            foreach (ElectronicComponent child in node.negetives)
            {
                to_power |= FindPath(child, visisted, in_circuit, pass);
                if (to_power)
                    in_circuit.Add(child);
            }
        }
        visisted.Remove(node);
        print("findpath = " + to_power);
        return to_power;
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
        ElectronicComponent gaussmeter = null;
        try
        {
            power_ = cm.tools.Find(obj => obj.GetComponent<ElectronicComponent>().tool_type == ToolType.PowerSupply).GetComponent<ElectronicComponent>();
        }
        catch (Exception e) { }

        if (power_ == null)
            return;

        // find the circuit with dfs
        Dictionary<ElectronicComponent, bool> visited = new Dictionary<ElectronicComponent, bool>();
        List<ElectronicComponent> in_circuit = new List<ElectronicComponent>();
        //FindPath(power_, visited, in_circuit, false);
        FindPathv2(power_, true,in_circuit, false);
        print("connect List");
        foreach (ElectronicComponent component in in_circuit)
        {
            print(component.name);
            switch (component.tool_type)
            {
                case ToolType.Ammeter:
                    ammeter_ = component;
                    break;
                case ToolType.Voltmeter:
                    votmeter_ = component;
                    break;
                case ToolType.WireA:
                    wireA_ = component;
                    break;
                case ToolType.WireB:
                    wireB_ = component;
                    break;
                case ToolType.PowerSupply:
                    power_ = component;
                    break;
                case ToolType.Resistor:
                    resistor_ = component;
                    break;
                default:
                    break;
            }
        }


        cm.total_voltage_ = power_.voltage * UnityEngine.Random.Range(cm.coefficient - cm.offset, cm.coefficient + cm.offset);
        if (resistor_)
        {
            resistor_.voltage = cm.total_voltage_;
            resistor_.ampere = cm.total_voltage_ / resistor_.resistance;
            cm.total_ampere_ = resistor_.ampere;
        }
        if (votmeter_)
        {
            votmeter_.voltage = cm.total_voltage_;
        }
        if (ammeter_)
        {
            ammeter_.ampere = cm.total_ampere_;
        }
        if (wireA_)
        {
            wireA_.ampere = cm.total_ampere_- wireA_.resistance;
        }
        if (wireB_)
        {
            wireB_.ampere = cm.total_ampere_ - wireB_.resistance;
        }
        if(wireA_ && wireB_) {
            print(wireA_.reverse);
            if(wireA_.reverse == true)
            {
                float d = wireA_.transform.position.y - wireB_.transform.position.y;
                print(d);
                float L = ((WireAManager)wireA_).length;
                wireA_.force = wireA_.ampere * wireB_.ampere * (float)(4 * PI * 1e-1 / (4 * PI * d * d)) * L;
                wireB_.force = wireA_.force;
            }
            else
            {
                float d = wireA_.transform.position.y - wireB_.transform.position.y;
                float L = ((WireAManager)wireA_).length;
                wireA_.force = -(wireA_.ampere * wireB_.ampere * (float)(4 * PI * 1e-1 / (4 * PI * d * d)) * L);
                wireB_.force = wireA_.force;
            }
        }
        power_.ampere = cm.total_ampere_;
        GameObject gaussmeter_o;
        try{
            gaussmeter_o = cm.tools.Find(obj => obj.GetComponent<ElectronicComponent>().tool_type == ToolType.Gaussmeter);
            gaussmeter = gaussmeter_o.GetComponent<ElectronicComponent>();
            gaussmeter.gameObject.GetComponent<GaussmeterManager>().CaculateGauss();
        }catch(Exception e) {}
        
    }
}

