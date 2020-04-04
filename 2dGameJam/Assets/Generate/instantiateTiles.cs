using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateTiles : MonoBehaviour
{
    public GameObject[] myGrounds;
    public GameObject[] myWalls;
    private int random;
    public int REPETITIONS = 20;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos_vec=new Vector3( 0.0f, 0.0f, 0.0f );
        for (int i = 0; i < REPETITIONS; i++)
        {
            random = Random.Range(0, myGrounds.Length);
            Instantiate(myGrounds[random], pos_vec, Quaternion.identity);
            random = Random.Range(0, 4);
            if(random==0) 
            {
                pos_vec.x += 1;
            }
            else if(random==1)
            {
                pos_vec.x += -1;
            }
            else if(random == 2)
            {
                pos_vec.y += 1;
            }
            else if(random == 3)
            {
                pos_vec.y -= 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
