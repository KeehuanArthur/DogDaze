<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public int house_count = 3;

    [Serializable]
    public class Materials {

        public GameObject[] street_floors;
        public GameObject[] street_walls;
        public GameObject[] street_house;
        public GameObject[] house_floors;
        public GameObject[] house_walls;
        public GameObject[] junkyard_floors;
        public GameObject[] junkyard_walls;
        public GameObject spray_bottle;
        public GameObject roomba;
        public GameObject tennis_ball;
    }

    // private List<List<List<GameObject[]>>> houses;
    private List<HouseGenerator> houses;
    public Materials materials = new Materials();

    /**
      Map List:
      - Street
      - Junkyard
      - Houses x3
     */


    private HouseGenerator GetHouseGenerator(int house_index, string type) {

        HouseGenerator hg = new HouseGenerator();

        if (type == "house") {
            hg.floor_tiles = materials.house_floors;
            hg.wall_tiles = materials.house_walls;
        }
        else if (type == "junk") {
            hg.floor_tiles = materials.junkyard_floors;
            hg.wall_tiles = materials.junkyard_floors;
        }

        return hg;
    }


    private void BuildWorld() {

        // Build Houses
        houses = new List<HouseGenerator>();
        for (int i=0; i < house_count; i++) {
            HouseGenerator hg = GetHouseGenerator(1, "house");
            hg.seralizeHouse(10,10,1);
            houses.Add(hg);
        }
        houses[0].materializeHouse();

        // houses[0].deMateralizeHouse();
        // Build Street

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
=======
﻿using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public int house_count = 3;

    [Serializable]
    public class Materials {

        public GameObject[] street_floors;
        public GameObject[] street_walls;
        public GameObject[] street_house;
        public GameObject[] house_floors;
        public GameObject[] house_walls;
        public GameObject[] junkyard_floors;
        public GameObject[] junkyard_walls;
        public GameObject spray_bottle;
        public GameObject roomba;
        public GameObject tennis_ball;
    }

    // private List<List<List<GameObject[]>>> houses;
    private List<HouseGenerator> houses;
    public Materials materials = new Materials();

    /**
      Map List:
      - Street
      - Junkyard
      - Houses x3
     */


    private HouseGenerator GetHouseGenerator(int house_index, string type) {

        HouseGenerator hg = new HouseGenerator();

        if (type == "house") {
            hg.floor_tiles = materials.house_floors;
            hg.wall_tiles = materials.house_walls;
        }
        else if (type == "junk") {
            hg.floor_tiles = materials.junkyard_floors;
            hg.wall_tiles = materials.junkyard_floors;
        }

        return hg;
    }


    private void BuildWorld() {

        // Build Houses
        houses = new List<HouseGenerator>();
        for (int i=0; i < house_count; i++) {
            HouseGenerator hg = GetHouseGenerator(1, "house");
            hg.seralizeHouse(10,10,1);
            houses.Add(hg);
        }
        houses[0].materializeHouse();

        // houses[0].deMateralizeHouse();
        // Build Street

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
>>>>>>> 72819a0f579cd6391dcf90477d0a530b3d776385
