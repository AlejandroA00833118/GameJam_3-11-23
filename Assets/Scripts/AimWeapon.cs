using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon : MonoBehaviour
{
    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs{
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
    }
    [SerializeField] Transform aimTransform;
    [SerializeField] Transform characterTransform;
    [SerializeField] Camera worldCamera;
    [SerializeField] Animator gunAnimator;
    [SerializeField] Transform gunEndPointTransform;
    
    void Update()
    {
        HandleAim();
        HandleShooting();
    }

    private void HandleAim()
    {
        Vector3 mouseWorldPosition = worldCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;

        Vector3 aimDirection = (mouseWorldPosition - transform.position).normalized;
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
        Vector3 mouseWorldPosition = worldCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;

        if(Input.GetMouseButtonDown(0)){
            gunAnimator.SetTrigger("Shoot");

            OnShoot?.Invoke(this, new OnShootEventArgs {
                gunEndPointPosition = gunEndPointTransform.position,
                shootPosition = mouseWorldPosition,
            });
        }
    }
}
