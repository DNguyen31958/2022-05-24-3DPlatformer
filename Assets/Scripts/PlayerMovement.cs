using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movementSpeed = 8f;
    private float jumpForce = 8f;
    [SerializeField] private AudioSource jumpSound;

    private Rigidbody rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 2f;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if(Input.GetButtonDown("Jump") && IsGrounded() == true)
        {
            Jump();
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, -0.1f, groundLayer);
    }

    private void Jump()
    {
        jumpSound.Play();
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyHead")
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }
}
