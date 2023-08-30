using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 100f;
    float yRotation = 0f;
    public float maxRotation = 25f;
    public float yRotationOffset = -90f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        // Get Mouse Input
        float x = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        // Change Y-Axis Rotation value
        yRotation += x;
        yRotation = Mathf.Clamp(yRotation, yRotationOffset + (-maxRotation), yRotationOffset + maxRotation); // Keep the angle restricted.

        // Apply rotation
        transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
