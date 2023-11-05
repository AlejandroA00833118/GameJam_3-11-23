using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject[] projectiles;
    public PlayerMovement playerMovement;

    public void ChangeProjectile(int index)
    {
        playerMovement = GetComponent<PlayerMovement>();
        GameObject newProjectile = projectiles[index];

        if (playerMovement.projectile != null && newProjectile != null)
        {
            playerMovement.projectile = newProjectile;
        }
    }
}
