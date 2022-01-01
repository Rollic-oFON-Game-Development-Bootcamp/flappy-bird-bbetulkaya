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

    [SerializeField] private PipeController pipeController;
    [SerializeField] private BirdController birdController;
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
            pipeController.isGameOver = true;
            birdController.enabled = false;
        }

    }
    public void GameStart()
    {
        UIManager.GamePlayPanel(true);
        birdController.enabled = true;
        pipeController.enabled = true;
    }
    public void UpdateScore()
    {
        ScoreManager.Instance.IncreaseScore(1);
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
