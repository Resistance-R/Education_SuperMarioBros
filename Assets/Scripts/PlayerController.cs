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
    private GameObject FirePrefab;

    
    public int lifeScore = 1;
    public bool isTall = false;
    public bool isFlo = false;
    public bool isDead = false;

    private bool isGrounded = false;
    private Rigidbody2D myRigid;

    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Dead();
        Attack();
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

    private void Attack()
    {
        if(isFlo == true)
        {
            Vector3 FirePosition = new Vector3(transform.position.x + 22.7f, transform.position.y, 0f);

            if (Input.GetMouseButtonDown(0))
            {
                GameObject Fire = Instantiate(FirePrefab, FirePosition, Quaternion.identity);
            }

        }
    }

    private IEnumerator TimeWaiter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        moveSpeed = 4.5f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Land" || collision.collider.tag == "UsedBox" || collision.collider.tag == "Unbroken")
        {
            isGrounded = true;
            moveSpeed = 4.5f;
        }

        if (collision.collider.tag == "Brick" || collision.collider.tag == "Box")
        {
            isGrounded = true;
            moveSpeed = 0;
        }

        if (collision.collider.tag == "Mur")
        {
            isTall = true;
            lifeScore += 1;
        }

        if (collision.collider.tag == "Flo")
        {
            isFlo = true;
        }

        if (collision.collider.tag == "Enemy")
        {
            GoombaController PlyerHit = collision.gameObject.GetComponent<GoombaController>();
        }
        
        if(collision.collider.tag == "Brick" && isTall == true)
        {
            AboutBricks bricks = collision.gameObject.GetComponent<AboutBricks>();
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

        if (collision.collider.tag == "Brick" || collision.collider.tag == "Box" || collision.collider.tag == "Unbroken" || collision.collider.tag == "UsedBox")
        {
            moveSpeed = 4.5f;
            isGrounded = false;
        }
    }
}