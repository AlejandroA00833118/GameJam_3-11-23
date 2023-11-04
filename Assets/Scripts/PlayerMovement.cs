using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 forceToApply;
    [SerializeField] private float forceDamping;
    [SerializeField] Animator characterAnimator;

    public void FixedUpdate()
    {
        Vector2 PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector2 moveForce = PlayerInput * moveSpeed;
        moveForce += forceToApply;
        forceToApply /= forceDamping;

        if(Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f){
            forceToApply = Vector2.zero;
        }
        rb.velocity = moveForce * Time.fixedDeltaTime;

        if(Mathf.Abs(moveForce.x) > 0 || Mathf.Abs(moveForce.y) > 0){
            characterAnimator.SetBool("IsMoving", true);
        }
        else{
            characterAnimator.SetBool("IsMoving", false);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag.Equals("Bullet")){
            Destroy(col.gameObject);
        }
    }
}
