using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private Transform playerModel;
    [SerializeField] private float minimumAngle;
    [SerializeField] private float maximumAngle;
    [SerializeField] private float mouseSensitivity;
    public bool stickCamera;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
 
    void Update()
    {
        float aimX = Input.GetAxis("Mouse X");
        float aimY = Input.GetAxis("Mouse Y");
        var rotation = cameraTarget.rotation;
        rotation *= Quaternion.AngleAxis(aimX * mouseSensitivity,Vector3.up);
        rotation *= Quaternion.AngleAxis(-aimY * mouseSensitivity, Vector3.right);
        cameraTarget.rotation = rotation;


        var angleX = cameraTarget.localEulerAngles.x;
        Debug.Log(angleX);
        if(angleX > 180 && angleX < maximumAngle)
        {
            angleX = maximumAngle;
        }
        else if (angleX < 180 && angleX > minimumAngle)
        {
            angleX = minimumAngle;
        }
 
        cameraTarget.localEulerAngles = new Vector3(angleX, cameraTarget.localEulerAngles.y, 0);
 
        if (stickCamera)
        {
            playerModel.rotation = Quaternion.Euler(0, cameraTarget.rotation.eulerAngles.y, 0);
        }
    }
}
