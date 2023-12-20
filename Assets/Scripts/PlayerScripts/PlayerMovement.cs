using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    private float horizontalMovement;
    private float verticalMovement;
    private Vector3 direction;

    public float speed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        if (verticalMovement != 0f)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, verticalMovement * speed);
        }

        if (horizontalMovement != 0f)
        {
            rb.velocity = new Vector3(horizontalMovement * speed, rb.velocity.y, 0f);
        }

        if(!(verticalMovement == 0f && horizontalMovement == 0f))
        {
            var tanangle = Mathf.Atan2(horizontalMovement, verticalMovement) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, tanangle, 0);
        }
        

        //if (Mathf.Abs(rb.velocity.z) > 0f || Mathf.Abs(rb.velocity.x) > 0f)
        //{
        //    animator.SetBool("isWalking", true);
        //}
        //else
        //{
        //    animator.SetBool("isWalking", false);
        //}
    }
}
