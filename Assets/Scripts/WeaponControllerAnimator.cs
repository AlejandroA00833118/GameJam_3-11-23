using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControllerAnimator : MonoBehaviour
{
    public RuntimeAnimatorController[] animatorControllers;

    void Start() {
        ChangeAnimatorController(animatorControllers[2]);
    }
    
    void ChangeAnimatorController(RuntimeAnimatorController newAnimatorController)
    {
        Animator animator = GetComponent<Animator>();
        
        if (animator != null && newAnimatorController != null)
        {
            animator.runtimeAnimatorController = newAnimatorController;
        }
    }
}
