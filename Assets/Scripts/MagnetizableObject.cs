using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class MagnetizableObject : MonoBehaviour
{
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Magnetize(Vector3 direction)
    {
        rigidbody.AddForce(direction);
    }
}
