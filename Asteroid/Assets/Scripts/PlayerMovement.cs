using System.Collections;
using System.Collections.Generic;
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

    float moveDirection;
    float turnDirection;

    //todo: Add a mouse rotation controller

    // Update is called once per frame
    void Update() {
        moveDirection = Input.GetAxis("Vertical");
        turnDirection = -Input.GetAxis("Horizontal");

        ScreenWrap();
        
    }

    private void FixedUpdate() {
        rb.AddRelativeForce(Vector2.up * moveDirection * moveSpeed);
        rb.AddTorque(turnDirection * turnSpeed);
    }

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
