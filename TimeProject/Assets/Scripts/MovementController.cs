using UnityEngine;
public class MovementController : MonoBehaviour
{
    public Transform playerModel;
    private Transform _mainCamera;
    public new Rigidbody rigidbody;
    public float speed = 3f; 
 
    void Start()
    {
        if (Camera.main is { }) _mainCamera = Camera.main.transform;
    }
 
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 camF = _mainCamera.forward;
        Vector3 camR = _mainCamera.right;
        camF.y = 0f;
        camR.y = 0f;
 
        Vector3 movingVector = horizontal * camR.normalized + vertical * camF.normalized;
        if (!_mainCamera.GetComponent<FollowCam>().stickCamera)
        {
            if (movingVector.magnitude >= 0.2f)
            {
                playerModel.rotation = Quaternion.LookRotation(camF, Vector3.up);
            }
        }
 
        rigidbody.velocity = movingVector * speed;
    }
}