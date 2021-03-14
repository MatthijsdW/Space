using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipControl : MonoBehaviour
{
    [SerializeField]
    private float thrustForce;
    [SerializeField]
    private float pitchTorque;
    [SerializeField]
    private float yawTorque;

    private Vector2 turnValue;
    private float thrustValue;

    private new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Rotation
        float yaw = turnValue.x * yawTorque * Time.deltaTime;
        float pitch = turnValue.y * pitchTorque * Time.deltaTime;
        rigidbody.AddRelativeTorque(-pitch, yaw, 0);

        //Forward movement
        float forwardForce = thrustValue * thrustForce * Time.deltaTime;
        rigidbody.AddRelativeForce(forwardForce * Vector3.forward);
    }

    public void OnTurn(InputAction.CallbackContext context)
    {
        turnValue = context.ReadValue<Vector2>();
    }

    public void OnThrust(InputAction.CallbackContext context)
    {
        thrustValue = context.ReadValue<float>();
    }
}
