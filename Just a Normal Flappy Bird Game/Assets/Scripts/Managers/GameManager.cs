using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance;
    public static GameManager Instance => instance ?? (instance = FindObjectOfType<GameManager>());
    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }
    #endregion

    [SerializeField] private PipeSpawner pipeSpawner;
    [SerializeField] private BirdController birdController;
    [SerializeField] private BirdAI birdAI;
    [SerializeField] private UIManager UIManager;
    [SerializeField] private LevelManager levelManager;

    // Controls variables
    [SerializeField] private bool isGameOverCalled = false;

    private void Start()
    {
        GameStart();
    }
    public void GameOver()
    {
        if (!isGameOverCalled)
        {
            isGameOverCalled = true;

            levelManager.IncreaseNumberOfLose();
            ScoreManager.Instance.SaveScore();

            UIManager.GameOverPanel(true);
            pipeSpawner.isGameOver = true;
        }

    }
    public void GameStart()
    {
        UIManager.GamePlayPanel(true);

        if (!(levelManager.CurrentLevel() == "Prototype2"))
        {
            birdController.enabled = true;
        }
        else
        {
            birdAI.enabled = true;
        }
        
        pipeSpawner.enabled = true;
    }
    public void UpdateScore(int value)
    {
        ScoreManager.Instance.SetCurrentScore(value);
        UIManager.UpdateScoreText(ScoreManager.Instance.GetCurrentScore());
    }
    public void Restart()
    {
        if (levelManager.IsNextLevelLoad())
        {
            levelManager.LoadLevel("Prototype2");
        }
        else
        {
            levelManager.LoadLevel(SceneManager.GetActiveScene().name);
        }
    }
}
