using UnityEngine;
using DG.Tweening;
using System.Collections;

public class GameEventsHandler : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private FXManager fxManager;
    [SerializeField] private HoleManager holeManager;
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private DifficultyManager difficultyManager;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private DeadZone deadZone;
    [SerializeField] private Magnet magnet;
    [SerializeField] private Spawner spawner;
    [SerializeField] private ObjectsCounter objectsCounter;

    private void OnEnable()
    {
        deadZone.OnObjectCollided += OnObjectDeadZoneEntered;
        levelManager.OnLevelStarted += OnLevelStarted;
        objectsCounter.OnAllGoalObjectsCollected += OnAllGoalObjectsCollected;
    }

    private void OnDisable()
    {
        deadZone.OnObjectCollided -= OnObjectDeadZoneEntered;
        levelManager.OnLevelStarted -= OnLevelStarted;
        objectsCounter.OnAllGoalObjectsCollected -= OnAllGoalObjectsCollected;
    }

    private void OnLevelStarted(int currentLevel)
    {
        difficultyManager.CalculateDifficulty(currentLevel);
        spawner.SpawnRandomAllObjects();
        objectsCounter.CountInteractableObjects();
        
        holeManager.Initialize();
        magnet.Initialize();

        uiManager.Fade();
        uiManager.UpdateLevelProgressBar(objectsCounter.GetGoalObjectsAmountNormilized());
        uiManager.SetLevelText(currentLevel);
    }

    private void OnObjectDeadZoneEntered(IInteractableObject collidedObject, MagnetizableObject magnetizableObject)
    {
        magnet.RemoveFromMagnetField(magnetizableObject);

        if (collidedObject is GoalObject)
        {
            objectsCounter.DecreaseGoalObjectAmount();
            uiManager.UpdateLevelProgressBar(objectsCounter.GetGoalObjectsAmountNormilized());
        }

        if (collidedObject is Obstacle)
        {
            holeManager.Deactivate();

            Camera.main.transform.DOShakePosition(1f, .2f, 20, 90f);

            StartCoroutine((FinishLevelAfterDelayRoutine(1.5f)));
        }
    }

    private void OnAllGoalObjectsCollected()
    {
        holeManager.Deactivate();

        saveManager.SaveFinishedLevel(levelManager.CurrentLevel);
        fxManager.PlayConfetti();
        uiManager.ShowLevelCompletedPanel();

        StartCoroutine((FinishLevelAfterDelayRoutine(2.5f)));
    }

    private IEnumerator FinishLevelAfterDelayRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        sceneLoader.ReloadScene();

        yield break;
    }
}
