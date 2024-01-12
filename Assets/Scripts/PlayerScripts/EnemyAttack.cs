using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject enemySpell;
    public GameObject firePoint;
    public Transform target;

    private bool isAttacking;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (isAttacking)
        {
            Attack();

            Vector3 relativePos = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos,Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.time * 0.1f);
        }
    }

    private void Attack()
    {
        animator.SetBool("isAttacking", true);
        StartCoroutine(CreateSpell());
        StartCoroutine(EndAttack());
        isAttacking = false;
    }

    public void TriggerAttack()
    {
        isAttacking = true;
    }

    private IEnumerator CreateSpell()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(enemySpell, firePoint.transform.position, firePoint.transform.rotation);
    }
    
    private IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(2);
        animator.SetBool("isAttacking", false);
    }
}
