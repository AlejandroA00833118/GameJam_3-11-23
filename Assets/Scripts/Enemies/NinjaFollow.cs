using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaFollow : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float minimumDistance;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private Transform gunEndPointTransform;

    [SerializeField] private float detectionDistance;
    [SerializeField] private float followDistance;
    [SerializeField] private bool following = false;
    [SerializeField] private GameObject gun;

    private void Start(){
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, target.position) < followDistance && following == true){
            if(Vector2.Distance(transform.position, target.position) > minimumDistance + 0.1f){
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
                enemyAnimator.SetBool("IsMoving", true);
            }
            else if(Vector2.Distance(transform.position, target.position) < minimumDistance - 0.1f){
                transform.position = Vector2.MoveTowards(transform.position, target.position, 0.5f * -speed * Time.fixedDeltaTime);
                enemyAnimator.SetBool("IsMoving", true);
            }
            else{
                enemyAnimator.SetBool("IsMoving", false);
            }
        }
        else if(Vector2.Distance(transform.position, target.position) < detectionDistance && following == false){
            following = true;
            gun.SetActive(true);
        }
        else if(Vector2.Distance(transform.position, target.position) > followDistance && Vector2.Distance(transform.position, target.position) > detectionDistance){
            following = false;
            gun.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag.Equals("Bullet")){
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
