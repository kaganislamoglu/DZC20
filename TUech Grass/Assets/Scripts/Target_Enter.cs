using UnityEngine;
using UnityEngine.Events;

public class Target_Enter : MonoBehaviour
{
    public UnityEvent onEnter;
    
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Ball") {
            onEnter.Invoke();
        }
    }
}
