using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float minimumDistance;
    [SerializeField] private Animator enemyAnimator;

    [SerializeField] private Transform gunEndPointTransform;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float timeBetweenShots;
    private float nextShotTime;

    private void Start(){
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if(Time.time > nextShotTime){
            Instantiate(projectile, gunEndPointTransform.position, gunEndPointTransform.rotation);
            nextShotTime = Time.time + timeBetweenShots;
        }
        
        if(Vector2.Distance(transform.position, target.position) > minimumDistance + 0.25f){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
            enemyAnimator.SetBool("IsMoving", true);
        }
        else if(Vector2.Distance(transform.position, target.position) < minimumDistance - 0.25f){
            transform.position = Vector2.MoveTowards(transform.position, target.position, 0.5f * -speed * Time.fixedDeltaTime);
            enemyAnimator.SetBool("IsMoving", true);
        }
        else{
            enemyAnimator.SetBool("IsMoving", false);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag.Equals("Bullet")){
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
