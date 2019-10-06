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
		topFrameObjects = new List<GameObject>();
		topFramePositions = new List<List<int>>();


    	GameObject wall_tile = houseComponents.wall_sprite_holder;
		GameObject floor_tile = houseComponents.floor_sprite_holder;
		GameObject special_item_tile = houseComponents.special_item_sprite_holder;


		wall_tile.AddComponent<BoxCollider2D>();

        for( int i=0; i < columns; i++ ) {
            frame.Add(new List<GameObject>());
            for( int j=0; j < rows; j++ ) {
                if (i == 0 || j == 0 || i == columns-1 || j == rows-1) {
                    wall_tile.GetComponent<SpriteRenderer>().sprite = sprite_list[sprite_mapper["wall"][0]];
                    frame[i].Add(wall_tile);
                }
                else {
                    floor_tiles.GetComponent<SpriteRenderer>().sprite = sprite_list[sprite_mapper["floor"][0]];
                    frame[i].Add(floor_tiles);    
                }
            }
        }

		special_item_tile.GetComponent<SpriteRenderer>().sprite = sprite_list[sprite_mapper["specialitem"][0]];
        if (special_item_tile.GetComponent<BoxCollider2D>() == null)
		{
			special_item_tile.AddComponent<BoxCollider2D>();
		}
		special_item_tile.GetComponent<BoxCollider2D>().isTrigger = true;
		special_item_tile.GetComponent<BoxCollider2D>().tag = "SpecialItem";

		topFrameObjects.Add(special_item_tile);
		topFramePositions.Add(new List<int>(new int[] { 6, 6 }));

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
