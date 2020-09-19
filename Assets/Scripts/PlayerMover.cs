using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    public float speed;
    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;

    private void Awake()
    {
        rb2d = transform.GetComponent<Rigidbody2D>();
        bc2d = transform.GetComponent<BoxCollider2D>();
    }

    public CameraMover cameraMover;
    public Transform playerTransform;

    private void Start()
    {
        cameraMover.Setup(() => playerTransform.position);
    }
    private void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 30f;
            rb2d.velocity = Vector2.up * jumpVelocity;
        }

        HandleMovement();
    }

    private bool IsGrounded()
    {
        RaycastHit2D ray2d = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);
        return ray2d.collider != null;
    }

    private void HandleMovement()
    {
        float moveSpeed = 20f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        } else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb2d.velocity = new Vector2(+moveSpeed, rb2d.velocity.y);
            } else
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }
        }
    }
}
