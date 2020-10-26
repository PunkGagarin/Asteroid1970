using UnityEngine;

public class Bullet : MonoBehaviour {

    public int damage = 60;
    public GameObject hitEffect;

    void OnTriggerEnter2D(Collider2D collision) {
        if (hitEffect != null) {
            GameObject hitEffect = Instantiate(this.hitEffect, transform.position, Quaternion.identity);
            Destroy(hitEffect, 1f);
        }

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
