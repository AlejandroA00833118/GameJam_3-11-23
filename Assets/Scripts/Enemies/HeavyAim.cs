using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAim : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private Transform aimTransform;
    [SerializeField] private Transform characterTransform;
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform gunEndPointTransform;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private HeavyFollow heavy;
    private float nextShotTime = 0.1f;
    
    private void Start(){
        playerTransform = GameObject.FindWithTag("Player").transform;
    }
    
    void Update()
    {
        gunAnimator.SetBool("IsMoving", heavy.moving);
        HandleAim();
        HandleShooting();
    }

    private void HandleAim()
    {
        Vector3 playerPosition = playerTransform.position;
        playerPosition.z = 0f;

        Vector3 aimDirection = (playerPosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 aimLocalScale = Vector3.one;
        Vector3 charLocalScale = Vector3.one;
        if(angle > 90 || angle < -90){
            aimLocalScale.y = -1f;
            charLocalScale.x = -1f;
        }
        else{
            aimLocalScale.y = 1f;
            charLocalScale.x = 1f;
        }
        aimTransform.localScale = aimLocalScale;
        characterTransform.localScale = charLocalScale;
    }

    private void HandleShooting()
    {
        if(Time.time > nextShotTime && heavy.moving == false){
            gunAnimator.SetTrigger("Shoot");
            nextShotTime = Time.time + timeBetweenShots;
        }
    }
}
