using UnityEngine;
using System;

public class ObjectsCounter : MonoBehaviour
{
	private int currentGoalObjectsAmount;
	private int totalGoalObjectsAmount;

	public event Action OnAllGoalObjectsCollected;

	public int CurrentGoalObjectsAmount => currentGoalObjectsAmount;
	public int TotalGoalObjectsAmount => totalGoalObjectsAmount;

	public void CountInteractableObjects()
	{
		totalGoalObjectsAmount = FindObjectsOfType<GoalObject>().Length;
		currentGoalObjectsAmount = totalGoalObjectsAmount;
	}

	public void DecreaseGoalObjectAmount()
	{
		currentGoalObjectsAmount--;

		if (currentGoalObjectsAmount <= 0)
        {
			currentGoalObjectsAmount = 0;

			OnAllGoalObjectsCollected?.Invoke();
        }
	}

	public float GetGoalObjectsAmountNormilized()
    {
		return (float) (totalGoalObjectsAmount - currentGoalObjectsAmount) / totalGoalObjectsAmount;
    }
}
