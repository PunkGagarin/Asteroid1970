using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text textNumber;

    [HideInInspector]
    public int currentScore = 0;

    private static ScoreManager instance;

    public static ScoreManager GetInstance { get { return instance; } }
    public int GetCurrentScore { get { return currentScore; } }

    #region delegate
    //Here we can use a delegate Event, for example:

    //public void delegate OnScoreChanged(int score);
    //public OnScireChanged onScorechanged;

    //This will allow us to get rid of update method
    //And call smth like AddAndPrintScore
    #endregion

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Update() {
        textNumber.text = currentScore.ToString();
    }

    public void AddScore(int score) {
        currentScore += score;
    }

    public void CheckHighScore() {
        int currentHighScore = PlayerPrefs.GetInt("highScore", 0);

        if (currentScore > currentHighScore) {
            PlayerPrefs.SetInt("highScore", currentScore);
        }
    }

    public int GetHighScore() {
        return PlayerPrefs.GetInt("highScore", 0);
    }
}
