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

    [SerializeField] Transform aimTransform;
    [SerializeField] Transform gunEndPointTransform;
    [SerializeField] GameObject projectile;
    [SerializeField] private float bullet_speed;
    [SerializeField] private float timeBetweenShots;
    private float nextShotTime;

    // Update is called once per frame
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
                Instantiate(projectile, gunEndPointTransform.position, Quaternion.identity);
                Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
                rigidbody.velocity = aimTransform.up * bullet_speed * Time.fixedDeltaTime;
                Debug.Log(rigidbody.velocity);

                nextShotTime = Time.time + timeBetweenShots;
            }
    }
}
