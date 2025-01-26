using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public Light spotlight; // Assign the Light component in the Inspector
    public float offIntensity = 0f; // Intensity when the spotlight is off
    public float onIntensity = 10f; // Intensity when the spotlight is on

    private bool isSpotlightActive = true; // Track the state of the spotlight

    void Update()
    {
        // Check if the "F" key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Toggle the intensity of the spotlight
            if (spotlight != null)
            {
                isSpotlightActive = !isSpotlightActive;
                spotlight.intensity = isSpotlightActive ? onIntensity : offIntensity;
            }
            else
            {
                Debug.LogWarning("Spotlight Light component is not assigned.");
            }
        }
    }
}
