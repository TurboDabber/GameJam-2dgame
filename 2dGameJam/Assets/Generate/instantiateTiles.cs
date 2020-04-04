using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateTiles : MonoBehaviour
{
    public GameObject[] myGrounds;
    public GameObject[] myWalls;
    const int width=300;
    const int height=300;
    public  short[,] game_board = new short[height, width];
    private int random;
    public int REPETITIONS = 20;
    // Start is called before the first frame update
    void Start()
    {
        Board_init();
        Vector3 pos_vec=new Vector3(-width/2, -height/2, 0.0f );
        for(int i=1;i<height-1;i++)
            for(int j=1;j<width-1;j++)
            {
                Vector3 buff_vec = pos_vec;
                if (game_board[i,j]==1)
                {
                    
                    buff_vec.x += j;
                    buff_vec.y += i;
                    random = Random.Range(0, myGrounds.Length);
                    Instantiate(myGrounds[random], buff_vec, Quaternion.identity);
                }
                if(game_board[i,j]==2)
                {
                    buff_vec.x += j;
                    buff_vec.y += i;
                    random = Random.Range(0, myWalls.Length);
                    Instantiate(myWalls[random], buff_vec, Quaternion.identity);
                }
            }
        /*
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
        }*/
    }

    void Board_init()
    {
        int a = height / 2, b = width / 2;
        for(int i=a-3;i<a+3;i++)
            for(int j=b-3;j<b+3;j++)
            {
                game_board[i, j] = 1;
            }
        for (int i = 2; i < height-2; i++)
            for (int j = 2; j < width-2; j++)
            {
               
                random =Random.Range(0,4);

            }


        for (int i = 0; i < height; i++)//makes frame from walls
        {
            for (int j = 0; j < width; j++)
            {
                if (game_board[i, j] == 0)
                {
                    if (i > 0 && i < (height - 1))
                    {
                        if (game_board[i - 1, j] == 1)
                        {
                            game_board[i - 1, j] = 2;
                        }
                        if (game_board[i + 1, j] == 1)
                        {
                            game_board[i + 1, j] = 2;
                        }

                    }
                    if (j > 0 && j < (height - 1))
                    {
                        if (game_board[i, j + 1] == 1)
                        {
                            game_board[i, j + 1] = 2;
                        }
                        if (game_board[i, j + 1] == 1)
                        {
                            game_board[i, j + 1] = 2;
                        }

                    }

                }
            }

         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
