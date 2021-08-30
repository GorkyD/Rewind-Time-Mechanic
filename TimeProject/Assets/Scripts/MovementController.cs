using UnityEngine;
public class MovementController : MonoBehaviour
{
    [SerializeField] private Transform playerModel;
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private float speed = 3f; 
    private Transform _mainCamera;
    
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