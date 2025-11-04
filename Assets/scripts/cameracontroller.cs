using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTarget;
    public float sensitivityX = 200f;
    public float sensitivityY = 100f;
    public float minY = -40f;
    public float maxY = 70f;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

        xRotation += mouseX;
        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, minY, maxY);

        cameraTarget.rotation = Quaternion.Euler(yRotation, xRotation, 0f);
    }
}
