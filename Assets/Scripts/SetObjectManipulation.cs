using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.InputModule.Tests;
using HoloToolkit.Unity.InputModule.Utilities.Interactions;

public class SetObjectManipulation : MonoBehaviour, IInputClickHandler
{
    public GameObject WeaManipulator;
    private string name;

    void Start()
    {
        name = gameObject.name;
       
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if(name == "Move")
        {
            WeaManipulator.GetComponent<HandDraggable>().enabled = true;
            WeaManipulator.GetComponent<NavigationRotateResponder>().enabled = false;
            WeaManipulator.GetComponent<TwoHandManipulatable>().enabled = false;
        }

        if (name == "Rotate")
        {
            WeaManipulator.GetComponent<HandDraggable>().enabled = false;
            WeaManipulator.GetComponent<NavigationRotateResponder>().enabled = true;
            WeaManipulator.GetComponent<TwoHandManipulatable>().enabled = false;
        }

        if (name == "Scale")
        {
            WeaManipulator.GetComponent<HandDraggable>().enabled = false;
            WeaManipulator.GetComponent<NavigationRotateResponder>().enabled = false;
            WeaManipulator.GetComponent<TwoHandManipulatable>().enabled = true;
        }
    }
}
