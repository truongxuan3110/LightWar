using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    private Rigidbody2D rb;
    public float speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        Destroy(gameObject,2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
