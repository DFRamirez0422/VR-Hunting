using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 200f;
    public Transform playerBody; // assign capsule here
    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // Rotate camera up/down
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate capsule left/right
        if (playerBody != null)
            playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
    }
}
