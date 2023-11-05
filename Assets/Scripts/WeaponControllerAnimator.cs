using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControllerAnimator : MonoBehaviour
{
    public RuntimeAnimatorController[] animatorControllers;
    
    public void ChangeAnimatorController(int index)
    {
        Animator animator = GetComponent<Animator>();
        RuntimeAnimatorController newAnimatorController = animatorControllers[index];
        
        if (animator != null && newAnimatorController != null)
        {
            animator.runtimeAnimatorController = newAnimatorController;
        }
    }
}
