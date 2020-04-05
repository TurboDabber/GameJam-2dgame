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
    Vector2 prev_move;
    // Update is called once per frame
    void Update()
    {
        if(movement.x != 0 || movement.y != 0)
        {
            prev_move = movement;
            animator.SetFloat("Atc_hor", prev_move.x);
            animator.SetFloat("Atc_vert", prev_move.y);
        }
            
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(!Input.anyKey)
            timer += Time.deltaTime;
        else
        {
            animator.SetBool("Dance", false);
            timer = 0;
            if (Input.GetKeyDown(KeyCode.Space))
                animator.SetTrigger("Basic_attack");
            if (Input.GetKeyDown(KeyCode.LeftControl))
                animator.SetTrigger("Piruet");
        }
           
        if (timer > time_to_dance)
            animator.SetBool("Dance", true);

        //animator.SetBool("Basic_attack", false);
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * movement_speed * Time.fixedDeltaTime);
    }
}
