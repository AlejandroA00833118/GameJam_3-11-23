using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float force = 10.0f;
    public int attack = 40;
    Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direccion = transform.right;
        rb.AddForce(direccion * force, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ambient")) {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.CompareTag("Wall") || other.CompareTag("Bullet")) {
            Destroy(gameObject);
        }

        if (other.CompareTag("Player")) {
            other.GetComponent<Health>().ReceiveDamage(attack);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
