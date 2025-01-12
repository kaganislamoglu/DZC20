using UnityEngine;

namespace StarterAssets
{
    public class MouseToggleController : MonoBehaviour
    {
        public FirstPersonController firstPersonController; // Assign the FirstPersonController component in the Inspector
        private bool isCursorLocked = true; // Start with the cursor locked

        void Start()
        {
            // Ensure the cursor starts locked
            ToggleCursorLock(true);
        }

        void Update()
        {
            // Toggle cursor lock when the left Ctrl key is pressed
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                isCursorLocked = !isCursorLocked;
                ToggleCursorLock(isCursorLocked);
            }
        }

        private void ToggleCursorLock(bool lockCursor)
        {
            if (lockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                // Enable camera rotation in FirstPersonController
                if (firstPersonController != null)
                {
                    firstPersonController.enabled = true;
                }
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                // Disable camera rotation in FirstPersonController
                if (firstPersonController != null)
                {
                    firstPersonController.enabled = false;
                }
            }
        }
    }
}
