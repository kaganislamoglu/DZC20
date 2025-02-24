using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public float spawnTime = 1f;
    public float fadeOutTime = 5f;
    public Image tgLogo;
    private bool shown = false;

    public AudioSource source;
    public AudioClip clip;

    public Image qr1;
    public Image qr2;
    public Image qr3;
    public Image qr4;

    public Text pickUpText;
    public Text pickUpText2;
    public Text interactText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pickUpText.gameObject.SetActive(false);
        pickUpText2.gameObject.SetActive(false);

        interactText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!shown) {
            if (Time.time >= spawnTime) {
                Color tempColor = tgLogo.color;
                tempColor.a = 1f;
                tgLogo.color = tempColor;
                
                source.PlayOneShot(clip);

                shown = true;
            }
            
        }
        else if(tgLogo.color.a > 0) {
            Color tempColor = tgLogo.color;
                tempColor.a = tempColor.a - Time.deltaTime/fadeOutTime;
                tgLogo.color = tempColor;

        }
        else {
            this.enabled = false;
        }
    }
}
