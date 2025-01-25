using UnityEngine;

public class GuardDetection : MonoBehaviour
{
    [SerializeField] public GameObject logicRoomDoor; // Reference to Logic Room Door
    [SerializeField] private string burgerTag = "Burger"; // Tag for burger
    [SerializeField] private string donutPinkTag = "DonutPink"; // Tag for pink donut
    [SerializeField] private string donutBrownTag = "DonutBrown"; // Tag for brown donut

    private bool isPinkDonutInZone = false;
    private bool isBrownDonutInZone = false;
    private bool isBurgerInZone = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(burgerTag))
        {
            Debug.Log("Burger prefab entered the trigger zone!");
            isBurgerInZone = true;
        }

        if (other.CompareTag(donutPinkTag))
        {
            Debug.Log("Pink Donut prefab entered the trigger zone!");
            isPinkDonutInZone = true;
        }

        if (other.CompareTag(donutBrownTag))
        {
            Debug.Log("Brown Donut prefab entered the trigger zone!");
            isBrownDonutInZone = true;
        }

        UpdateDoorState();
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(burgerTag))
        {
            Debug.Log("Burger prefab exited the trigger zone!");
            isBurgerInZone = false;
        }

        if (other.CompareTag(donutPinkTag))
        {
            Debug.Log("Pink Donut prefab exited the trigger zone!");
            isPinkDonutInZone = false;
        }

        if (other.CompareTag(donutBrownTag))
        {
            Debug.Log("Brown Donut prefab exited the trigger zone!");
            isBrownDonutInZone = false;
        }

        UpdateDoorState();
    }

    public void OnObjectPickedUp(GameObject obj)
    {
        if (obj.CompareTag(burgerTag))
        {
            Debug.Log("Burger prefab was picked up!");
            isBurgerInZone = false;
        }

        if (obj.CompareTag(donutPinkTag))
        {
            Debug.Log("Pink Donut prefab was picked up!");
            isPinkDonutInZone = false;
        }

        if (obj.CompareTag(donutBrownTag))
        {
            Debug.Log("Brown Donut prefab was picked up!");
            isBrownDonutInZone = false;
        }

        UpdateDoorState();
    }

    private void UpdateDoorState()
    {
        if (isBurgerInZone && (isPinkDonutInZone || isBrownDonutInZone))
        {
            Debug.Log("Conditions met! Opening the door.");
            logicRoomDoor.GetComponent<Open_Door>().OpenDoor();
        }
        else
        {
            Debug.Log("Conditions not met! Closing the door.");
            logicRoomDoor.GetComponent<Open_Door>().CloseDoor();
        }
    }
}
