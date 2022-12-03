using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I redid the script. I had to reverse commit to check for changes but there isn't really any
// [Self-notes and explanations]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float moveSpeed;
    private float jumpHeight;
        // inAir checks if player is airborne
    private bool inAir;
        // moveHztl/Vrtl checks if player is moving horizontally/vertically
    private float moveHztl;
    private float moveVrtl;

    void Start()
    {
        // gets rb2d as our GameObject
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 3f;
        jumpHeight = 16f;
        inAir = false;
    }

    void Update()
    {
        // self-explanatory
        moveHztl = Input.GetAxisRaw("Horizontal");
        moveVrtl = Input.GetAxisRaw("Vertical");
    }
    
    void FixedUpdate()
    {
        // these || symbols mean "or"
        if (moveHztl > 0.1f || moveHztl < -0.1f)
        {
            // AddForce has Time.deltaTime methods integrated by default
            // ForceMode2D.Impulse will add a continuous force
            rb2d.AddForce(new Vector2(moveHztl * moveSpeed, 0f), ForceMode2D.Impulse);
        }
        // Exclamation marks (!) ask if the player is jumping. Two AND operands (&&) mean that these both have to be true.
        if (!inAir && moveVrtl > 0.1f)
        {
            // same as the other, but swapped values, and moveSpeed is changed to jumpHeight
            rb2d.AddForce(new Vector2(0f, moveVrtl * jumpHeight), ForceMode2D.Impulse);
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Two equal symbols (==) means you *check* if it is equal.
        // This and OnTriggerExit are part of a ground check, since I added a box collider as a trigger.
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
