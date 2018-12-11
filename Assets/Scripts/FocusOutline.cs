
using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace cakeslice
{
    public class FocusOutline : MonoBehaviour, IFocusable
    {

        // Use this for initialization
        void Start()
        {
            gameObject.GetComponent<Outline>().enabled = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void IFocusable.OnFocusEnter()
        {
            gameObject.GetComponent<Outline>().enabled = true;
        }

        void IFocusable.OnFocusExit()
        {
            gameObject.GetComponent<Outline>().enabled = false;
        }
    }
}
