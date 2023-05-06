using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurGenerator : MonoBehaviour
{

    [SerializeField]
    private GameObject UsedBoxPrefab;

    [SerializeField]
    private GameObject MurPregab;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 BoxPosition = new Vector3(transform.position.x, transform.position.y, 0f);
        Vector3 MurPosition = new Vector3(transform.position.x, transform.position.y + 1f, 0f);

        if (collision.collider.tag == "Head")
        {
            GameObject UesdBox = Instantiate(UsedBoxPrefab, BoxPosition, Quaternion.identity);
            GameObject Mur = Instantiate(MurPregab, MurPosition, Quaternion.identity);
            Destroy(this.gameObject);
            Debug.Log("Mushroom apeared!");
        }
    }
}
