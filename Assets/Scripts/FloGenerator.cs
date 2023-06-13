using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject UsedBoxPrefab;

    [SerializeField]
    private GameObject FloPrefab;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 BoxPosition = new Vector3(transform.position.x, transform.position.y, 0f);
        Vector3 FloPosition = new Vector3(transform.position.x, transform.position.y + 1f, 0f);

        if (collision.collider.tag == "Head")
        {
            GameObject UesdBox = Instantiate(UsedBoxPrefab, BoxPosition, Quaternion.identity);  
            GameObject Flo = Instantiate(FloPrefab, FloPosition, Quaternion.identity);
            Destroy(this.gameObject);
            Debug.Log("Flower apeared!");
        }
    }
}
