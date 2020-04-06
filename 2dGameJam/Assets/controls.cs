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
    public float piruet_cooldown;
    float piruet_time;
    float piruet_timer;
    public Health piruet;
    public float powerful_cooldown;
    float powerful_time;
    float powerful_timer;
    public Health powerful;
    public float heal_cooldown;
    float heal_time;
    float heal_timer;
    public Health heal;
    float basic_attack_time;
    float basic_attack_timer = 0;
    bool active_animation = false;
    public Attacks attacks;
    Vector2 movement;
     public Vector2 prev_move;

    private void Start()
    {
        piruet.setMax(piruet_cooldown);
        powerful.setMax(powerful_cooldown);
        heal.setMax(heal_cooldown);
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Basic_attack_front":
                    basic_attack_time = clip.length;
                    break;
                case "Hero_piruet":
                    piruet_time = clip.length;
                    break;
                case "Powerful_attack":
                    powerful_time = clip.length;
                    break;
                case "Sword_up":
                    heal_time = clip.length;
                    break;
            }
        }
        piruet_timer = piruet_cooldown;
        powerful_timer = powerful_cooldown;
        heal_timer = heal_cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        piruet.set_health(piruet_timer);
        powerful.set_health(powerful_timer);
        heal.set_health(heal_timer);

        if ((movement.x != 0 || movement.y != 0))
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
            if (Input.GetKeyDown(KeyCode.Space) && basic_attack_timer > basic_attack_time)
            {
                animator.SetTrigger("Basic_attack");
                active_animation = true;
                attacks.Basic_attack();
                basic_attack_timer = 0;
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl) && piruet_timer >= piruet_cooldown)
            {
                animator.SetTrigger("Piruet");
                active_animation = true;
                attacks.Piruet();
                piruet_timer = 0;
            }     
            else if (Input.GetKeyDown(KeyCode.LeftShift) && powerful_timer >= powerful_cooldown)
            {
                animator.SetTrigger("Powerful");
                active_animation = true;
                attacks.Powerful_attack();
                powerful_timer = 0;
            }    
            else if (Input.GetKeyDown(KeyCode.LeftAlt) && heal_timer >= heal_cooldown)
            {
                animator.SetTrigger("Sword_up");
                active_animation = true;
                attacks.Heal();
                heal_timer = 0;
            }    
        }
           
        if (timer > time_to_dance)
            animator.SetBool("Dance", true);

        if (basic_attack_timer < basic_attack_time)
            basic_attack_timer += Time.deltaTime;
        if (piruet_timer < piruet_cooldown)
            piruet_timer += Time.deltaTime;
        if (powerful_timer < powerful_cooldown)
            powerful_timer += Time.deltaTime;
        if (heal_timer < heal_cooldown)
            heal_timer += Time.deltaTime;

        if (basic_attack_timer > basic_attack_time && piruet_timer > piruet_time && powerful_timer > powerful_time && heal_timer > heal_time)
            active_animation = false;
    }

    private void FixedUpdate()
    {
        if (!active_animation)
            rigidbody.MovePosition(rigidbody.position + movement * movement_speed * Time.fixedDeltaTime);
    }
}
