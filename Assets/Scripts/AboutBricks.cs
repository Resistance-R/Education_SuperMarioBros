using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutBricks : MonoBehaviour
{
    [SerializeField]
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
        if (collision.collider.tag == "Head")
        {
            PlayerController Player = collision.collider.GetComponent<PlayerController>();
            if (Player != null && Player.IsBreaker())
            {
                Destroy(this.gameObject);
            }
        }
    }
}
