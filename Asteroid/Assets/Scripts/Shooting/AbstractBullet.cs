using UnityEngine;

public class AbstractBullet<T> : MonoBehaviour where T : HealthUnit {
    public int damage;
    public GameObject hitEffect;

    void OnTriggerEnter2D(Collider2D collision) {
        if (hitEffect != null) {
            GameObject hitEffect = Instantiate(this.hitEffect, transform.position, Quaternion.identity);
            Destroy(hitEffect, 1f);
        }

        T enemy = collision.GetComponent<T>();
        if (enemy != null) {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}