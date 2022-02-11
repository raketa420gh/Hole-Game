using System;
using UnityEngine;

[RequireComponent(typeof(LevelColors))]

public class LevelManager : MonoBehaviour
{
	[SerializeField] private SaveManager saveManager;

	private LevelColors levelColors;
	private int currentLevel;

	public event Action<int> OnLevelStarted;

	public int CurrentLevel => currentLevel;

    private void Awake()
    {
		levelColors = GetComponent<LevelColors>();
    }

    private void Start()
	{
		levelColors.UpdateLevelColors();

		currentLevel = saveManager.GetLastFinishedLevel() + 1;

		OnLevelStarted?.Invoke(currentLevel);
	}
}
