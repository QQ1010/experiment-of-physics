using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ToolType
{
    Ammeter,
    Voltmeter,
    PowerSupply,
    Resistor,
    Gaussmeter,
    WireA,
    WireB,
    Ruler
}


[System.Serializable]
public class ElectronicComponent : MonoBehaviour
{
    public ToolType tool_type;
    public float voltage
    {
        get { return voltage_; }
        set
        {
            voltage_ = value;
            if (voltage_text_)
            {
                voltage_text_.text = Math.Round(voltage_, 3).ToString();
            }
        }
    }
    public float ampere
    {
        get { return ampere_; }
        set
        {
            ampere_ = value;
            if (ampere_text_)
            {
                ampere_text_.text = Math.Round(ampere_, 3).ToString();
            }
        }
    }
    public float resistance
    {
        get { return resistance_; }
        set
        {
            resistance_ = value;
            if (voltage_text_)
            {
                resistance_text_.text = Math.Round(resistance_, 3).ToString();
            }
        }
    }
    public List<ElectronicComponent> positives = new List<ElectronicComponent>();
    public List<ElectronicComponent> negetives = new List<ElectronicComponent>();
    public List<bool> postag = new List<bool>();
    public List<bool> negtag = new List<bool>();
    public float mass;
    public float force = 0;
    public bool reverse;

    private float voltage_;
    private float ampere_;
    private float resistance_;
    [SerializeField] TextMeshProUGUI voltage_text_;
    [SerializeField] TextMeshProUGUI ampere_text_;
    [SerializeField] TextMeshProUGUI resistance_text_;

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        positives.Clear();
        negetives.Clear();
        postag.Clear();
        negtag.Clear();
        force = 0;
        reverse = false;

        voltage_ = 0.0f;
        ampere_ = 0.0f;
        if(tool_type == ToolType.Resistor)
            resistance_ = ((ResistorManager)this).min_resistance;
        if(voltage_text_)
            voltage_text_.text = "0.0";
        if(ampere_text_)
            ampere_text_.text = "0.0";
    }

    public bool ConnectComponent(bool from, bool to, ElectronicComponent component)
    {
        if (component == null) return false;
        if (from)
        {
            if (positives.Contains(component))
                return false;
            positives.Add(component);
            postag.Add(to);
        }
        else
        {
            if (negetives.Contains(component))
                return false;
            negetives.Add(component);
            negtag.Add(to);
        }
        if (to)
        {
            if (component.positives.Contains(this))
                return false;
            component.positives.Add(this);
            component.postag.Add(from);
        }
        else
        {
            if (component.negetives.Contains(this))
                return false;
            component.negetives.Add(this);
            component.negtag.Add(from);
        }
        return true;
    }

    // warning cannot remove postag List and negtag List, so do not use until someone fix the bug XD
    //public bool DisconnectComponent(bool from, bool to, ElectronicComponent component)
    //{
    //    if (component == null) return false;

    //    if (from && positives.Exists(x => x == component))
    //    {
    //        positives.Remove(component);
    //    }
    //    else if (!from && negetives.Exists(x => x == component))
    //    {
    //        negetives.Remove(component);
    //    }
    //    else return false;
    //    if (to && component.positives.Exists(x => x == this))
    //    {
    //        component.positives.Remove(this);
    //    }
    //    else if (!to && component.negetives.Exists(x => x == this))
    //    {
    //        component.negetives.Remove(this);
    //    }
    //    else return false;
    //    return true;
    //}

    public virtual bool CheckPlace(bool from, bool to, ElectronicComponent component)
    {
        return true;
    }
}
