using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 15f;
    public float turnSpeed = 10f;
    public Rigidbody2D rb;

    [Header("ScreenWrap points"), Space(10)]
    public float screenTop = 16;
    public float screenBottom = -16;
    public float screenRight = 21;
    public float screenLeft = -21;

    GameManager gameManager;

    float moveDirection;
    float turnDirection;


    private void Start() {
        gameManager = GameManager.GetInstance;
    }
    void Update() {
        if (gameManager.isGameOver)
            return;

        moveDirection = Input.GetAxis("Vertical");
        turnDirection = -Input.GetAxis("Horizontal");

        ScreenWrap();

    }

    private void FixedUpdate() {
        if (gameManager.isGameOver)
            return;

        rb.AddRelativeForce(Vector2.up * moveDirection * moveSpeed);
        //rb.AddTorque(turnDirection * turnSpeed); // -> We can simulate more "space" rotation
        transform.Rotate(Vector3.forward * turnDirection * turnSpeed * Time.fixedDeltaTime); // or we can use direct rotation
    }

    /**
     * We wrap a screen, so if a player move out 
     * he will be teleported in an opposite direction
     */
    private void ScreenWrap() {
        Vector2 newPosition = transform.position;
        if (transform.position.y > screenTop) {
            newPosition.y = screenBottom;
        } else if (transform.position.y < screenBottom) {
            newPosition.y = screenTop;
        }

        if (transform.position.x > screenRight) {
            newPosition.x = screenLeft;
        } else if (transform.position.x < screenLeft) {
            newPosition.x = screenRight;
        }
        transform.position = newPosition;
    }
}
