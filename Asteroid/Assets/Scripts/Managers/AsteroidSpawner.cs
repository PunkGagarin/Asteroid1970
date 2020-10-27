using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    [System.Serializable]
    public struct SpawnItem {
        public GameObject spawnPrefab;
        public float spawnSpeed;
        public float speed;
    }
    public SpawnItem[] spawnArray;


    public float leftSide = 18.5f;
    public float topSide = 14f;
    public float wallRadius = 1.5f;

    float innerRadius;
    GameManager gameManager;


    private void Start() {
        gameManager = GameManager.GetInstance;
        innerRadius = (Vector2.left * leftSide + Vector2.up * topSide).magnitude;

        foreach (SpawnItem item in spawnArray) {
            StartCoroutine(SpawnAsteroid(item));
        }
    }

    /**
     * Spawn an asteroid depends on spawnArray list
     * In a torus around the screen
     */
    IEnumerator SpawnAsteroid(SpawnItem item) {
        while (!gameManager.isGameOver) {
            yield return new WaitForSeconds(item.spawnSpeed);

            GameObject gameOBject = Instantiate(item.spawnPrefab, GetRandomPositionInTorus(), Quaternion.identity);

            Vector2 movePoint = Vector2.right;
            movePoint.x += Random.Range(-10f, 10f);
            Vector2 direction = new Vector2(movePoint.x - gameOBject.transform.position.x, movePoint.y - gameOBject.transform.position.y);

            Rigidbody2D enemyRb = gameOBject.GetComponent<Rigidbody2D>();
            enemyRb.AddForce(direction * item.speed, ForceMode2D.Impulse);

            Destroy(gameOBject, 10f);
        }
    }

    /**
     * Get a Vector2 position in a torus of a certain radius
     */
    Vector2 GetRandomPositionInTorus() {
        float rndAngle = Random.value * 6.28f; // use radians, saves converting degrees to radians

        // determine position
        float cX = Mathf.Sin(rndAngle);
        float cY = Mathf.Cos(rndAngle);

        Vector2 ringPos = new Vector2(cX, cY);
        ringPos *= innerRadius;

        // At any point around the center of the ring
        // a circle of radius the same as the wallRadius will fit exactly into the torus.
        // Simply get a random point in a sphere of radius wallRadius,
        // then add that to the random center point
        Vector2 sPos = Random.insideUnitCircle * wallRadius;

        return (ringPos + sPos);
    }
}
