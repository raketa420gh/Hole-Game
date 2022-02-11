using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private Spawner spawner;

    public void CalculateDifficulty(int currentLevel)
    {
        if (currentLevel >= 10)
        {
            spawner.SetChancesToSpawn(55, 65);
        }
        if (currentLevel >= 20)
        {
            spawner.SetChancesToSpawn(60, 60);
        }
        if (currentLevel >= 30)
        {
            spawner.SetChancesToSpawn(65, 55);
        }
        if (currentLevel >= 40)
        {
            spawner.SetChancesToSpawn(70, 50);
        }
        if (currentLevel >= 50)
        {
            spawner.SetChancesToSpawn(75, 45);
        }
        if (currentLevel >= 60)
        {
            spawner.SetChancesToSpawn(80, 40);
        }
        if (currentLevel >= 70)
        {
            spawner.SetChancesToSpawn(75, 35);
        }
        if (currentLevel >= 80)
        {
            spawner.SetChancesToSpawn(80, 30);
        }
        if (currentLevel >= 90)
        {
            spawner.SetChancesToSpawn(85, 25);
        }
        if (currentLevel >= 100)
        {
            spawner.SetChancesToSpawn(90, 20);
        }
    }
}
