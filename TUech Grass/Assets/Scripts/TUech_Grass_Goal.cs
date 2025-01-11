using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.UI;

public class TUech_Grass_Goal : MonoBehaviour
{
    public float spawnTime = 1f;
    public float fadeOutTime = 5f;
    public Image tgLogo;
    private bool shown = false;

    public AudioSource source;
    public AudioClip clip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            Debug.Log("off");
            this.enabled = false;
        }
    }
}
