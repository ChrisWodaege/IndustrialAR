using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class MenuController : MonoBehaviour, IInputClickHandler
{
    public GameObject menu;
  
    public float distanceToCamera = 1;
    private bool isActive;

    public GameObject menuDistanceObject;
    public float menuFollowSpeed = 0.5f;
    private Vector3 velocity = Vector3.zero;
    private float distance;
    private bool menuPositionCorrectionFlag = false;
    public float scaleSpeed = 0.25f;
    private float start, end;
    private float value;
    // Use this for initialization

    void Start()
    {
        isActive = false;
        menu.SetActive(isActive);
        menu.transform.localScale = new Vector3(0.3458222f, 0, 0.003278186f);
     
    }

   
    void Update()
    {
     
        PositionTheMenu();

        if (isActive == true && menu.transform.localScale.y <= 0.34582229)
        {
            ScaleFadingMenu();
        }

        if(isActive == false && menu.transform.localScale.y >= 0)
        {
            ScaleFadingMenu();
        }

        if (menu.transform.localScale.y == 0)
        {
            menu.SetActive(false);
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (menu.activeSelf == false)
        {
            start = 0;
            end = 0.3458222f;
            value = 0;

            menu.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distanceToCamera;
            menu.SetActive(true);
            isActive = true;

        }
        else
        {
            start = 0.3458222f;
            end = 0;
            value = 0;
            
            isActive = false;

        }


    }

    void ScaleFadingMenu()
    {
        value += scaleSpeed;

        menu.transform.localScale = new Vector3(0.3458222f, Mathf.Lerp(start, end, value), 0.003278186f);
    }

    void PositionTheMenu()
    {
        distance = Vector3.Distance(menuDistanceObject.transform.position, menu.transform.position);


        if (isActive && distance > 0.5f || menuPositionCorrectionFlag == true)
        {

            menu.transform.position = Vector3.SmoothDamp(menu.transform.position, menuDistanceObject.transform.position, ref velocity, menuFollowSpeed);
          
            menuPositionCorrectionFlag = true;
            if (distance < 0.1f)
            {
             
                menuPositionCorrectionFlag = false;
            }

        }
    }
    
}