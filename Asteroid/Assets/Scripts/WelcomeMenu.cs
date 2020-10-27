using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeMenu : MonoBehaviour {

    public Text highScoreText;

    public void Start() {
        highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("highScore");
    }

    /**
     * Load main level of this game
     */
    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
