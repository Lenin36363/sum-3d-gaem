using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] Animator animator;

    private bool enemyIsInHitBox;
    private Collider enemyCollider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetTrigger("isAttacking");
            if (enemyIsInHitBox && enemyCollider != null)
            {
                Destroy(enemyCollider.gameObject);
            }

        }
    }    

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Enemy"))
        {
            enemyIsInHitBox = true;
            enemyCollider = otherCollider;
        }
    }

    void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Enemy"))
        {
            enemyIsInHitBox = false;
        }
    }
}
