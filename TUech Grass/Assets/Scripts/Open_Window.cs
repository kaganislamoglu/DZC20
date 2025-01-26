using System.Collections;
using UnityEngine;

public class Open_Window : MonoBehaviour
{
    private bool openWindow = false;
    public GameObject[] lights; // Array to hold the light GameObjects

    public GameObject[] closelights;
    public float lightActivationDelay = 0.5f; // Delay between enabling lights

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < 8 && openWindow)
        {
            this.transform.Translate(Vector3.up * 1/2 * Time.deltaTime);
        }
        if (this.transform.position.y > 2.87 && !openWindow)
        {
            this.transform.Translate(Vector3.down * 2 * Time.deltaTime);
        }
    }

    public void OpenWindow()
    {
        openWindow = true;
        StartCoroutine(EnableLights());
    }

    public void CloseWindow()
    {
        openWindow = false;
    }

    private IEnumerator EnableLights()
    {
        foreach (GameObject light in closelights)
        {
            light.SetActive(false);
        }
        foreach (GameObject light in lights)
        {
            light.SetActive(true); // Enable the light GameObject
            yield return new WaitForSeconds(lightActivationDelay); // Wait before enabling the next light
        }
    }
}
