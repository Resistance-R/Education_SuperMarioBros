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
        this.transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Brick")
        {
            direction *= -1;
        }

        if(collision.collider.tag == "Leg" || collision.collider.tag == "Fire")
        {
            Destroy(this.gameObject);
        }
    }
}
