using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject[] projectiles;
    public PlayerMovement playerMovement;

    void Start() {
        ChangeProjectiles(projectiles[2]);
    }
    
    void ChangeProjectiles(GameObject newProjectile)
    {
        playerMovement = GetComponent<PlayerMovement>();

        if (playerMovement.projectile != null && newProjectile != null)
        {
            playerMovement.projectile = newProjectile;
        }
    }
}
