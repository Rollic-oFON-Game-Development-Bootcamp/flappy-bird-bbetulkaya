using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Level1
    [SerializeField] private static int numberOfLose;
    [SerializeField] private int maxLoseTime;

    // Level2
    [SerializeField] private float maxPlayTime;
    [SerializeField] private float timeElapsed;


    private void Start()
    {
        if (CurrentLevel() == "Prototype2") StartCoroutine(Level2PlayTime());
    }

    public void IncreaseNumberOfLose()
    {
        numberOfLose += 1;
    }

    public bool IsLevel1Complete()
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

    IEnumerator Level2PlayTime()
    {
        yield return new WaitForSeconds(maxPlayTime);
        LoadLevel("Prototype3");
    }
}
