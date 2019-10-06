using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBuilder : SceneBuilder
{

    public GameMaster.HouseComponents houseComponents;

    public override void serealize() {
        // Game Objects here are a list of tiles to choose from
        List<List<GameObject>> ret = new List<List<GameObject>>();
        frame = new List<List<GameObject>>();


        for( int i=0; i < columns; i++ ) {
            frame.Add(new List<GameObject>());
            for( int j=0; j < rows; j++ ) {
                if (i == 0 || j == 0 || i == columns-1 || j == rows-1) {
                    GameObject wall_tile = houseComponents.wall_sprite_holder;                   
                    wall_tile.GetComponent<SpriteRenderer>().sprite = sprite_list[sprite_mapper["floor"][0]];
                    frame[i].Add(wall_tile);
                }
                else {
                    GameObject floor_tile = houseComponents.floor_sprite_holder;
                    floor_tiles.GetComponent<SpriteRenderer>().sprite = sprite_list[sprite_mapper["floor"][0]];
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
