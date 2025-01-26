using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class OpenUI_InteractionQR : MonoBehaviour
{
    public Text interactText;           // UI Text for interaction
    public Canvas uI;                   // Canvas to display UI
    private bool menuOpen = false;      // Tracks if the menu is open
    private bool windowTriggered = false; // Tracks if the window/lights action is triggered

    public FirstPersonController fps;  // Reference to the player controller
    public GameObject qrCodeScanner;   // Reference to the QR code scanner
    public Open_Window windowScript;   // Reference to the Open_Window script

    // Update is called once per frame
    void Update()
    {
        if (menuOpen && Input.GetKey(KeyCode.Escape)) 
        {
            CloseMenu();
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.tag == "Player") 
        {
            interactText.gameObject.SetActive(true);

            if (!menuOpen && Input.GetKey(KeyCode.E)) 
            {
                interactText.gameObject.SetActive(false);
                menuOpen = true;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                fps.enabled = false;
                uI.gameObject.SetActive(true);

                // Trigger window and lights if interacting with the QR code scanner
                if (!windowTriggered && gameObject == qrCodeScanner)
                {
                    windowTriggered = true; // Ensure this happens only once
                    windowScript.OpenWindow(); // Trigger the window and lights
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Player") 
        {
            interactText.gameObject.SetActive(false);
        }
    }

    private void CloseMenu()
    {
        menuOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fps.enabled = true;
        uI.gameObject.SetActive(false);
    }
}
