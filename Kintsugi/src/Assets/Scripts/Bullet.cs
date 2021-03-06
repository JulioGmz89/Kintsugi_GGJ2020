using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 5;
    public Rigidbody2D rb;
    public float enemyKnockbackspeed = 100f;
    public GameObject impactEffect;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Rigidbody2D rbe = enemy.GetComponent<Rigidbody2D>();
            rbe.AddForce(transform.right * enemyKnockbackspeed);
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
