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

    void PlayAudio()
    {
        if (clickChanger == false)
        {
            PlayClick();
        }
        if (clickChanger == true)
        {
            PlaySecondClick();
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

    public void PlayClick()
    {
        interactionAudio.clip = click;
        interactionAudio.Play();
    }

    public void PlaySecondClick()
    {
        interactionAudio.clip = secondClick;
        interactionAudio.Play();

       
    }
}
