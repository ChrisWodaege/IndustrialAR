using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class EnableDisableLable : MonoBehaviour, IInputClickHandler, ISpeechHandler
{
    bool pressed = false;
    public GameObject lable;
    private float scale = 0;
    public float speed = 0.1f;
    private float value = 0;
    int start, end;

  
    void Update()
    {
        if (pressed == true && value <= 1)
        {
            value += speed;
            scale = Mathf.Lerp(start, end, value);
            lable.transform.localScale = new Vector3(scale, scale, scale);
        }

        if (value >= 1)
        {
             pressed = false;
        }

        if (scale <= 0)
        {
            lable.SetActive(false);
        }

        
    }

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        SpeechInput(eventData.RecognizedText.ToLower());
    }

    public void SpeechInput(string command)
    {
        value = 0;
        pressed = true;

        switch (command)
        {
            case "inspect":
                if (lable.activeSelf == false) {
                    EnableLable();
                }
                break;

            case "disable":
                if (lable.activeSelf == true) {
                    DisableLabel();
                }
                break;
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        UserInput();
    }

    void UserInput()
    {
        value = 0;
        pressed = true;

        if (lable.activeSelf == true)
        {
            DisableLabel();
        }
        else
        {
            EnableLable();
        }
    }

    void EnableLable()
    {
        lable.SetActive(true);
        start = 0;
        end = 1;
    }

    void DisableLabel()
    {
        start = 1;
        end = 0;
    }
}
