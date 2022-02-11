using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string lastFinishedLevelKey;

    public void SaveFinishedLevel(int level)
    {
        PlayerPrefs.SetInt(lastFinishedLevelKey, level);
    }

    public int GetLastFinishedLevel()
    {
        return PlayerPrefs.GetInt(lastFinishedLevelKey, 0);
    }

    public void ResetAllKeys()
    {
        PlayerPrefs.DeleteAll();
    }
}
