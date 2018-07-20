using UnityEngine;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Examples
{
    // This script is a simple example of how an interactive item can
    // be used to change things on gameobjects by handling events.
    public class ExampleInteractiveItem : MonoBehaviour
    {
        int count = 0;
        int increment = 1;
        float timer = Time.time;
        bool gazedAt = false;
        [SerializeField] private Material m_NormalMaterial;                
        [SerializeField] private Material m_OverMaterial;                  
        [SerializeField] private Material m_ClickedMaterial;               
        [SerializeField] private Material m_DoubleClickedMaterial;         
        [SerializeField] private VRInteractiveItem m_InteractiveItem;
        [SerializeField] private Renderer m_Renderer;

        private void Awake ()
        {
            m_Renderer.material = m_NormalMaterial;
        }

        private void Update()
        {
            if (gazedAt)
            {
                count += increment;
                switch (count)
                {
                    case (1):
                        m_Renderer.material.color = new Color(0.882f, 0.996f, 0.992f, 1);
                        break;
                    case (50):
                        m_Renderer.material.color = new Color(0.670f, 0.988f, 0.984f, 1);
                        break;
                    case (100):
                        m_Renderer.material.color = new Color(0.454f, 0.988f, 0.984f, 1);
                        break;
                    case (300):
                        m_Renderer.material.color = new Color(0.003f, 0.796f, 0.780f, 1);
                        break;
                    case (400):
                        m_Renderer.material.color = new Color(0.003f, 0.796f, 0.780f, 1);
                        break;
                    case (600):
                        m_Renderer.material.color = new Color(0.003f, 0.796f, 0.486f, 1);
                        break;
                    case (800):
                        m_Renderer.material.color = new Color(0.003f, 0.796f, 0.301f, 1);
                        break;
                    case (900):
                        m_Renderer.material.color = new Color(0.505f, 0.796f, 0.003f, 1);
                        break;
                    case (1000):
                        m_Renderer.material.color = new Color(0.721f, 0.796f, 0.003f, 1);
                        break;
                    case (1200):
                        m_Renderer.material.color = new Color(0.960f, 0.929f, 0.141f, 1);
                        break;
                    case (1400):
                        m_Renderer.material.color = new Color(0.960f, 0.690f, 0.141f, 1);
                        break;
                    case (1500):
                        m_Renderer.material.color = new Color(0.960f, 0.521f, 0.141f, 1);
                        break;
                    case (1600):
                        m_Renderer.material.color = new Color(0.960f, 0.317f, 0.141f, 1);
                        break;
                    case (1700):
                        m_Renderer.material.color = new Color(1.0f, 0.0f, 0.0f, 1);
                        break;
                }
                //m_Renderer.material.color = new Color((0.0f + (count / 11000)), (1.0f - (count / 1500)), (1.0f - (count / 1000)), 1);
                // m_Renderer.material.color = Color.red * count / 1000;
              /*  if (count > 0 && count < 1000)
                    m_Renderer.material.color = new Color(0.0f, 0.0f + (count / 1000), 0.0f + (count / 100), 1);
                else if (count > 1000 && count < 2000)
                    m_Renderer.material.color = new Color(0.0f, 0.0f + (count / 100), 0.0f + (count / 1000), 1);
                else if (count > 2000 && count < 5000)
                    m_Renderer.material.color = Color.green * count / 1100;
                else if (count > 5000)
                    m_Renderer.material.color = Color.red * count / 1300;*/
            }

        }

        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_InteractiveItem.OnClick += HandleClick;
            m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
           
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
            m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
        }


        //Handle the Over event
        private void HandleOver()
        {
           // m_Renderer.material.color = Color.blue;
            gazedAt = true;
            Debug.Log(m_InteractiveItem.tag);
            //Debug.Log("Show over state");
            Debug.Log(count);
            // count += increment;
          
            /* if (count > 0 && count <100)
               m_Renderer.material.color = Color.green;
             else if (count > 100 && count < 200)
               m_Renderer.material.color = Color.blue;
             else if (count > 200 && count < 500)
                 m_Renderer.material.color = Color.cyan;
             else if (count > 500)
                 m_Renderer.material.color = Color.red;*/




        }


        //Handle the Out event
        private void HandleOut()
        {
            Debug.Log("Show out state");
            //m_Renderer.material = m_NormalMaterial;
            gazedAt = false;
            Debug.Log(count);
        }


        //Handle the Click event
        private void HandleClick()
        {
            Debug.Log("Show click state");
            m_Renderer.material = m_ClickedMaterial;
        }


        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
            Debug.Log("Show double click");
            m_Renderer.material = m_DoubleClickedMaterial;
        }
    }

}