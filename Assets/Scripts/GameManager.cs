using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void TriggerGameOver() {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame() {
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
