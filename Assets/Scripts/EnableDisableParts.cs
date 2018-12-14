namespace HoloToolkit.Unity.InputModule.Tests
{
    using HoloToolkit.Unity.InputModule;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class EnableDisableParts : MonoBehaviour, IInputClickHandler
    {
        public GameObject[] MainBaugruppen;
        public GameObject[] SubBaugruppen;
        public GameObject layer;
        public float speed = 0.02f;
        private float value = 0;
        private float alphaGeneral = 1;
        private float alphaWire = 0;
        private Material[] mat;
        private bool pressed = false;
        private bool wireIsActive;
        
        private int alphaSwitch = 1;
        int start, end;

     

        void Update()
        {
            
            if (pressed == true)
            {
                if (value <= 1)
                {
                    value += speed;
                    alphaGeneral = Mathf.Lerp(start, end, value);
                    alphaWire = Mathf.Lerp(end, start, value);
         
                    foreach (GameObject part in MainBaugruppen)
                    {
                        mat = part.GetComponent<Renderer>().materials;
                        
                        
                                             
                        if (name == "ShadedWire")
                        {
                            ChangeWireOpacity(alphaWire);
                        } else
                        {
                            Debug.Log("Wire: " + wireIsActive);
                            if (wireIsActive)
                            {
                                
                                ChangeWireOpacity(alphaGeneral);
                            }                      
                            changeMaterialToTransparent();
                            ChangeShadedOpacity();
                        }
                    }
                }

                if (alphaGeneral <= 0 && name != "ShadedWire")
                {
                    layer.SetActive(false);
                }

                if (value >= 1)
                {
                    foreach (GameObject part in MainBaugruppen)
                    {
                        mat = part.GetComponent<Renderer>().materials;
                        changeMaterialToOpaque();
                    }
                    

                    pressed = false;

                    if (alphaSwitch == 1)
                    {
                        alphaSwitch = -1;
                    } else if (alphaSwitch == -1)
                    {
                        alphaSwitch = 1;
                    }

                    foreach (GameObject subPart in SubBaugruppen)
                    {
                        if (subPart.activeSelf == true && alphaGeneral > 0.99f)
                        {
                            subPart.SetActive(false);
                        }
                    }

                }
 
            }
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            value = 0;
            pressed = true;

            foreach (GameObject subPart in SubBaugruppen)
            {
                if(subPart.activeSelf == false)
                {
                    subPart.SetActive(true);
                }
            }

            if (name == "ShadedWire")
            {
                Debug.Log("in");
                if (wireIsActive == true)
                {
                     wireIsActive = false;
                }
                else
                {
                       wireIsActive = true;
                }
            }

            Debug.Log(wireIsActive);

            if (pressed == true)
            {
                if (alphaSwitch == 1)
                {
                    start = 1;
                    end = 0;
                }
                if (alphaSwitch == -1)
                {
                    if (name != "ShadedWire")
                    {
                        layer.SetActive(true);
                    }
                    start = 0;
                    end = 1;
                }
            }
        }

        
        void ChangeShadedOpacity()
        {
            Color currentColor = mat[0].color;
            currentColor.a = alphaGeneral;
            mat[0].color = currentColor;
           
        }

        void ChangeWireOpacity(float alpha)
        {
            Color currentColor = mat[1].GetColor("_WireColor");
            currentColor.a = alpha;
            mat[1].SetColor("_WireColor", currentColor);

        }

        void changeMaterialToTransparent()
        {
            mat[0].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat[0].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat[0].SetInt("_ZWrite", 0);
            mat[0].DisableKeyword("_ALPHATEST_ON");
            mat[0].EnableKeyword("_ALPHABLEND_ON");
            mat[0].DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat[0].renderQueue = 3000;
        }

        void changeMaterialToOpaque()
        {
            mat[0].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            mat[0].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            mat[0].SetInt("_ZWrite", 1);
            mat[0].DisableKeyword("_ALPHATEST_ON");
            mat[0].DisableKeyword("_ALPHABLEND_ON");
            mat[0].DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat[0].renderQueue = -1;
        }
    }
}
