using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationTrigger : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log("Animator component found: " + (animator != null));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");
            animator.SetBool("PlayerNear", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger");
            animator.SetBool("PlayerNear", false);
        }
    }
}
