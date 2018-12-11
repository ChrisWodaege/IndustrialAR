using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class StartStopAnimation : MonoBehaviour, IInputClickHandler, IInputHandler
{
    bool pressed = true;
    Animator anim;
    public GameObject animatedObject;


    void Start()
    {
        anim = animatedObject.GetComponent<Animator>();

    }

    public void OnInputClicked(InputClickedEventData eventData)
    {

        if (pressed == false)
        {

            pressed = true;
            anim.SetFloat("startStopValue", 1f);
            Debug.Log(1);
        }
        else
        {
            pressed = false;
            anim.SetFloat("startStopValue", 0);
            Debug.Log(0);
        }
   
    }

    public void OnInputDown(InputEventData eventData)
    { }
    public void OnInputUp(InputEventData eventData)
    { }
}
