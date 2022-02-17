using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(SphereCollider))]

public class Magnet : MonoBehaviour
{
    [SerializeField] private float magnetForce;

    private bool isActive;
    private List<MagnetizableObject> affectedMagnetizableObjects = new List<MagnetizableObject>();

    public void Initialize()
    {
        affectedMagnetizableObjects.Clear();
        Activate();
    }
    public void Activate()
    {
        isActive = true;
    }

    public void Deactivate()
    {
        isActive = false;
    }

    private void FixedUpdate()
    {
        if (!isActive)
            return;

        foreach (MagnetizableObject magnetizableObject in affectedMagnetizableObjects)
        {
            magnetizableObject.Magnetize(
                (transform.position - magnetizableObject.transform.position)
                * (magnetForce * Time.fixedDeltaTime));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive)
            return;

        MagnetizableObject magnetizableObject = other.GetComponent<MagnetizableObject>();

        if (magnetizableObject != null)
            AddToMagnetField(magnetizableObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isActive)
            return;

        MagnetizableObject magnetizableObject = other.GetComponent<MagnetizableObject>();

        if (magnetizableObject != null)
            RemoveFromMagnetField(magnetizableObject);
    }

    public void AddToMagnetField(MagnetizableObject magnetizableObject) => 
        affectedMagnetizableObjects.Add(magnetizableObject);

    public void RemoveFromMagnetField(MagnetizableObject magnetizableObject) => 
        affectedMagnetizableObjects.Remove(magnetizableObject);
}
