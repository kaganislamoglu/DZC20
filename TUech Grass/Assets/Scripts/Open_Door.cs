using System;
using UnityEngine;

public class Open_Door : MonoBehaviour
{
    private bool openDoor = false;
    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < 6 && openDoor) {
            this.transform.Translate(Vector3.up * 2 * Time.deltaTime);
        }
    }

    public void OpenDoor(){
        openDoor = true;
    }
}
