using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class OpenUI_Interaction : MonoBehaviour
{
    public Text interactText;
    public Canvas uI;
    private bool menuOpen = false;

    public FirstPersonController fps;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if(menuOpen && Input.GetKey(KeyCode.Escape)) 
        {

            menuOpen = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            fps.enabled = true;

            uI.gameObject.SetActive(false);
                
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Player") 
        {
            
            interactText.gameObject.SetActive(true);

            if(!menuOpen && Input.GetKey(KeyCode.E)) 
            {
                interactText.gameObject.SetActive(false);

                menuOpen = true;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                fps.enabled = false;

                uI.gameObject.SetActive(true);
                
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") 
        {
            interactText.gameObject.SetActive(false);
        }
    }

}
