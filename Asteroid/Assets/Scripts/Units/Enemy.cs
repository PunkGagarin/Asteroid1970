using UnityEngine;

public class Enemy : HealthUnit {

    public int score = 50;
    ScoreManager scoreManager;

    private void Awake() {
        scoreManager = ScoreManager.GetInstance;
    }

    protected override void Die() {
        base.Die();
        scoreManager.AddScore(score);
        Destroy(gameObject);
        //TODO: spawn an Asteroids
    }
}
