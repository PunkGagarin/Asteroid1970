using UnityEngine;
using UnityEngine.UI;

public class Player : HealthUnit {
    private const int CollissionPlayerDamage = 1;
    public GameObject hpBar;

    GameManager gameManager;

    private void Start() {
        gameManager = GameManager.GetInstance;
    }

    public override void TakeDamage(int damage) {
        if (gameManager.isGameOver)
            return;

        base.TakeDamage(damage);
        CheckHpBar();
    }

    private void CheckHpBar() {
        Image[] healthBars = hpBar.GetComponentsInChildren<Image>();
        for (int i = 0; i < healthBars.Length; i++) {
            if (i > health - 1) {
                healthBars[i].enabled = false;
            }
        }
    }

    protected override void Die() {
        base.Die();

        GameManager.GetInstance.GameOver();

        Destroy(gameObject, .5f);
    }
}
