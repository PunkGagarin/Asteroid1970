using UnityEngine;

public class UFOShooting : MonoBehaviour {

    public float rotationSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firepoint;

    [Header("Shooting params")]
    public float bulletForce = 20f;
    public float attackSpeed = 2f;
    public float attackCooldown = 0f;
    public float attackRange = 7f;

    Player target;
    GameManager gameManager;


    void Start() {
        target = Player.GetInstance;
        gameManager = GameManager.GetInstance;
    }

    void Update() {
        if (gameManager.isGameOver)
            return;

        attackCooldown -= Time.deltaTime;

        FaceTarget();
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance <= attackRange) {
            Shoot();
        }
    }

    private void Shoot() {
        if (attackCooldown <= 0f) {
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
            Destroy(bullet, 3f);

            attackCooldown = 1f / attackSpeed;
        }
    }

    void FaceTarget() {
        var dir = target.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}


