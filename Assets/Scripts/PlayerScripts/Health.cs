using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            Object winLose = FindAnyObjectByType(typeof(WinLose));
            winLose.GetComponent<WinLose>().EnemyDown();

            Destroy(gameObject);
            //play death audio
        }
    }
}
