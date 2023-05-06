using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactItems : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 4.5f;

    [SerializeField]
    private float direction = 1f;

    private Rigidbody2D itemRigid;
    
    void Start()
    {
        itemRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
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

        if (collision.collider.tag == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("Contact!");
        }
    }
}
