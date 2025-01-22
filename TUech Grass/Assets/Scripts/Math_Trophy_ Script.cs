using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Math_Trophy_Script : MonoBehaviour
{
    public TextMeshProUGUI errorText;
    public TextMeshProUGUI victoryText;
    
    public GameObject door;
    private bool liftDoor = false;

    void Update() {
    }
    public void Scan() {
        //for now just to test if it works

        
        liftDoor = true;
        print(liftDoor);
        door.GetComponent<Open_Door>().OpenDoor();
        victoryText.gameObject.SetActive(true);
           
    }

    void OnEnable() {
        errorText.gameObject.SetActive(false);
        victoryText.gameObject.SetActive(false);
    }
    
}
