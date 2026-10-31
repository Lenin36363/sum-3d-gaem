using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase2 : MonoBehaviour
{
    private bool canAttack;
    [SerializeField] private float attackDelay;
    public float detectionRange = 10f;

    void Start()
    {
        canAttack = true;
    }

    void Update()
    {
        // Debug.Log(canAttack);
        if (canAttack != true)
        {
            StartCoroutine(AttackTimer());
            return;
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > detectionRange) return;

        Vector3 direction = (player.transform.position - transform.position + new Vector3(0f, 1f, 0f)).normalized;
        RaycastHit hit;
        Debug.DrawRay(transform.position, direction * detectionRange, Color.red);
        if (Physics.Raycast(transform.position, direction, out hit, detectionRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Vector3 pos = player.transform.position;
                // print("Player is found in the coordinates " + pos.x + ", " + pos.y + ", " + pos.z);
                if (canAttack == true)
                {
                    StartCoroutine(Teleport(pos));
                    canAttack = false;
                }
            }
        }
    }


    IEnumerator Teleport(Vector3 pos)
    {
        Debug.Log("Imma teleport soon");
        yield return new WaitForSeconds(attackDelay);
        transform.position = pos;
    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(3f);
        canAttack = true;
    }

}