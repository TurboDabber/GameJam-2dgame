using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Parameters : MonoBehaviour
{
    public const int health_max = 100;
    public int health_now = 100;
    public int collected_frames = 0;
    public const int all_frames = 4;
    public bool fail = false;
    public bool won = false;
    public Health healthBar;/// UI bar 
    public CollectedFrames collected;
    public GameObject Ending;
    // Start is called before the first frame update
    void Start()
    {
        health_now = health_max;
        healthBar.setMax(health_max);//////////setting max health
        collected_frames = 3;
        collected.fillAmount = collected_frames.ToString( );
        collected.maxAmount = all_frames;
        collected.setText("0");
    }/// <summary>
     /// </summary>

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))/////////testing
        {
            TakeDmg(20);

        }

    }
    void TakeDmg(int dmg_given)
    {
        health_now -= dmg_given;
        if (health_now < 0)
        {
            fail = true;
        }

        healthBar.set_health(health_now);
    }
    void AddFrames()
    {
        collected_frames++;
        collected.fillAmount = collected_frames.ToString();
        collected.setText(collected.fillAmount);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Frame")
        {


            AddFrames();
            if (collected_frames >= 4)
            {
                Vector3 SpawnHere = new Vector3(collision.transform.position.x, collision.transform.position.y, 0.0f);
                Instantiate(Ending, SpawnHere, Quaternion.identity);
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Finish")
        {
            won = true;
        }
    }
}
