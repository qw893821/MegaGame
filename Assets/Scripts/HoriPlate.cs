using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoriPlate : MonoBehaviour {
    //plate move speed
    float speed;
    //plate move direction
    Vector3 dir;
	// Use this for initialization
	void Awake () {
        speed = 4f;
        dir = new Vector3(0, 1f, 0);
	}
	
	// Update is called once per frame
	void Update () {
        HoriPlateMovement();

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Reverse")
        {
            dir =-dir;
        }
    }

    void HoriPlateMovement()
    {
        transform.position += dir.normalized * Time.deltaTime * speed;
    }
}
