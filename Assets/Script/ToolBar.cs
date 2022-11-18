using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBar : MonoBehaviour
{
    public List<GameObject> ToolbarManager = new List<GameObject>();
    public List<GameObject> Tools;
    public void CreateAmmeter()
    {

        // Target
        GameObject targetObject = Tools[0];
        // Parent
        GameObject parentObject = GameObject.Find("Tool");

        // Create
        Instantiate(
             targetObject,
             parentObject.transform.position,
             parentObject.transform.rotation,
             parentObject.transform
        );
        /*ToolbarManager.Add(
           Instantiate(
            targetObject,
            parentObject.transform.position,
            parentObject.transform.rotation,
            parentObject.transform
       ));*/
    }
    public void CreateVoltmeter()
    {

        // Target
        GameObject targetObject = Tools[1];
        // Parent
        GameObject parentObject = GameObject.Find("Tool");

        // Create
        Instantiate(
            targetObject,
            parentObject.transform.position,
            parentObject.transform.rotation,
            parentObject.transform
       );
        /*ToolbarManager.Add(
           Instantiate(
            targetObject,
            parentObject.transform.position,
            parentObject.transform.rotation,
            parentObject.transform
       ));*/
    }
    public void CreateGaussmeter()
    {

        // Target
        GameObject targetObject = Tools[2];
        // Parent
        GameObject parentObject = GameObject.Find("Tool");

        // Create
        Instantiate(
            targetObject,
            parentObject.transform.position,
            parentObject.transform.rotation,
            parentObject.transform
       );
        /*ToolbarManager.Add(
           Instantiate(
            targetObject,
            parentObject.transform.position,
            parentObject.transform.rotation,
            parentObject.transform
       ));*/
    }
    public void CreateDCPower()
    {

        // Target
        GameObject targetObject = Tools[3];
        // Parent
        GameObject parentObject = GameObject.Find("Tool");

        // Create
        Instantiate(
            targetObject,
            parentObject.transform.position,
            parentObject.transform.rotation,
            parentObject.transform
       );
        /*ToolbarManager.Add(
           Instantiate(
            targetObject,
            parentObject.transform.position,
            parentObject.transform.rotation,
            parentObject.transform
       ));*/
    }
    public void CreateVariableResistor()
    {

        // Target
        GameObject targetObject = Tools[4];
        // Parent
        GameObject parentObject = GameObject.Find("Tool");

        // Create
        Instantiate(
            targetObject,
            parentObject.transform.position,
            parentObject.transform.rotation,
            parentObject.transform
       );
        /*ToolbarManager.Add(
           Instantiate(
            targetObject,
            parentObject.transform.position,
            parentObject.transform.rotation,
            parentObject.transform
       ));*/
    }
    public void CreateRuler()
    {

        // Target
        GameObject targetObject = Tools[5];
        // Parent
        GameObject parentObject = GameObject.Find("Tool");

        // Create
        Instantiate(
            targetObject,
            parentObject.transform.position,
            parentObject.transform.rotation,
            parentObject.transform
       );
        /*ToolbarManager.Add(
           Instantiate(
            targetObject,
            parentObject.transform.position,
            parentObject.transform.rotation,
            parentObject.transform
       ));*/
    }
    public void CreateWireA()
    {

        // Target
        GameObject targetObject = Tools[6];
        // Parent
        GameObject parentObject = GameObject.Find("Tool");

        // Create
        Instantiate(
            targetObject,
            parentObject.transform.position,
            parentObject.transform.rotation,
            parentObject.transform
       );
        /*ToolbarManager.Add(
           Instantiate(
            targetObject,
            parentObject.transform.position,
            parentObject.transform.rotation,
            parentObject.transform
       ));*/
    }
    public void CreateWireB()
    {

        // Target
        GameObject targetObject = Tools[7];
        // Parent
        GameObject parentObject = GameObject.Find("Tool");

        // Create
        Instantiate(
            targetObject,
            parentObject.transform.position,
            parentObject.transform.rotation,
            parentObject.transform
       );
        /*ToolbarManager.Add(
           Instantiate(
            targetObject,
            parentObject.transform.position,
            parentObject.transform.rotation,
            parentObject.transform
       ));*/
    }
    public void Reset()
    {
        GameObject parentObject = GameObject.Find("Tool");
        int nbChildren = parentObject.transform.childCount;

        for (int i = nbChildren - 1; i >= 0; i--)
        {
            Destroy(parentObject.transform.GetChild(i).gameObject);
        }
    }
}
