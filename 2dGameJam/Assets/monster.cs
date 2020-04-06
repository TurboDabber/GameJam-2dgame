using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class monster : MonoBehaviour
{

    public const float health_max = 12;
    public float health_now;
    public GameObject player;
    public GameObject itself;


    public AIPath aIPath;//fliping sprite

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (aIPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);

        }
        else if (aIPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        float distance = Vector3.Distance(player.transform.position, itself.transform.position);
        if (distance<0)
        {
            distance = -distance;
        }
        if (distance > 10)
        {
            aIPath.canMove = false;
        }
        else
        {
            aIPath.canMove = true;
        }
    }


    void TakeDmg(float dmg_given)
    {
        health_now -= dmg_given;
        if (health_now < 0)
        {

        }

    }
}
