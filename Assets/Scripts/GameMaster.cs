using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public int house_count = 3;

    [Serializable]
    public class Materials {

        public GameObject street_floors;
        public GameObject street_walls;
        public GameObject street_house;
        public GameObject house_floors;
        public GameObject house_walls;
        public GameObject junkyard_floors;
        public GameObject junkyard_walls;
        public GameObject spray_bottle;
        public GameObject roomba;
        public GameObject tennis_ball;
    }

    // private List<List<List<GameObject[]>>> houses;
    private List<HouseBuilder> houses;
    public Materials materials = new Materials();

    private Transform board_holder_transform;

    public GameObject player;


    /**
      Map List:
      - Street
      - Junkyard
      - Houses x3
     */


    private SceneBuilder SceneFactory(int house_index, string type, Transform transform) {

        SceneBuilder builder;

        if (type == "house") {
            builder = new HouseBuilder();
            builder.floor_tiles = materials.house_floors;
            builder.wall_tiles = materials.house_walls;
            builder.columns = 10;
            builder.rows = 20;
        }
        // else if (type == "junk") {
        //     builder.floor_tiles = materials.junkyard_floors;
        //     builder.wall_tiles = materials.junkyard_floors;
        // }
        // else if (type == "street") {
        else {
            builder = new StreetBuilder();
            builder.floor_tiles = materials.street_floors;
            builder.wall_tiles = materials.street_walls;
            builder.columns = 200;
            builder.rows = 300;
        }

        builder.board_holder_transform = transform;
        return builder;
    }


    private void BuildWorld() {

        // Build Houses
        houses = new List<HouseBuilder>();
        board_holder_transform = new GameObject("Board").transform;
        for (int i=0; i < house_count; i++) {
            HouseBuilder hg = SceneFactory(1, "house", board_holder_transform) as HouseBuilder;
            hg.serealize();
            houses.Add(hg);
        }
        houses[0].materialize();
        houses[0].deMaterialize();


        // Build Street
        StreetBuilder street_builder = SceneFactory(1, "street", board_holder_transform) as StreetBuilder;
        street_builder.serealize();
        street_builder.materialize();
        player.transform.position = new Vector3(100, 0, -1f);


        // Build Street
        // StreetBuilder street_builder = new StreetBuilder();
        // street_builder.board_holder_transform = board_holder_transform;
        // street_builder.floor_tiles = materials.street_floors;
        // street_builder.wall_tiles = materials.street_walls;
        // street_builder.seralizeStreet();
        // street_builder.materalizeStreet();

        // player.transform.position = new Vector3(100,0,-1f);

    }




    void Awake() {
        BuildWorld();
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
