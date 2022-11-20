using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBar : MonoBehaviour
{
    public List<GameObject> ToolbarManager = new List<GameObject>();
    public List<GameObject> Tools;
    
    public void CreateObject(int index)
    {
        // Target
        GameObject targetObject = Tools[index];
        // Parent
        GameObject parentObject = GameObject.Find("Tool");

        // Create
        GameObject o = Instantiate(
             targetObject,
             parentObject.transform.position,
             parentObject.transform.rotation,
             parentObject.transform
        );
        CircuitManager.instanse.tools.Add(o);
    }
    public void Reset()
    {
        GameObject parentObject = GameObject.Find("Tool");
        int nbChildren = parentObject.transform.childCount;

        for (int i = nbChildren - 1; i >= 0; i--)
        {
            Destroy(parentObject.transform.GetChild(i).gameObject);
        }
        CircuitManager.instanse.tools.Clear();
    }
}
