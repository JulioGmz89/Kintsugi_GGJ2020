using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CurrencyPickUp : MonoBehaviour
{
    public Stats stats;
    public int goldValue = 10;
    public Transform target;
    public float speed = 0f;
    public float speedIncrease = 2f;
    public float rotateSpeed = 200f;
    private float rh;
    private Rigidbody2D rb;

    void OnTriggerEnter2D(Collider2D other)
    {
        stats.currentGold += goldValue;
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rh += Time.deltaTime * speedIncrease;
        if (rh >= 1)
        {
            int floor = Mathf.FloorToInt(rh);
            speed += floor; // normally 1 unless huge framedrop or Huge regenHealth value
            rh -= floor;
        }

        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount  = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    }
}
