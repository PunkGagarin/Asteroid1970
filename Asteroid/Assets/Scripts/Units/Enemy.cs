using UnityEngine;

public class Enemy : HealthUnit {

    public int score = 50;
    public EnemyType enemyType;
    ScoreManager scoreManager;
    GameManager gameManager;

    [Header("SpawnChild"), Space(10)]
    public GameObject childSpawn;
    public int count = 2;
    public int childSpeed = 10;
    public float spawnMoveDirRange = 1f;

    private void Start() {
        scoreManager = ScoreManager.GetInstance;
        gameManager = GameManager.GetInstance;
    }

    private void Update() {
        if (gameManager.isGameOver)
            Destroy(gameObject);
    }

    protected override void Die() {
        base.Die();
        scoreManager.AddScore(score);
        Destroy(gameObject);

        if (enemyType.Equals(EnemyType.AsteroidLarge) && childSpawn != null) {
            SpawnSmallAsteroids();
        }
    }

    private void SpawnSmallAsteroids() {
        for (int i = 0; i < count; i++) {
            GameObject childAsteroid = Instantiate(childSpawn, transform.position, Quaternion.identity);
            childAsteroid.GetComponent<Rigidbody2D>()
                .AddForce(new Vector2(Random.Range(-spawnMoveDirRange, spawnMoveDirRange),
                    Random.Range(-spawnMoveDirRange, spawnMoveDirRange)) * childSpeed, ForceMode2D.Impulse
                );
            Destroy(childAsteroid, 15f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Player player = collision.GetComponent<Player>();
        if (player != null) {
            player.TakeDamage(1);
        }
    }
}

public enum EnemyType { UFO, AsteroidLarge, AsteroidMedium, AsteroidSmall }
