using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;


public class PlaySound : MonoBehaviour, IInputClickHandler
{
    private AudioSource interactionAudio;
    public AudioClip click;
    public AudioClip secondClick;


    private bool clickChanger = false;

    void Start()
    {
        interactionAudio = GetComponent<AudioSource>();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        PlayAudio();
        
    }
    public void PlayAudio()
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
}
