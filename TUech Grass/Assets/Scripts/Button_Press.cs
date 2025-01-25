using System;
using UnityEngine;
using UnityEngine.Events;

public class Button_Press : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask layerMask;
    public UnityEvent[] action;

    private int level = 0;

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Player") 
        {
            if(Input.GetMouseButton(0)) 
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit raycastHit,float.MaxValue, layerMask)){
                    if(raycastHit.collider.gameObject == gameObject) {
                        
                        action[level].Invoke();
                    }
                }
                
            }
        }
    }

    public void NextLevel() {
        level++;
    }
}
