using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertPlate : MonoBehaviour {
    //plate move speed
    float speed;

    //plate direction
    Vector3 dir;

    //get plate
	// Use this for initialization
	void Awake () {
        speed = 4f;
        dir = new Vector3(1f, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        PlateMovement();
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Reverse")
        {
            dir = -dir;
            print("enter");
        }
    }

    void PlateMovement()
    {
        transform.position += dir.normalized * Time.deltaTime * speed;
    }
}
