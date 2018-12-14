using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class StartStopAnimation : MonoBehaviour, IInputClickHandler, ISpeechHandler
{
    bool pressed = true;
    Animator anim;
    public GameObject animatedObject;


    void Start()
    {
        anim = animatedObject.GetComponent<Animator>();

    }
   
    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        SpeechInput(eventData.RecognizedText.ToLower());
    }

    public void SpeechInput(string command)
    {
        switch (command)
        {
            case "activate":
                UserInput();
                break;
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        UserInput();
       
   
    }

    public void UserInput()
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

   
}
