using UnityEngine;

public class ItemPickable : MonoBehaviour, IPickable
{
    public ItemSO itemScriptableObject;

    public void PickItem()
    {
        // Notify the trigger zone before destroying the object
        NotifyTriggerExit();

        // Destroy the object
        Destroy(gameObject);
    }

    private void NotifyTriggerExit()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.1f);
        foreach (var collider in hitColliders)
        {
            var guardDetection = collider.GetComponent<GuardDetection>();
            if (guardDetection != null)
            {
                guardDetection.OnObjectPickedUp(gameObject);
            }
        }
    }
}
