using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Transform aimTransform;

    public float fuerza = 10.0f;
    Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direccion = aimTransform.right;
        rb.AddForce(direccion * fuerza, ForceMode2D.Impulse);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
