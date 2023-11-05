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

    public ProjectileController projectileController;
    public WeaponControllerAnimator weaponControllerAnimator;
    public WeaponSprite weaponSprite;

    public int idWeapon = 0; //Pistola: 0, Machinegun: 1, Sniper: 2
    public int[] weaponAmmunition = {10000, 100, 10};
    private int ammunition = 10000;
    private float[] weaponAttackSpeed = {1f, 0.25f, 3f};

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

    public void UpdateWeapon(int index) {
        idWeapon = index;
        ammunition = weaponAmmunition[index];
        timeBetweenShots = weaponAttackSpeed[index];
    }

    private void Fire(){
        if (Time.time > nextShotTime) {
            if (ammunition > 0) {
                Instantiate(projectile, gunEndPointTransform.position, gunEndPointTransform.rotation);
                ammunition -= 1;
                Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
                nextShotTime = Time.time + timeBetweenShots;
            }
            else {
                weaponSprite.ChangeSprite(0);
                weaponControllerAnimator.ChangeAnimatorController(0);
                projectileController.ChangeProjectile(0);
                UpdateWeapon(0);
            }
        }
    }
}
