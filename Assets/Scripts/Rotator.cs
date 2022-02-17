using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] [Range(0, 360)] private float x;
    [SerializeField] [Range(0, 360)] private float y;
    [SerializeField] [Range(0, 360)] private float z;

    private void Start()
    {
        Rotate();
    }

    private void Rotate()
    {
        Vector3 rotationAngles = transform.rotation.eulerAngles;
        Vector3 newAngles = new Vector3(rotationAngles.x + x, rotationAngles.y + y, rotationAngles.z + z);

        transform.rotation = Quaternion.Euler(newAngles);
    }
}