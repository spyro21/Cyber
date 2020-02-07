using UnityEngine;
using System.Collections;

public class MapRoom : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x >= 900)
        {
            gameObject.SetActive(false);
        }
        else {
            gameObject.SetActive(true);
        }
	}
}
