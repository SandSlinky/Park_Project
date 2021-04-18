using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowingMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public bool canMove = true;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            movement.y = Input.GetAxisRaw("Vertical");
            movement.x = 1;

            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    private void FixedUpdate()
    {
        // FixedUpdate used for movement, it's called a set number of times per second, making it more reliable than update.
        {
            if (canMove == true)
                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
