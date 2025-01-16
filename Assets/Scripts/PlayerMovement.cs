using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rb;

    Vector2 movement;

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("x", movement.x);
        animator.SetFloat("y", movement.y);

        /*animator.SetFloat("Horizontal",movement.x);
		animator.SetFloat("Vertical",movement.y);
		animator.SetFloat("Speed",movement.sqrMagnitude);*/
    }

    // Melhor para trabalhar com física	
    void FixedUpdate()
    {
        // Movement
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
