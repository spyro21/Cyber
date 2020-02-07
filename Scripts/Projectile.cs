using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {


    public float speed;
    public int direction;
    public int test;
    public bool isdirection4;
    



    public Rigidbody2D rb;
    private Transform target;
    private DoorManager dm;

    private Vector3 distanceFrom;
    Vector2 Movement;

    public Projectile(int dir) {
        direction = dir;
    }
	// Use this for initialization
	void Start () {
        
        //gets the transform component of the player 
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //fixed glitch where projectile would not be shot in direction 4
        if (!isdirection4)
        {
            if (transform.rotation.z == 0)
            {
                Movement.x += 1;
            }
            else if (Quaternion.Angle(transform.rotation, Quaternion.Euler(0, 0, 0)) == 90) // checks if rotation is at direction 2
            {
                Movement.y += 1;
            }
            else if (Quaternion.Angle(transform.rotation, Quaternion.Euler(0, 0, 0)) == 180) // checks if rotation is at direction 3
            {
                Movement.x -= 1;
            }

            //quaternion angle at 270 is weird so the 4th direction is another prefabs
        }
        else
        {
            direction = 4;
            Movement.y -= 1;
        }
       
        
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Wall") {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Enemy") {
            Destroy(gameObject);
        }
    }

    void Update() {
        
        distanceFrom = transform.position - target.position;
        if (distanceFrom.x > 20 || distanceFrom.y > 10) {
            Destroy(gameObject);
        }
    }
    

	// Update is called once per frame
	void FixedUpdate () {
        
        rb.MovePosition(rb.position + Movement * speed * Time.fixedDeltaTime);
	}
}
