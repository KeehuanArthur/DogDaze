using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetBuilder : SceneBuilder
{
    public override void serealize() {
        frame = new List<List<GameObject>>();


        for (int i=0; i<columns; i++) {
            frame.Add(new List<GameObject>());
            for (int j=0; j<rows; j++ ) {

                if (i > 10 && i < 20) {
                    frame[i].Add(floor_tiles);
                }

                else if (i <= 10 && j > 20 && j < 30) {
                    frame[i].Add(floor_tiles);
                }

                else if (i >= 20 && j > 40 && j < 50) {
                    frame[i].Add(floor_tiles);
                }

                else if ( j > 60 ) {
                    frame[i].Add(floor_tiles);
                }

                else {
                    frame[i].Add(null);
                }
            }
        }
<<<<<<< HEAD


        /* Front Mat */
        



    }
=======
>>>>>>> a18c1d34c1ce53812bec8d3aa578e506c96a8846


        for (int i=0; i < columns; i++)
        {
            for (int j=0; j < rows; j++)
            {
                if (j>=0 && j<20)
                {
                    if (i == 10 || i == 20)
                    {
                        frame[i][j] = wall_tiles;
                    }
                } else if(j==20 || j==30)
                {
                    if (i<=10 || i==20)
                    {
                        frame[i][j] = wall_tiles;
                    }
                } else if(j>20 && j<30)
                {
                    if (i == 20)
                    {
                        frame[i][j] = wall_tiles;
                    }
                }
                else if(j>30 && j<40)
                {
                    if (i==10 || i==20)
                    {
                        frame[i][j] = wall_tiles;
                    }
                } else if(j==40 || j==50)
                {
                    if (i==10 || i>=20)
                    {
                        frame[i][j] = wall_tiles;
                    }
                } else if(j>40 && j < 50)
                {
                    if (i == 10)
                    {
                        frame[i][j] = wall_tiles;
                    }
                } else if(j>50 && j<60)
                {
                    if (i==10 || i==20)
                    {
                        frame[i][j] = wall_tiles;
                    }
                } else if(j==60)
                {
                    if (i<=10 || i >= 20)
                    {
                        frame[i][j] = wall_tiles;
                    }
                } else if(j>60 && j < 80)
                {
                    if (i==0 || i == 29)
                    {
                        frame[i][j] = wall_tiles;
                    }
                }
            

            }
        }
    }
   
}
