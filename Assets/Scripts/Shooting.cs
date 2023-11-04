using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Shooting : MonoBehaviour
{
    [SerializeField] private AimWeapon playerAimWeapon;
    [SerializeField] private float shakeIntensity;
    [SerializeField] private float shakeTimer;

    private void Start() {
        playerAimWeapon.OnShoot += PlayerAimWeapon_OnShoot;
    }

    private void PlayerAimWeapon_OnShoot(object sender, AimWeapon.OnShootEventArgs e) {
        UtilsClass.ShakeCamera(shakeIntensity, shakeTimer);
    }
}
