using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 4.5f;

    [SerializeField]
    private float jumpForce = 9.5f;
    
    [SerializeField]
    private int lifeScore = 1;

    private bool isGrounded = false;
    private bool isTall = false;
    private bool isDead = false;
    private Rigidbody2D myRigid;


    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        WhenTall();
        Dead();
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

    private void WhenTall()
    {
        if (isTall == true)
        {
            lifeScore += 1;
            isTall = false;
        }
    }

    private void Dead()
    {
        GameObject HeadFinder = GameObject.Find("Head");
        GameObject LegFinder = GameObject.Find("Leg");

        if (lifeScore == 0)
        {
            isDead = true;
        }

        if (isDead == true)
        {
            Debug.Log("Dead!");
            Destroy(HeadFinder);
            Destroy(LegFinder);
            Time.timeScale = 0f;
        }
    }

    private IEnumerator TimeWaiter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        moveSpeed = 4.5f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Land")
        {
            isGrounded = true;
        }

        if (collision.collider.tag == "Brick" || collision.collider.tag == "Box")
        {
            isGrounded = true;
            moveSpeed = 0;
        }

        if (collision.collider.tag == "Mur")
        {
            isTall = true;
        }

        if (collision.collider.tag == "Enemy")
        {
            lifeScore -= lifeScore;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Brick" || collision.collider.tag == "Box")
        {
            StartCoroutine(TimeWaiter(0.5f));
        }

        if (collision.collider.tag == "DeadZone")
        {
            isDead = true;
        }    
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Land")
        {
            isGrounded = false;
        }

        if (collision.collider.tag == "Brick" || collision.collider.tag == "Box")
        {
            moveSpeed = 4.5f;
            isGrounded = false;
        }
    }
}
