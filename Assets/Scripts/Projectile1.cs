using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile1 : MonoBehaviour
{
    public float fuerza = 10.0f;

    void Start() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direccion = transform.right;
        rb.AddForce(direccion * fuerza, ForceMode2D.Impulse);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
