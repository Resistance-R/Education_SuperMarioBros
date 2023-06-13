using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    private Rigidbody2D FireRigid;

    void Start()
    {
        FireRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FireForward();
    }

    private void FireForward()
    {
        Vector2 force = new Vector2(0.3f, 0f);
        FireRigid.AddForce(force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider)
        {
            Destroy(this.gameObject);
        }
    }
}
