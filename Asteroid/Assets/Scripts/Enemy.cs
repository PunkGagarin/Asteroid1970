using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public int score = 50;

    public GameObject deathEffect;

    public void TakeDamage(int damage) {
        health -= damage;

        if(health <= 0) {
            Die();
        }
    }

    private void Die() {
        if (deathEffect != null) {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
        ScoreManager.GetInstance.AddScore(score);
        Destroy(gameObject);
    }
}
