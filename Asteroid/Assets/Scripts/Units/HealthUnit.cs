using UnityEngine;

public class HealthUnit : MonoBehaviour {

    public int health;
    public GameObject deathEffect;

    public virtual void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0)
            Die();
    }

    protected virtual void Die() {
        if (deathEffect != null) {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }
}
