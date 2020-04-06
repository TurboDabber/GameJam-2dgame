using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public Transform front_attack_point;
    public Transform back_attack_point;
    public Transform left_attack_point;
    public Transform right_attack_point;
    public Transform piruet_point;
    public Transform powerful_point;
    public float attack_range = 0.5f;
    public float piruet_range = 2f;
    public LayerMask enemy_layers;
    public float attack_horizontal;
    public float attack_vertical;
    public controls controls;
    public Parameters parameters;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attack_horizontal = controls.prev_move.x;
        attack_vertical = controls.prev_move.y;
    }

    public void Basic_attack()
    {
        if (attack_horizontal < 0)
        {
            Collider2D[] hit_enemies = Physics2D.OverlapCircleAll(left_attack_point.position, attack_range, enemy_layers);

            foreach (Collider2D enemy in hit_enemies)
            {
                enemy.GetComponent<monster_dmg>().TakeDmg(3);
            }
        }
        else if(attack_horizontal > 0)
        {
            Collider2D[] hit_enemies = Physics2D.OverlapCircleAll(right_attack_point.position, attack_range, enemy_layers);

            foreach (Collider2D enemy in hit_enemies)
            {
                enemy.GetComponent<monster_dmg>().TakeDmg(3);
            }
        }
        else if(attack_vertical < 0)
        {
            Collider2D[] hit_enemies = Physics2D.OverlapCircleAll(front_attack_point.position, attack_range, enemy_layers);

            foreach (Collider2D enemy in hit_enemies)
            {
                enemy.GetComponent<monster_dmg>().TakeDmg(3);
            }
        }
        else if(attack_vertical > 0)
        {
            Collider2D[] hit_enemies = Physics2D.OverlapCircleAll(back_attack_point.position, attack_range, enemy_layers);

            foreach (Collider2D enemy in hit_enemies)
            {
                enemy.GetComponent<monster_dmg>().TakeDmg(3);
            }
        }
    }

    public void Piruet()
    {
        Collider2D[] hit_enemies = Physics2D.OverlapCircleAll(piruet_point.position, piruet_range, enemy_layers);

        foreach (Collider2D enemy in hit_enemies)
        {
            enemy.GetComponent<monster_dmg>().TakeDmg(6);
        }
    }

    public void Powerful_attack()
    {
        Collider2D[] hit_enemies = Physics2D.OverlapCircleAll(powerful_point.position, piruet_range, enemy_layers);

        foreach (Collider2D enemy in hit_enemies)
        {
            enemy.GetComponent<monster_dmg>().TakeDmg(100);
        }
    }

    public void Heal()
    {
        if ((parameters.health_now += 40) < 100)
            parameters.health_now += 40;
        else
            parameters.health_now = 100;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(front_attack_point.position, attack_range);
        Gizmos.DrawWireSphere(back_attack_point.position, attack_range);
        Gizmos.DrawWireSphere(left_attack_point.position, attack_range);
        Gizmos.DrawWireSphere(right_attack_point.position, attack_range);
        Gizmos.DrawWireSphere(piruet_point.position, piruet_range);
    }
}
