using UnityEngine;

public class UFOBullet : MonoBehaviour {
    public int damage = 1;
    public GameObject hitEffect;

    void OnTriggerEnter2D(Collider2D collision) {
        if (hitEffect != null) {
            GameObject hitEffect = Instantiate(this.hitEffect, transform.position, Quaternion.identity);
            Destroy(hitEffect, 1f);
        }

        Player enemy = collision.GetComponent<Player>();
        if (enemy != null) {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
