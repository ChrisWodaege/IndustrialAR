using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;


public class PlaySound : MonoBehaviour, IInputClickHandler, IHoldHandler
{
    private AudioSource interactionAudio;
    public AudioClip click;
    public AudioClip secondClick;
    public AudioClip hold;

    private bool clickChanger = false;

    void Start()
    {
        interactionAudio = GetComponent<AudioSource>();



    }

    public void OnInputClicked(InputClickedEventData eventData)
    {

        if (clickChanger == false)
        {
            interactionAudio.clip = click;
            interactionAudio.Play();

        }
        if (clickChanger == true)
        {
            interactionAudio.clip = secondClick;
            interactionAudio.Play();

        }
        if (secondClick != null)
        {
            if (clickChanger == false)
            {
                clickChanger = true;
            }
            else
            {
                clickChanger = false;

            }
        }
    }


    public void OnHoldStarted(HoldEventData eventData)
    {
        if (hold != null)
        {
            interactionAudio.clip = hold;
            interactionAudio.Play();
        }
    }

    public void OnHoldCompleted(HoldEventData eventData)
    {

    }

    public void OnHoldCanceled(HoldEventData eventData)
    {
    
    }

}
