using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    private Animator animator;
    public GameObject playerSpell;
    public GameObject firePoint;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    private void Attack()
    {
        animator.SetBool("isAttacking", true);
        Instantiate(playerSpell, firePoint.transform.position, firePoint.transform.rotation);
        StartCoroutine(EndAttack());
    }

    private IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(2);
        animator.SetBool("isAttacking", false);
    }
}
