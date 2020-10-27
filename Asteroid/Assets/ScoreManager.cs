using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text textNumber;

    [HideInInspector]
    public int totalScore = 0;

    private static ScoreManager instance;

    public static ScoreManager GetInstance { get { return instance; } }

    #region delegate
    //Here we can use a delegate Event, for example:

    //public void delegate OnScoreChanged(int score);
    //public OnScireChanged onScorechanged;

    //This will allow us to get rid of update method
    //And call smth like AddAndPrintScore
    #endregion

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    void Update()
    {
        textNumber.text = totalScore.ToString();
    }

    public void AddScore(int score) {
        totalScore += score;
    }
}
