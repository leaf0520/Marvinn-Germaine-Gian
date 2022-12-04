using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I redid the script. I had to reverse commit to check for changes but there isn't really any
// [Self-notes and explanations]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
        // inAir checks if player is airborne
    private bool inAir;
        // moveHztl/Vrtl checks if player is moving horizontally/vertically
    private float moveHztl;
    private float moveVrtl;

    void Start()
    {
        // gets rb2d as our GameObject
        rb2d = gameObject.GetComponent<Rigidbody2D>();
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
        // AddForce has Time.deltaTime methods integrated by default
        // ForceMode2D.Impulse will add an instant force
        rb2d.AddForce(new Vector2(moveHztl * moveSpeed, 0f), ForceMode2D.Impulse);
        
        // Exclamation marks (!) ask if the player is not in air (or grounded). Two AND operands (&&) mean that these both have to be true.
        if (!inAir)
        {
            // same as the other, but swapped values, and moveSpeed is changed to jumpHeight
            rb2d.AddForce(new Vector2(0f, moveVrtl * jumpHeight), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Two equal symbols (==) means you *check* if it is equal.
        // This and OnTriggerExit are part of a ground check, since I added a box collider as a trigger.
        if (collision.collider.CompareTag("Platform"))
        {
            inAir = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            inAir = true;
        }
    }
}
