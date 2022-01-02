using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private static int numberOfLose;
    [SerializeField] private int maxLoseTime;
    [SerializeField] private int currentLevel;


    public void IncreaseNumberOfLose()
    {
        SetNumberOfLose(numberOfLose + 1);
    }

    private void SetNumberOfLose(int loseCount)
    {
        numberOfLose = loseCount;
        Debug.Log(numberOfLose);

    }

    public bool IsNextLevelLoad()
    {
        if (numberOfLose >= maxLoseTime)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public string CurrentLevel()
    {
        return SceneManager.GetActiveScene().name;
    }
}
