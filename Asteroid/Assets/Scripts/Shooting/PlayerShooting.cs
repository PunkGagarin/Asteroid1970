using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public Transform firepoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    GameManager gameManager;

    private void Start() {
        gameManager = GameManager.GetInstance;
    }

    void Update() {
        if (gameManager.isGameOver)
            return;

        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
    }

    private void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 3f);
    }
}
