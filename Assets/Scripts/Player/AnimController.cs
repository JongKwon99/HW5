using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnJump(InputValue value)
    {
        animator.SetTrigger("To Jump");
    }

    public void OnFire(InputValue value)
    {
        animator.SetTrigger("To Attack");
    }

    public void OnDamaged(InputValue value)
    {
        animator.SetTrigger("To Damaged");
    }

    public void AlertObservers(string message)
    {
        // Debug.Log($"Animation Event Triggered: {message}");
    }
}
