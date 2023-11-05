using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public int weaponId;

    public PlayerMovement playerMovement;
    public ProjectileController projectileController;
    public WeaponControllerAnimator weaponControllerAnimator;
    public WeaponSprite weaponSprite;

    void Start() {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        projectileController = GameObject.FindGameObjectWithTag("Player").GetComponent<ProjectileController>();
        weaponControllerAnimator = GameObject.FindGameObjectWithTag("PlayerAim").GetComponent<WeaponControllerAnimator>();
        weaponSprite = GameObject.FindGameObjectWithTag("PlayerGun").GetComponent<WeaponSprite>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            weaponSprite.ChangeSprite(weaponId);
            weaponControllerAnimator.ChangeAnimatorController(weaponId);
            projectileController.ChangeProjectile(weaponId);
            playerMovement.UpdateWeapon(weaponId);

            Destroy(gameObject);
        }
    }
}