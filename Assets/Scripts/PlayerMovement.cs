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

    [SerializeField] public GameObject projectile;
    [SerializeField] private Transform gunEndPointTransform;
    [SerializeField] private float timeBetweenShots;
    private float nextShotTime;

    public int idArma; //Pistola: 0, Machinegun: 1, Sniper: 2

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

        if(Input.GetMouseButton(0)){
            Fire();
        }
    }

    private void Fire(){
        if(Time.time > nextShotTime){
            Instantiate(projectile, gunEndPointTransform.position, gunEndPointTransform.rotation);
            Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
            nextShotTime = Time.time + timeBetweenShots;
        }
    }
}
