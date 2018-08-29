using UnityEngine;
using VRStandardAssets.Utils;
using System.Collections;

namespace VRStandardAssets.Examples
{
    // This script is a simple example of how an interactive item can
    // be used to change things on gameobjects by handling events.
    public class ExampleInteractiveItem : MonoBehaviour
    {
        //a variable to hold the count
        int count = 0;
        //how much the count is incremented by 
        int increment = 1;
        //is an object being looked at?
        bool gazedAt = false;
        //to toggle the heatmap and eye tracker on/off
        bool transparent = false;
        //variables to change the materials when they are being looked at 
        [SerializeField] private Material m_NormalMaterial;
        [SerializeField] private Material m_OverMaterial;
        [SerializeField] private Material m_ClickedMaterial;
        [SerializeField] private Material m_DoubleClickedMaterial;
        [SerializeField] private VRInteractiveItem m_InteractiveItem;
        [SerializeField] private Renderer m_Renderer;
        [SerializeField] private int viewTime;

        //initally no materials are changed
        private void Awake()
        {
            m_Renderer.material = m_NormalMaterial;
           
        }

        private void Start()
        {
            StartCoroutine(Example());

        }

        //update at every frame
        private void Update()
        {
            if (gazedAt)
            {
                viewTime = count;
                count += increment;
            }

            //toggling the heatmap on/off
            if (Input.GetKeyDown("space"))
            {
                transparent = true;
            }

            if (Input.GetKeyDown("m"))
            {
                transparent = false;
            }


            if (transparent)
            {
                //0.01s - 0.83s
                if (count >= 1 && count < 50)
                    m_Renderer.material.color = new Color(0.882f, 0.996f, 0.992f, 1);
                //0.83s - 1.67s
                if (count >= 50 && count < 100)
                    m_Renderer.material.color = new Color(0.670f, 0.988f, 0.984f, 1);
                //1.67s - 2.5s
                if (count >= 100 && count < 150)
                    m_Renderer.material.color = new Color(0.454f, 0.988f, 0.984f, 1);
                //2.5s  - 3.3s -> over this time is considered staring
                if (count >= 150 && count < 200)
                    m_Renderer.material.color = new Color(0.505f, 0.796f, 0.003f, 1);
                //2.2s - 4.1s  
                if (count >= 200 && count < 250)
                    m_Renderer.material.color = new Color(0.960f, 0.929f, 0.141f, 1);
                //4.1 - 5s
                if (count >= 250 && count < 300)
                    m_Renderer.material.color = new Color(0.960f, 0.690f, 0.141f, 1);
                //5s - 5.8s
                if (count >= 300 && count < 350)
                    m_Renderer.material.color = new Color(0.960f, 0.521f, 0.141f, 1);
                //5.8s - 6.67s
                if (count >= 350 && count < 400)
                    m_Renderer.material.color = new Color(0.960f, 0.317f, 0.141f, 1);
                //>6.67s
                if (count >= 400)
                    m_Renderer.material.color = new Color(1.0f, 0.0f, 0.0f, 1);
               
            }
            else
                m_Renderer.material = m_NormalMaterial;

        }

        //detecting if there is an intersection between the raycast and object
        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
           
        }


        //Handle the Over event
        private void HandleOver()
        {
            
            gazedAt = true;
        }
   

        //Handle the Out event
        private void HandleOut()
        { 
            gazedAt = false;
            
        }

        //write to the lof file 
        void writeToLog(string message)
        {
            System.IO.File.AppendAllText(@"C:\Users\sc17smhh\Documents\LogFile.txt", message);
           
           
           m_InteractiveItem 
        }

        IEnumerator Example()
        {
            //write the log file after 2min
            yield return new WaitForSeconds(120);
              Debug.Log("count " + count + " object " + m_InteractiveItem.name);
              writeToLog(" Time viewed: " + count + " Object: " + m_InteractiveItem.name+ '\n');
             

        }


    }

}
