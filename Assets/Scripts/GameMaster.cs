using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.UI;


public class GameMaster : MonoBehaviour
{

    public const string game_state_start_loading_level = "StartLoadingLevel";
    public const string game_state_loading_level = "LoadingLevel";
    public const string game_state_playing_game = "PlayingGame";
    public string cur_game_state = game_state_loading_level;
    public float levelStartDelay = 2f;
    private Text levelText;
    private GameObject canvasImage;
    Dictionary <string, string> nextStage = new Dictionary<string, string>();

    SceneBuilder currentScene;


    public int house_count = 3;
    private bool doingSetup;




    [Serializable]
    public class Materials {

        public GameObject street_floors;
        public GameObject street_walls;
        public GameObject street_house;
        public GameObject street_doors;
        public GameObject house_floors;
        public GameObject house_walls;
        public GameObject junkyard_floors;
        public GameObject junkyard_walls;
        public GameObject spray_bottle;
        public GameObject roomba;
        public GameObject tennis_ball;
    }





    [Serializable]
    public class HouseComponents{
        public GameObject floor_sprite_holder;
        public GameObject wall_sprite_holder;
        public GameObject entrance_sprite_holder;
    }
    public  HouseComponents houseComponents;

    public Sprite[] spriteListHouse1;
    public Sprite[] spriteListHouse2;
    public Sprite[] spriteListHouse3;
    public Sprite[] streetSpriteList;

    List<Sprite[]> rawHouseSprites;

    IDictionary<string, int[]> sprite_mapper;



    private void OnLevelWasLoaded(int index) {
    }

    private List<HouseBuilder> houses;
    private StreetBuilder street;
    public Materials materials = new Materials();

    private Transform board_holder_transform;

    private GameObject player;
	public GameObject enemyPrefab;
	private List<GameObject> enemies;


    /**
      Map List:
      - Street
      - Junkyard
      - Houses x3
     */


    private SceneBuilder SceneFactory(
        int house_index, string type, Transform transform) {

        if (type == "house") {
            HouseBuilder builder = new HouseBuilder();
            builder.floor_tiles = materials.house_floors;
            builder.wall_tiles = materials.house_walls;
            builder.houseComponents = houseComponents;
            builder.columns = 20;
            builder.rows = 20;
            builder.sprite_list = rawHouseSprites[0]; // hardcoded for now cus we only have 1 list of sprites
            builder.sprite_mapper = sprite_mapper;
            builder.board_holder_transform = transform;            
            return builder;
        }
        else if (type == "street") {
            StreetBuilder builder = new StreetBuilder();
            builder.floor_tiles = materials.street_floors;
            builder.wall_tiles = materials.street_walls;
            builder.door_tiles = materials.street_doors;
            builder.columns = 30;
            builder.rows = 80;
            builder.board_holder_transform = transform;            
            return builder;
        }
        else {
            return null;
        }
    }

    public void EnterStreet() {
        Debug.Log("Enter Street");
        currentScene.deMaterialize();
        currentScene = street;
        currentScene.materialize();

        player.transform.position = new Vector3(100,0,-1f);
        enemies = new List<GameObject>();
    }

    public void EnterHouse(int houseNumber) {
        // TODO: display "level 1" instead of "level start"
        Debug.Log("Enter House" + houseNumber.ToString());
        
        currentScene.deMaterialize();
        currentScene = houses[houseNumber];
        currentScene.materialize();
        
        player.transform.position = new Vector3(10,1,-1f);
        SpawnEnemies(houseNumber);
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
        // TEMP - JUST GET DOOR
        materials.street_doors.GetComponent<SpriteRenderer>().sprite = houses[0].sprite_list[sprite_mapper["door"][0]];
        //houses[0].materialize();
        //houses[0].deMaterialize();


        //Build Street
        street = SceneFactory(1, "street", board_holder_transform) as StreetBuilder;
        street.serealize();

        currentScene = street;
        currentScene.materialize();
        //street_builder.materialize();
        // player.transform.position = new Vector3(15, 0, -1f);


        // Build Street
        // StreetBuilder street_builder = new StreetBuilder();
        // street_builder.board_holder_transform = board_holder_transform;
        // street_builder.floor_tiles = materials.street_floors;
        // street_builder.wall_tiles = materials.street_walls;
        // street_builder.seralizeStreet();
        // street_builder.materalizeStreet();

        // player.transform.position = new Vector3(100,0,-1f);

    }

	void SpawnEnemies(int houseNumber)
	{
		enemies = new List<GameObject>();
		for (int i = 0; i < 3; i++)
		{
			GameObject enemy = Instantiate(enemyPrefab, new Vector3(15,15, -1f), Quaternion.identity);
            //enemy.GetComponent<PlayerMovement>().gameMaster = this;
            enemies.Add(enemy);

		}
	}


	void Awake() {
		player = GameObject.FindWithTag("Player");
        //player.GetComponent<PlayerMovement>().gameMaster = this;

        sprite_mapper = new Dictionary<string, int[]>();
        sprite_mapper.Add( "floor", new [] {16,18,19} );
        sprite_mapper.Add( "wall", new [] {8, 10, 11});
        sprite_mapper.Add( "door", new [] {54, 62});

        rawHouseSprites = new List<Sprite[]>();
        rawHouseSprites.Add(spriteListHouse1);
        rawHouseSprites.Add(spriteListHouse2);
        rawHouseSprites.Add(spriteListHouse3);



        cur_game_state = game_state_start_loading_level;
        canvasImage = GameObject.Find("LevelCanvas");


		BuildWorld();
    }



    // Start is called before the first frame update
    void Start()
    {            

    }

    public void SetCurrentGameState(String newState) {
        if (newState == "load") {
            cur_game_state = game_state_start_loading_level;
        }
    }
    // Update is called once per frame
    void Update()
    {

        /* State Definitions */
        switch (cur_game_state) {
            case game_state_start_loading_level:
                cur_game_state = game_state_loading_level;
                StartCoroutine( changeStateCo(game_state_playing_game, 2f) );
                break;

            case game_state_loading_level:
                canvasImage.SetActive(true);
                break;

            case game_state_playing_game:
                canvasImage.SetActive(false);
                break;

            default:
                break;
        }
    }

    IEnumerator changeStateCo(String state_name, float delayTime) {

        yield return new WaitForSeconds(delayTime);
        cur_game_state = state_name;
    }

    // void ChangeGameStates() {
    //     /* Next State Logic */

    //     switch (cur_game_state) {
    //         case game_state_playing_game:
    //             break;
            
    //         case game_state_loading_level:
    //             break;
    //     }

    // }
}
