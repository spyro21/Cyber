using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Rigidbody2D rb;
    private GameObject[] dms;
    private GameObject room;
    private DoorManager Manager;

    Vector3 movement;

    public float speed;
    private int rand;
    private int randD;
    private bool first = true;
    private float closestDistance;

	// Use this for initialization
	void Start () {
        dms = GameObject.FindGameObjectsWithTag("Room");

        foreach (var dm in dms) {
            float distance = Vector3.Distance(dm.transform.position, transform.position);
            if (first) {
                closestDistance = distance;

                first = false;
            } else if (distance < closestDistance) {
                room = dm;
                closestDistance = distance;
            }
        }
        Manager = room.GetComponent<DoorManager>();
	}
	
	// Update is called once per frame
	void Update () {
        rand = (int)(Random.Range(0f,100f));
        if (rand == 1) {
            randD = (int)(Random.Range(0f,4f) + 1);
            movement.x = 0;
            movement.y = 0;
            switch (randD)
            {
                case 1:
                    movement.x += 1;
                    break;
                case 2:
                    movement.y += 1;
                    break;
                case 3:
                    movement.x -= 1;
                    break;
                case 4:
                    movement.y -= 1;
                    break;

            }
        }

        
	}

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Projectile") {
            Destroy(gameObject);
            Manager.subtractNumEnemies(1);
        }
    }

    // Update is called once per frame (physics)
    void FixedUpdate() {
        rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
    }
}
