using UnityEngine;

public class MagnetizableObject : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;

    private void Awake()
    {
        if (!rigidbody)
            rigidbody = GetComponent<Rigidbody>();
    }

    public void Magnetize(Vector3 direction)
    {
        rigidbody.AddForce(direction);
    }
}
