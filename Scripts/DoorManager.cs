using UnityEngine;
using System.Collections;


public class DoorManager : MonoBehaviour { // also known as roomManager

    private AIStorage templates;

    public GameObject[] doors;

    public int numEnemies;
    private float randX;
    private float randY;
    private float roomX;
    private float roomY;
    private bool isComplete;
    private bool hasEntered;

    private void Start() {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<AIStorage>();
        hasEntered = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            hasEntered = true;
            setDoorActive(false);
            if (!isComplete) {
                spawnEnemy(2);
            }
            
            
        }
    }

    // spawns 'num' enemies in the room of this script
    private void spawnEnemy(int num)
    {
        for (int i = 0; i < num;i++) {
            randX = UnityEngine.Random.Range(-9f,9f) + transform.position.x;
            randY = UnityEngine.Random.Range(-5f, 5f) + transform.position.y;
            Instantiate(templates.AI[0], new Vector3(randX, randY, 5), Quaternion.identity);
        }
        
        numEnemies += num;
    }

    //changing method for when the enemy is destroyed
    public void subtractNumEnemies(int value)
    {
        numEnemies -= value;
    }

    void Update()
    {
        
        if (numEnemies <= 0 && hasEntered)
        {
            setDoorActive(true);
            isComplete = true;
        }
        
        
    }

    public void setDoorActive(bool setActiveV)
    {
        
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].SetActive(setActiveV);
        }
    }


}
