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

    private Boolean validQR = true;

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
        errorText.gameObject.SetActive(false);
        victoryText.gameObject.SetActive(false);
        validQR = true;
    }
    
}
