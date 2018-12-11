using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class MenuController : MonoBehaviour, IInputClickHandler
{
    public GameObject menu;
    public float StepSize = 0.005f;
    public float distanceToCamera = 1;
    private bool isActive;

    // Use this for initialization
    void Start()
    {
        isActive = false;
        menu.SetActive(isActive);
    }

   
    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (isActive == false)
        {
     
            menu.SetActive(true);
            menu.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distanceToCamera;
            isActive = true;
        }
        else
        {
        
            menu.SetActive(false);
            isActive = false;
        }


    }

}