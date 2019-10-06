using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBuilder : SceneBuilder
{

    public override void serealize() {
        // Game Objects here are a list of tiles to choose from
        List<List<GameObject>> ret = new List<List<GameObject>>();
        frame = new List<List<GameObject>>();


        for( int i=0; i < columns; i++ ) {
            frame.Add(new List<GameObject>());
            for( int j=0; j < rows; j++ ) {
                if (i == 0 || j == 0 || i == columns-1 || j == rows-1) {
                    frame[i].Add(wall_tiles);
                }
                else {
                    frame[i].Add(floor_tiles);    
                }
            }
        }

        // frame = ret;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
