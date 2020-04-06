using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateTiles : MonoBehaviour
{
    public GameObject[] myGrounds;
    public GameObject[] myWalls;
    public GameObject[] myPorals;
    public GameObject it;
    public const int width=500;
    public const int height=500;
    public short[,] game_board = new short[height, width];
    private int random;
    public int min_room = 35;
    public int max_room = 110;
    public int min_corridor = 20;
    public int max_corridor = 40;
    public static int room_limiter=1;
    // Start is called before the first frame update
    void Start()
    {
        Board_init();
        int num_of_ground=0;
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
                    num_of_ground++;
                }
                else if(game_board[i,j]==2)
                {
                    buff_vec.x += j;
                    buff_vec.y += i;
                    random = Random.Range(0, myWalls.Length);
                    Instantiate(myWalls[random], buff_vec, Quaternion.identity);
                }
            }
        AstarPath.active.Scan();
        for (int i=0;i<4;i++)
        {
            bool sucess = false;
            while(sucess==false)
            {
                Vector3 buff_vec = pos_vec;
                int a = Random.Range(0, width), b = Random.Range(0, height);
                if (game_board[a, b] == 1)
                {
                   

                    
                    buff_vec.x += b;
                    buff_vec.y += a;
                    buff_vec.z -= 0.1f;
                    random = Random.Range(0, myPorals.Length - 1);
                    Instantiate(myPorals[i], buff_vec, Quaternion.identity);
                    sucess = true;
                }
            }
        }
        AstarPath.active.Scan();
        for (int i = 0; i < num_of_ground/100; i++)
        {
            bool sucess = false;
            while (sucess == false)
            {
                Vector3 buff_vec = pos_vec;
                int a = Random.Range(0, width), b = Random.Range(0, height);
                if (game_board[a, b] == 1)
                {



                    buff_vec.x += b;
                    buff_vec.y += a;
                    buff_vec.z -= 0.1f;
                    Instantiate(it, buff_vec, Quaternion.identity);
                    sucess = true;
                }
            }
        }


    }

    void Board_init()
    {
        int a = height / 2, b = width / 2;
        for(int i=a-3;i<a+3;i++)
            for(int j=b-3;j<b+3;j++)
            {
                game_board[i, j] = 1;
            }       
        
        
        bool dont_once_more = false;
          while(dont_once_more == false)//at least one corridor
            for (int i = 0; i < 3 ;i++)
            {
                random = Random.Range(0, 2);
                if(random==1)
                {
                    dont_once_more = true;
                    create_cooridors(a, b, Random.Range(0, 4));
                }
            }


        for (int i = 0; i < height; i++)//makes frame from walls
        {
            for (int j = 0; j < width; j++)
            {
                if (game_board[i, j] == 0)
                {
                    if (i > 0 && i < (height - 1)&& j > 0 && j < (height - 1))
                    {
                        if (game_board[i - 1, j] == 1)
                        {
                            game_board[i , j] = 2;
                        }
                        if (game_board[i + 1, j] == 1)
                        {
                            game_board[i, j] = 2;
                        }
                        if (game_board[i, j - 1] == 1)
                        {
                            game_board[i, j] = 2;
                        }
                        if (game_board[i, j + 1] == 1)
                        {
                            game_board[i, j] = 2;
                        }

                        if (game_board[i - 1, j-1] == 1)
                        {
                            game_board[i, j] = 2;
                        }
                        if (game_board[i + 1, j+1] == 1)
                        {
                            game_board[i, j] = 2;
                        }
                        if (game_board[i+1, j - 1] == 1)
                        {
                            game_board[i, j] = 2;
                        }
                        if (game_board[i-1, j + 1] == 1)
                        {
                            game_board[i, j] = 2;
                        }

                    }

                }
            }

         }
        
    }
    void create_cooridors(int x,int y,int direction)
    {
      
            int length_corr = Random.Range(min_corridor, max_corridor);

            random = Random.Range(0, 7);
            
            int when_crack=-10;
            if(random<4)
            {
                when_crack = Random.Range(min_corridor,length_corr);
            }

            for(int i=0;i<length_corr;i++)
            {

                  if(i==when_crack)
                  {
                  create_cooridors(x, y, random);
                  }
                  if (direction == 0)
                    {
                         x++;
                    }
                   if (direction == 1)
                   {
                         x--;
                   }
                   if (direction == 2)
                   {
                       y--;
                   }
                   if (direction == 3)
                   {
                         y++;
                   }
                   int temp1 = x,temp2 = y;
                  for (int j=0;j<3;j++)
                  {
                    if (direction == 0||direction==1)
                        {
                            y+=j;
                        }
                    else if (direction == 2||direction==3)
                        {
                            x+=j;
                        }

                    if (x > 2 && x<width && y>2 && y<height)
                        {
                            game_board[x,y] = 1;
                        }
                
                
                    x = temp1;
                    y = temp2;
                
                  }
            }
            create_room(x, y,direction);
    }
    void create_room(int x, int y, int direction)
    {
        
        int length_room = Random.Range(min_room, max_room);
        int width_room = Random.Range(min_room, max_room);
        for (int i = 0; i < length_room; i++)
        { 
            if (direction == 0)
            {
                x++;
            }
            if (direction == 1)
            {
                x--;
            }
            if (direction == 2)
            {
                y--;
            }
            if (direction == 3)
            {
                y++;
            }
            int temp1 = x, temp2 = y;
            for (int j = 0; j < width_room; j++)
            {
                if (direction == 0 || direction == 1)
                {
                    y += j;
                }
                else if (direction == 2 || direction == 3)
                {
                    x += j;
                }

                if (x > 2 && x < width && y > 2 && y < height)
                {
                    game_board[x, y] = 1;
                }
                x = temp1;
                y = temp2;
            }
        }
        room_limiter++;
        random = Random.Range(0, room_limiter);
        if (random < 2&& room_limiter<14)
        {
            bool dont_once_more = false;
            while (dont_once_more == false)//at least one corridor
                for (int i = 0; i < 3; i++)
                {
                    random = Random.Range(0, 2);
                    if (random == 1)
                    {
                        dont_once_more = true;
                        create_cooridors(x, y, Random.Range(0, 4));
                    }
                }
        }
        else if (room_limiter<6)
        {
            create_cooridors(x, y, Random.Range(0, 4));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
