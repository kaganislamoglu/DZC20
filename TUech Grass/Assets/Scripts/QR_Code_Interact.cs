using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QR_Code_Interact : MonoBehaviour
{

    public Image qrCodeCorner;
    public GameObject highlight;
    public Text pickUpText;
    public Color inactiveColor = new Color(0.25f, 0.25f, 0.25f, 0.8f);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highlight.SetActive(false);
        qrCodeCorner.color = inactiveColor;
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Player") 
        {
            highlight.SetActive(true);
            pickUpText.gameObject.SetActive(true);

            if(Input.GetKey(KeyCode.E)) 
            {
                qrCodeCorner.color = Color.white;
                pickUpText.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") 
        {
            highlight.SetActive(false);
            pickUpText.gameObject.SetActive(false);
        }
    }

}
