using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum ToolType{
    Ammeter,
    Votmeter,
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
        set {
            if(voltage_text_) {
                voltage_ = value;
                voltage_text_.text = voltage_.ToString();
            }
        }
    }
    public float ampere
    {
        get { return ampere_; }
        set {
            if(voltage_text_) {
                ampere_ = value;
                ampere_text_.text = ampere_.ToString();
            }
        }
    }
    public float resistance
    {
        get { return resistance_; }
        set {
            if(voltage_text_) {
                resistance_ = value;
                resistance_text_.text = resistance_.ToString();
            }
        }
    }
    public List<ElectronicComponent> postives = new List<ElectronicComponent>();
    public List<ElectronicComponent> negetives = new List<ElectronicComponent>();

    private float voltage_;
    private float ampere_;
    private float resistance_;
    [SerializeField] TextMeshProUGUI voltage_text_;
    [SerializeField] TextMeshProUGUI ampere_text_;
    [SerializeField] TextMeshProUGUI resistance_text_;
    

    public bool ConnectComponent(bool from, bool to, ElectronicComponent component) {
        if(component == null) return false;
        if (from) {
            if(postives.Contains(component))
                return false;
            postives.Add(component);
        }
        else {
            if(negetives.Contains(component))
                return false;
            negetives.Add(component);
        }
        if (to) {
            if(component.postives.Contains(this))
                return false;
            component.postives.Add(this);
        }
        else {
            if(component.negetives.Contains(this))
                return false;
            component.negetives.Add(this);
        }
        return true;
    }
    public bool DisconnectComponent(ElectronicComponent component) {
        if (component == null) return false;
        bool result = false;
        if (postives.Exists(x => x == component)) {
            postives.Remove(component);
            result = true;
        }
        if (negetives.Exists(x => x == component)) {
            negetives.Remove(component);
            result = true;
        }
        if (component.postives.Exists(x => x == this)) {
            component.postives.Remove(this);
            result = true;
        }
        if(component.negetives.Exists(x => x == this)) {
            component.negetives.Remove(this);
            result = true;
        }
        return result;
    }
}
