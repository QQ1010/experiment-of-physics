using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ElectronicComponent : MonoBehaviour
{
    public float voltage;
    public float ampere;
    public float resistance;
    public List<ElectronicComponent> postives = new List<ElectronicComponent>();
    public List<ElectronicComponent> negetives = new List<ElectronicComponent>();

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
