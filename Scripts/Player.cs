using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed;

    public GameObject projectile;
    public GameObject projectile2;
    public Rigidbody2D rb;

    Vector3 rotateVec;
    Vector3 movement;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        if (Input.GetButtonDown("Fire1")) {
            
            Instantiate(projectile,transform.position, Quaternion.Euler(0, 0, 0));
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(0,0,90));
        }
        if (Input.GetButtonDown("Fire3"))
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, 180));
        }
        if (Input.GetButtonDown("Fire4"))
        {
            Instantiate(projectile2, transform.position,  Quaternion.Euler(0, 0, 270));
        }
    }

   
    void FixedUpdate() {
        transform.position = transform.position + movement * speed * Time.fixedDeltaTime;
    }

    
}
