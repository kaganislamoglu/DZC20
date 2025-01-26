using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Math_Trophy_Script : MonoBehaviour
{
    public TextMeshProUGUI errorText;
    public TextMeshProUGUI victoryText;
    
    public GameObject door;

    public GameObject fullMatrix;

    public TMP_InputField tlInput;
    public TMP_InputField trInput;
    public TMP_InputField blInput;
    public TMP_InputField brInput;

    private bool firstOpen = true;

    public void Scan() {
        
        errorText.gameObject.SetActive(false);
        victoryText.gameObject.SetActive(false);

        
        int tl, tr, bl, br;

        
        if (!int.TryParse(tlInput.text, out tl) ||
            !int.TryParse(trInput.text, out tr) ||
            !int.TryParse(blInput.text, out bl) ||
            !int.TryParse(brInput.text, out br))
        {
            errorText.gameObject.SetActive(true);
            return;
        }

        if (tl == -2 && tr == -1 && bl == 8 && br == 4) {
            door.GetComponent<Open_Door>().OpenDoor();
            victoryText.gameObject.SetActive(true);
        }

        else {
            errorText.gameObject.SetActive(true);
        }
        
           
    }

    void OnEnable() {
        if(firstOpen) {
            firstOpen = false;
            fullMatrix.SetActive(true);
        }
        errorText.gameObject.SetActive(false);
        victoryText.gameObject.SetActive(false);
    }
    
}
