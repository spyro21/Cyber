using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public float speed;
    private float startSpeed;
    private Transform target;
    private Vector3 distanceFrom;

    // Use this for initialization
    void Start()
    {
        startSpeed = speed;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceFrom = transform.position - target.position;
        if (distanceFrom.x > 4 || distanceFrom.y > 4)
        {
            speed = speed * 3;
        }
        else
        {
            speed = startSpeed;
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
