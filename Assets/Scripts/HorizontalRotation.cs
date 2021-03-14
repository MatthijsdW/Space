using UnityEngine;

public class HorizontalRotation : MonoBehaviour
{
    [SerializeField]
    private float angularVelocity;

    void Start()
    {
        GetComponent<Rigidbody>().AddTorque(new Vector3(0, angularVelocity, 0));
    }
}
