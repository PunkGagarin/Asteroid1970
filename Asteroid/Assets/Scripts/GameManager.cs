using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject gameOverUI;
    public Text currentScore;
    public Text highScore;

    ScoreManager scoreManager;

    #region Singleton
    private static GameManager instance;

    public static GameManager GetInstance { get { return instance; } }

    public void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    #endregion

    private void Start() {
        scoreManager = ScoreManager.GetInstance;
    }

    public void GameOver() {
        scoreManager.CheckHighScore();

        currentScore.text = "CURRENT SCORE: " + scoreManager.GetCurrentScore;
        highScore.text = "HIGH SCORE: " + scoreManager.GetHighScore();
        gameOverUI.SetActive(true);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit() {
        Debug.Log("Quiting the game!");
        Application.Quit();
    }
}
