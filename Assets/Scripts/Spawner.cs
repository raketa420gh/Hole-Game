using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] spawnPoints;
    [SerializeField] private Obstacle[] obstaclePrefabs;
    [SerializeField] private GoalObject[] goalObjectPrefabs;

    [Header("Parent Transforms")]
    [SerializeField] private Transform obstacleParent;
    [SerializeField] private Transform goalObjectParent;

    [Header("Spawn Probabilities")]
    [SerializeField] [Range(0, 100)] private int chanceToSpawn = 50;
    [SerializeField] [Range(0, 100)] private int goalObjectsProportion = 70;

    public void SetChancesToSpawn(int chance, int goalObjectsProportion)
    {
        if (chance < 0)
        {
            chance = 0;
        }
        else if (chance > 100)
        {
            chance = 100;
        }
        else
        {
            chanceToSpawn = chance;
        }

        if (goalObjectsProportion < 0)
        {
            goalObjectsProportion = 0;
        }
        else if (goalObjectsProportion > 100)
        {
            goalObjectsProportion = 100;
        }
        else
        {
            this.goalObjectsProportion = goalObjectsProportion;
        }
    }

    public void SpawnRandomAllObjects()
    {
        foreach (var spawnPoint in spawnPoints)
        {
            if (GetProbabilityConfirmed(chanceToSpawn))
            {
                if (GetProbabilityConfirmed(goalObjectsProportion))
                {
                    SpawnRandomGoalObject(spawnPoint.transform.position);
                }
                else
                {
                    SpawnRandomObstacle(spawnPoint.transform.position);
                }
            }
        }
    }

    private void SpawnRandomGoalObject(Vector3 position)
    {
        var randomGoalObject = goalObjectPrefabs[GetRandomGoalObjectPrefabsIndex()];

        Instantiate(randomGoalObject, position, Quaternion.identity, goalObjectParent);
    }

    private void SpawnRandomObstacle(Vector3 position)
    {
        var randomObstacle = obstaclePrefabs[GetRandomObstaclePrefabsIndex()];

        Instantiate(randomObstacle, position, Quaternion.identity, obstacleParent);
    }

    private int GetRandomObstaclePrefabsIndex()
    {
        var randomIndex = Random.Range(0, obstaclePrefabs.Length);

        return randomIndex;
    }

    private int GetRandomGoalObjectPrefabsIndex()
    {
        var randomIndex = Random.Range(0, goalObjectPrefabs.Length);

        return randomIndex;
    }

    private bool GetProbabilityConfirmed(int probability)
    {
        var random = Random.Range(1, 100);

        if (probability == 0)
        {
            return false;
        }

        if (probability >= random)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}