using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public const float health_max = 12;
    public float health_now;
    bool strong = false;
    GameObject itself;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player_attack")
        {

            health_now -= 3;
        }
        if (collision.gameObject.tag == "whril")
        {
            health_now -=5;

        }
        if (strong==true&& collision.gameObject.tag=="strong")
        {
            health_now = -100;

        }
    }
    void TakeDmg(float dmg_given)
    {
        health_now -= dmg_given;
        if (health_now < 0)
        {
            Destroy(itself);
        }

    }
}
