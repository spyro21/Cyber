using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int side;
    public Transform Destination;
    private Map mapScript;

    void Start()
    {
        mapScript = GameObject.FindGameObjectWithTag("MiniMap").GetComponent<Map>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (side == 1)
            {
                col.transform.position = col.transform.position + new Vector3(4, 0, 0);
            }
            else if (side == 2)
            {
                col.transform.position = col.transform.position + new Vector3(0, 4, 0);
            }
            else if (side == 3)
            {
                col.transform.position = col.transform.position + new Vector3(-4, 0, 0);
            }
            else
            {
                col.transform.position = col.transform.position + new Vector3(0, -4, 0);
            }
        }
        


    }
}


