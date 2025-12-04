using UnityEngine;

public class EnableMouseCursor : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true;                  // Make the cursor visible
    }
}
