using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI = null;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // Enforce the Singleton Pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void TriggerGameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        // Set score to 0
        ScoreManager.Instance.ResetScore();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        // Logs a message to the console to confirm it works in the editor
        Debug.Log("Game is exiting...");

        // Closes the application (only works in a built standalone game)
        Application.Quit();

#if UNITY_EDITOR
        // Safely exits play mode inside the Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
