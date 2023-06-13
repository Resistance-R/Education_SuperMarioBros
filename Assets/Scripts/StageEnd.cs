using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEnd : MonoBehaviour
{
    private Rigidbody2D StageEndRigid;

    void Start()
    {
        StageEndRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player" || collision.collider.tag == "Head")
        {
            Debug.Log("Stage End.");
            Time.timeScale = 0f;
        }
    }
}