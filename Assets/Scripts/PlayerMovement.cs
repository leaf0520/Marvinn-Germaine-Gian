using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [Self-notes and explanations]
// Basically, I'm moving the player using physics, but I swear I don't know jack about physics in general

// Rigidbody has some values changed for it to feel better
// Collision detection = continuous, Interpolation enabled, and Linear Drag and Gravity Scale are too.

public class PlayerMovement : MonoBehaviour
{
    // Was about to serialize a few fields but realized that it didn't matter
    private Rigidbody2D rb2d;
    private float moveSpeed;
    private float jumpHeight;
    // Checks if player is midair/airborne
    private bool inAir;
    // Checks if player is moving horizontally/vertically
    private float moveHztl;
    private float moveVrtl;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 3f;
        jumpHeight = 16f;
        inAir = false;
    }
    void Update()
    {
        // gets the input for, you guessed it, movement keys
        moveHztl = Input.GetAxisRaw("Horizontal");
        moveVrtl = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        // Pipe symbols, ||, means "or"
        if (moveHztl > 0.1f || moveHztl < -0.1f)
        {
            // AddForce has both Time.deltaTime methods integrated
            // ForceMode2D, preferably Impulse will add a continuous force
            rb2d.AddForce(new Vector2(moveHztl * moveSpeed, 0f), ForceMode2D.Impulse);
        }
        // Exclamation marks, !, make it ask if the player is jumping. Two AND (&&) symbols mean that both of these have to be true.
        if (!inAir && moveVrtl > 0.1f)
        {
            // Same thing, but swapped the vertical/Y values and changed moveSpeed to jumpHeight
            rb2d.AddForce(new Vector2(0f, moveVrtl * jumpHeight), ForceMode2D.Impulse);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Two equals (==) means you *check* if the value is equal
        // When the player collides with this here tagged object, then it's considered "grounded".
        // Basically, it's a ground checker. The reason why I added a box collider as a trigger.
        if (collision.gameObject.tag == "Platform")
        {
            inAir = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            inAir = true;
        }
    }
}
