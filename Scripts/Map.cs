using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    public int[,] grid = new int[20, 20];
    private int midX = 9;
    private int midY = 9;
    private int x;
    private int y;

    public GameObject roomBox;
    private Vector3 pos;
    public GameObject[] text;
    private GameObject[] spawners;
    private Transform canvasT;
    private Transform minimapT;


    void Start() {
        
        canvasT = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Transform>();
        minimapT = GameObject.FindGameObjectWithTag("MiniMap").GetComponent<Transform>();
        Invoke("findRooms", 2f);





    }

    void findRooms() {
        spawners = GameObject.FindGameObjectsWithTag("SpawnPoint");
        for (int row = 0; row < 20; row++)
        {
            for (int col = 0; col < 20; col++)
            {
                grid[row, col] = 0;
            }
        }

        //sets anchor point
        grid[midX, midY] = 1;


        for (int i = 0; i < spawners.Length; i++)
        {
            x = (int)(spawners[i].transform.position.x / 20);
            y = (int)(spawners[i].transform.position.y / 10);
            grid[x + midX, y + midY] = 1;
        }

        //make imageboxes on minimap
        for (int row = 0; row < 10; row++)
        {
            for (int col = 0; col < 10; col++)
            {
                pos.x = 750 + (row * 25);
                pos.y = 0 + (col * 25);

                if (grid[row + 5,col + 5] == 1) {
                   GameObject roomBox = Instantiate(this.roomBox, pos, Quaternion.identity) as GameObject;
                   roomBox.transform.SetParent(minimapT);
                }
            }
        }

        /*
        //prints grid
        for (int row = 0; row < 20; row++)
        {
            for (int col = 0; col < 20; col++)
            {
                pos.x = 200 + (row * 15);
                pos.y = 300 + (col * 15);

                if (grid[row, col] == 1)
                {
                    GameObject text1 = Instantiate(text[1], pos, Quaternion.identity) as GameObject;
                    text1.transform.SetParent(canvasT);


                }
                else
                {

                    GameObject text0 = Instantiate(text[0], pos, Quaternion.identity) as GameObject;
                    text0.transform.SetParent(canvasT);
                }
            }
        }
        */
    }
   
	// Update is called once per frame
	void Update () {
	    
	}
}
