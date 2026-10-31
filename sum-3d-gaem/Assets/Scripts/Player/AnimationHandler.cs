using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] private PlayerMovement moveScript;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animation anim;

    private bool jumpAnimating;

    void Start()
    {
        jumpAnimating = false;
    }
    void Update()
    {
        if (moveScript.grounded == true)
        {
            jumpAnimating = false;
            if (rb.velocity.x != 0.0f || rb.velocity.y != 0.0f)
            {
                anim.Play("Walk");
            }else if(rb.velocity.x <= 0.05f || rb.velocity.y <= 0.05f)
            {
                anim.Play("Idle");
            }
        }else if(moveScript.grounded == false && jumpAnimating == false)
        {
            jumpAnimating = true;
            anim.Play("Jump");
        }
    }
}
