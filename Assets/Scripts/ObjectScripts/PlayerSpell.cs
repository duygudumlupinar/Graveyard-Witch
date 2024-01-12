using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpell : MonoBehaviour
{
    public string targetTag;
    public float speed = 5;
    public int damage = 50;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        StartCoroutine(DestroySpell());
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag(targetTag))
        {
            if(targetTag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyAttack>().TriggerAttack();
                collision.gameObject.GetComponent<Health>().HandleDamage(damage);
            }
            else if (targetTag == "Player")
            {
                collision.gameObject.GetComponent<PlayerHealth>().HandleDamage(damage);
            }
            
            Destroy(gameObject);
        }
        
    }

    private IEnumerator DestroySpell()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
