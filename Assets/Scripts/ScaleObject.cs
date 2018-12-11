using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour, IInputClickHandler
{

    public Vector3 ScaleChange;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        transform.localScale += ScaleChange;
    }
}
