using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class OpenUI_Interaction : MonoBehaviour
{
    public Text interactText;
    public Canvas mainUI;
    public Canvas newUI;
    private Boolean menuOpen = false;

    public FirstPersonController fps;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if(menuOpen && Input.GetKey(KeyCode.Escape)) 
        {

            menuOpen = false;

            Time.timeScale = 1;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            fps.enabled = true;

            mainUI.gameObject.SetActive(true);
            newUI.gameObject.SetActive(false);
                
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
                
                Time.timeScale = 0;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                fps.enabled = false;

                mainUI.gameObject.SetActive(false);
                newUI.gameObject.SetActive(true);
                
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
