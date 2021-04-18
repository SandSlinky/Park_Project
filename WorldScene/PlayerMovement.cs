using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public bool canMove = true;
    public AudioSource trashSound;

    Vector2 movement;

    private void Start()
    {
        canMove = true;
        trashSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update used for inputs, it's called once per frame
        if (canMove == true)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Trash"))
        {
            trashSound.Play();
        }
    }
}
