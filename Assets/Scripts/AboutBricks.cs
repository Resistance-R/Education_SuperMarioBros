using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutBricks : MonoBehaviour
{
    private Rigidbody2D brickRigid;

    void Start()
    {
        brickRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (collision.collider.tag == "Head" && player.isTall == true)
        {
                Destroy(this.gameObject);
                Debug.Log("Brick is Broken.");
        }
    }
}
