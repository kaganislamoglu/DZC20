using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Matrix_Interact : MonoBehaviour
{

    public Image matrixPiece;

    public Image trophyUIPiece;
    public GameObject matrixBackground;
    public Text pickUpText;

    public bool pickupable;
    private static bool firstPiece = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        matrixPiece.gameObject.SetActive(false);
        trophyUIPiece.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other) 
    {
        if(pickupable && other.gameObject.tag == "Player") 
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            pickUpText.gameObject.SetActive(true);

            if(Input.GetKey(KeyCode.E)) 
            {
                matrixPiece.gameObject.SetActive(true);
                trophyUIPiece.gameObject.SetActive(true);
                pickUpText.gameObject.SetActive(false);

                if(firstPiece) {
                    firstPiece = false;
                    matrixBackground.SetActive(true);
                }
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(pickupable && other.gameObject.tag == "Player") 
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            pickUpText.gameObject.SetActive(false);
        }
    }

}
