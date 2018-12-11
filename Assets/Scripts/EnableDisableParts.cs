namespace HoloToolkit.Unity.InputModule.Tests
{
    using HoloToolkit.Unity.InputModule;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class EnableDisableParts : MonoBehaviour, IInputClickHandler
    {
        public GameObject[] MainBaugruppen;
        public GameObject layer;
        public float speed = 0.005f;
        private float value = 0;
        private float alpha = 1;
        private Material mat;
        private bool pressed = false;
        int start, end;

     
        void Update()
        {
            if (pressed == true && value <= 1)
            {
                value += speed;
                alpha = Mathf.Lerp(start, end, value);
                foreach (GameObject part in MainBaugruppen)
                {

                    mat = part.GetComponent<Renderer>().material;
                    Color currentColor = mat.color;
                    currentColor.a = alpha;
                    mat.color = currentColor;

                }
            }
      
            if (alpha <= 0)
            {
                layer.SetActive(false);
            }

            if (value >= 1)
            {
                foreach (GameObject part in MainBaugruppen)
                {
                    mat = part.GetComponent<Renderer>().material;
                    changeMaterialToOpaque();
                }

                pressed = false;
            }

        }

        public void OnInputClicked(InputClickedEventData eventData)
        {

            value = 0;
            pressed = true;

            foreach (GameObject part in MainBaugruppen)
            {
                mat = part.GetComponent<Renderer>().material;
                changeMaterialToTransparent();
            }

            if (layer.activeSelf == true)
            {
                DisableParts();

            }
            else
            {

                EnableParts();
            }
        }

        void DisableParts()
        {
            start = 1;
            end = 0;
        }

        void EnableParts()
        {
            layer.SetActive(true);

            start = 0;
            end = 1;

        }

        void changeMaterialToTransparent()
        {
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_ZWrite", 0);
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.EnableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = 3000;
        }

        void changeMaterialToOpaque()
        {
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            mat.SetInt("_ZWrite", 1);
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.DisableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = -1;
        }
    }
}