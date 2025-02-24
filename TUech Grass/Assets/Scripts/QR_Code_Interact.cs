using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QR_Code_Interact : MonoBehaviour
{

    public Image qrCodeCorner;
    public Text pickUpText;
    public Color inactiveColor;
    public GameObject fullQR;

    private static bool firstPiece = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        qrCodeCorner.color = inactiveColor;
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Player") 
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            pickUpText.gameObject.SetActive(true);

            if(Input.GetKey(KeyCode.E)) 
            {
                qrCodeCorner.color = Color.white;
                pickUpText.gameObject.SetActive(false);

                if(firstPiece) {
                    firstPiece = false;
                    fullQR.SetActive(true);
                }
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") 
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            pickUpText.gameObject.SetActive(false);
        }
    }

}
