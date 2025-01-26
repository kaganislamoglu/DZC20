using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QR_Scanner_Script : MonoBehaviour
{
    public TextMeshProUGUI errorText;
    public TextMeshProUGUI victoryText;
    public Image[] qrPieces;

    public GameObject window;
    public GameObject fullQR;

    private bool validQR = true;

    private bool firstOpen = true;

    public void Scan() {
        for(int i = 0; i < qrPieces.Length; i++) {
            if(!qrPieces[i].color.Equals(Color.white)) {
                errorText.gameObject.SetActive(true);
                
                validQR = false;

                break;
            } 
        }

        if(validQR) {
            victoryText.gameObject.SetActive(true);
            window.SetActive(false);
        }
    }

    void OnEnable() {
        if(firstOpen) {
            firstOpen = false;
                fullQR.SetActive(true);
        }
        errorText.gameObject.SetActive(false);
        victoryText.gameObject.SetActive(false);
        validQR = true;
    }
    
}
