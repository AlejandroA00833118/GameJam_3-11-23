using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float fuerza = 10.0f;
    public int ataque = 40;
    Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direccion = transform.right;
        rb.AddForce(direccion * fuerza, ForceMode2D.Impulse);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
