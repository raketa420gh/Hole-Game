using UnityEngine;
using System;

public class DeadZone : MonoBehaviour
{
    public event Action<IInteractableObject, MagnetizableObject> OnObjectCollided;

    private void OnTriggerEnter(Collider other)
    {
        if (Game.isGameover)
            return;

        var goalObject = other.GetComponent<GoalObject>();
        var obstacle = other.GetComponent<Obstacle>();
        var magnetizableObject = other.GetComponent<MagnetizableObject>();

        if (goalObject)
        {
            OnObjectCollided?.Invoke(goalObject, magnetizableObject);
        }

        if (obstacle)
        {
            OnObjectCollided?.Invoke(obstacle, magnetizableObject);
        }

        Destroy(other.gameObject);
    }
}