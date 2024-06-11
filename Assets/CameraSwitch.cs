using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera thirdPersonCamera;
    public Camera firstPersonCamera;

    [HideInInspector]
    public bool isThirdPerson = true;

    void Start()
    {
        thirdPersonCamera.enabled = true;
        firstPersonCamera.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            isThirdPerson = !isThirdPerson;
            thirdPersonCamera.enabled = isThirdPerson;
            firstPersonCamera.enabled = !isThirdPerson;
        }
    }
}
