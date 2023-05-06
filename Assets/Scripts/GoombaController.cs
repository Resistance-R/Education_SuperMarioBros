using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;

    [SerializeField]
    private float direction = 1f;

    private Rigidbody2D goombaRigid;

    void Start()
    {
        goombaRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GoombaMove();
    }
    
    private void GoombaMove()
    {
        Vector3 movePosition = new Vector3(transform.position.x + (direction * moveSpeed * Time.deltaTime), transform.position.y, 0f);
        transform.position = movePosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Unbroken")
        {
            direction *= -1;
        }

        if(collision.collider.tag == "Leg" || collision.collider.tag == "Fire")
        {
            Destroy(this.gameObject);
        }
    }
}
