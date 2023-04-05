using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ToolBar : MonoBehaviour
{
    public List<GameObject> ToolbarManager = new List<GameObject>();
    public List<GameObject> Tools;
    private bool[] exited;

    private void Start()
    {
        exited = new bool[10];
        for (int i = 0; i < 10; i++)
        {
            exited[i] = false;
        }
    }
    public void CreateObject(int index)
    {
        if(exited[index] == false)
        {
            // Target
            GameObject targetObject = Tools[index];
            // Parent
            GameObject parentObject = GameObject.Find("Tool");
            // Create
            GameObject o = Instantiate(
                 targetObject,
                 targetObject.transform.position,
                 targetObject.transform.rotation,
                 parentObject.transform
            );
            try{
                o.GetComponent<ElectronicComponent>().Init();
            }catch(Exception e) {}
            CircuitManager.instanse.tools.Add(o);
            exited[index] = true;
        }
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
        for (int i = 0; i < 10; i++)
        {
            exited[i] = false;
        }
    }
}
