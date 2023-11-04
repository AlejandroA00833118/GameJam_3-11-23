using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform aimTransform;
    [SerializeField] Transform gunEndPointTransform;
    [SerializeField] GameObject projectile;
    [SerializeField] private float bullet_speed;
    [SerializeField] private float timeBetweenShots;
    private float nextShotTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            Fire();
        }
    }

    private void Fire(){
        if(Time.time > nextShotTime){
                Instantiate(projectile, gunEndPointTransform.position, Quaternion.identity);
                Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
                rigidbody.velocity = aimTransform.up * bullet_speed * Time.fixedDeltaTime;
                Debug.Log(aimTransform.up);

                nextShotTime = Time.time + timeBetweenShots;
            }
    }
}
