using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    public const int health_max = 100;
    public int health_now = 100;
    public int collected_frames = 0;
    public const int all_frames = 4;
    bool fail = false;
    public Health healthBar;/// UI bar 
    public CollectedFrames collected;
    // Start is called before the first frame update
    void Start()
    {
        health_now = health_max;
        healthBar.setMax ( health_max);//////////setting max health
        collected.fillAmount = collected_frames;
        collected.maxAmount = all_frames;
    }/// <summary>
    /// </summary>

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
        if(health_now<0)
        {
            fail = true;
        }
        healthBar.set_health(health_now);
    }
    void AddFrames()
    {
        collected.fillAmount = ++collected_frames;
        collected.setText();

    }
}
