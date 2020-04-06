using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_dmg : MonoBehaviour
{

    public const float health_max = 12;
    public float health_now;
    public GameObject itself;
    // Start is called before the first frame update
    void Start()
    {
        health_now = health_max;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void TakeDmg(float dmg_given)
    {
        health_now -= dmg_given;
        if (health_now < 0)
        {
            Destroy(itself);
        }

    }
}
