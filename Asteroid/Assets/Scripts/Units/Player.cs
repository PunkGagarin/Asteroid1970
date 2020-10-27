using UnityEngine;
using UnityEngine.UI;

public class Player : HealthUnit {
    public GameObject hpBar;

    #region Singleton
    private static Player instance;

    public static Player GetInstance { get { return instance; } }

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    #endregion

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

        Destroy(gameObject);
    }
}
