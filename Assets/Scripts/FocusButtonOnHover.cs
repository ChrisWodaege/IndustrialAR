using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class FocusButtonOnHover: MonoBehaviour, IFocusable
{
    public GameObject buttonSelector;
    public float speed  = 0.2f;
    private float value;
    private float scaleFactor;
    private float translationFactor;
    private bool isFocused;


   	void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_HoverColorOverride", Color.black);
        buttonSelector.GetComponent<MeshRenderer>().material.SetColor("_HoverColorOverride", Color.black);
    }
	// Update is called once per frame
	void Update () {

        
        if(isFocused == true)
        {
          
            value += speed;
            scaleFactor = Mathf.Lerp(0.7f, 0.9f, value);
            buttonSelector.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

            translationFactor = Mathf.Lerp(0, 0.05f, value);
            buttonSelector.transform.localPosition = new Vector3(0, 0, translationFactor);
        } else
        {
            value += speed;
            scaleFactor = Mathf.Lerp(0.9f, 0.7f, value);
            buttonSelector.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

            translationFactor = Mathf.Lerp(0.05f, 0, value);
            buttonSelector.transform.localPosition = new Vector3(0, 0, translationFactor);
        }

    }

    void IFocusable.OnFocusEnter()
    {
        value = 0;
        isFocused = true;
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_HoverColorOverride", Color.blue);
        buttonSelector.GetComponent<MeshRenderer>().material.SetColor("_HoverColorOverride", Color.blue);
    }

    void IFocusable.OnFocusExit()
    {
        value = 0;
        isFocused = false;
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_HoverColorOverride", Color.black);
        buttonSelector.GetComponent<MeshRenderer>().material.SetColor("_HoverColorOverride", Color.black);
    }

  
    
  
}
