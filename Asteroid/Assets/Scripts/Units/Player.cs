using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : HealthUnit {
    private const int CollissionPlayerDamage = 1;
    public GameObject hpBar;

    private void OnTriggerEnter2D(Collider2D collision) {
        this.TakeDamage(CollissionPlayerDamage);
    }


    public override void TakeDamage(int damage) {
        base.TakeDamage(damage);
        CheckHpBar();
    }

    private void CheckHpBar() {
        Image[] healthBars = hpBar.GetComponentsInChildren<Image>();
        for (int i = 0; i < healthBars.Length; i++) {
            if (i > health) {
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
