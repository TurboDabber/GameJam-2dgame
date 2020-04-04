using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour
{
    public float movement_speed;
    public Rigidbody2D rigidbody;
    public Animator animator;
    public float time_to_dance;
    float timer = 0;
    Vector2 movement;
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(movement.x == 0 && movement.y == 0)
            timer += Time.deltaTime;
        else
        {
            animator.SetBool("Dance", false);
            timer = 0;
        }
           
        if (timer > time_to_dance)
            animator.SetBool("Dance", true);
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * movement_speed * Time.fixedDeltaTime);
        if(movement.x < 0)
        {

        }
    }
}
