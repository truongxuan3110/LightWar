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
        Destroy(gameObject,1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth _enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            _enemyHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
