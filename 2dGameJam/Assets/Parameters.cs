using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    public const int health_max = 100;
    public int health_now = 100;
    public int collected_frames = 0;
    public int all_frames = 4;
    public Health healthBar;/// UI bar 
    // Start is called before the first frame update
    void Start()
    {
        health_now = health_max;
        healthBar.setMax ( health_max);//////////setting max health
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))/////////testing
        {
            TakeDmg(20);
        }
    }
    void TakeDmg(int dmg_given)
    {
        health_now -= dmg_given;
        healthBar.set_health(health_now);
    }
}
