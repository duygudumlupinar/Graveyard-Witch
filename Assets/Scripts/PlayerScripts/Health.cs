using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int healthPoints;

    void Start()
    {
        healthPoints = 100;
    }

    public void HandleDamage(int damage)
    {
        healthPoints -= damage;

        if (healthPoints <= 0)
        {
            Destroy(gameObject);
            //play death audio
        }
    }
}
