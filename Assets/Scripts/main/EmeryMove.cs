using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmeryMove : MonoBehaviour
{
    
    public float speed;
    public Animator animator;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    
    [SerializeField] private int StartingHP = 5;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Global.Health = StartingHP;
        Global.EmeryInputBlocked = false;
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        animator.SetFloat("Horizontal", moveVelocity.x);
        animator.SetFloat("Vertical", moveVelocity.y);
        animator.SetFloat("Speed", moveVelocity.sqrMagnitude);

    }

    void FixedUpdate()
    {
        if (!Global.EmeryInputBlocked)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }
    }
}
