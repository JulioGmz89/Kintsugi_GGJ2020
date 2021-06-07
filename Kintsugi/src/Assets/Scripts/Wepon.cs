using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float knockbackSpeed = 100f;

    public Animator animator;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }
    void Shoot()
    {

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        rb.AddForce(-firePoint.right * knockbackSpeed);
    }
}
