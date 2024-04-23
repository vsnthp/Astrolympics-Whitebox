using UnityEngine;

public class VRCanvasController : MonoBehaviour
{
    public Transform cameraTransform; // Assign your VR Camera here

    void Update()
    {
        // Keep the canvas position in front of the camera
        transform.position = cameraTransform.position + cameraTransform.forward * 2f;

        // Make the canvas always face the camera
        transform.rotation = Quaternion.LookRotation(transform.position - cameraTransform.position);
    }
}