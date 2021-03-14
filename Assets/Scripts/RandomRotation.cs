using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    [SerializeField]
    private float angularVelocity;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * angularVelocity;
    }
}