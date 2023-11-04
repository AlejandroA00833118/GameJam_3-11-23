using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyFollow : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float minimumDistance;
    [SerializeField] private Animator enemyAnimator;

    [SerializeField] private GameObject projectile;
    [SerializeField] private float timeBetweenShots;
    private float nextShotTime;
    public bool moving;

    private void Start(){
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {   
        if(Vector2.Distance(transform.position, target.position) > minimumDistance + 0.4f){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
            enemyAnimator.SetBool("IsMoving", true);
            moving = true;
        }
        else if(Vector2.Distance(transform.position, target.position) < minimumDistance - 0.4f){
            transform.position = Vector2.MoveTowards(transform.position, target.position, 0.5f * -speed * Time.fixedDeltaTime);
            enemyAnimator.SetBool("IsMoving", true);
            moving = true;
        }
        else{
            enemyAnimator.SetBool("IsMoving", false);
            moving = false;
        }

        if(Time.time > nextShotTime && moving == false){
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextShotTime = Time.time + timeBetweenShots;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag.Equals("Bullet")){
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
