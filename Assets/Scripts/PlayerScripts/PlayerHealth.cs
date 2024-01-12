using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int healthPoints;
    private Vector3 startingPosition;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        healthPoints = 100;
        startingPosition = transform.position;
    }

    public void HandleDamage(int damage)
    {
        healthPoints -= damage;

        if (healthPoints <= 0)
        {
            healthPoints = 100;
            rb.transform.position = startingPosition;
        }
    }
}
