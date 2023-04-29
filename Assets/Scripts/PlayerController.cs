using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 4.5f;

    [SerializeField]
    private float jumpForce = 9.5f;

    private bool isGrounded = false;
    private Rigidbody2D myRigid;


    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        myRigid.velocity = new Vector2(moveInput * moveSpeed, myRigid.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            myRigid.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Land")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Land")
        {
            isGrounded = false;
        }
    }
}
