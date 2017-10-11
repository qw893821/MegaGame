using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour {
    LineRenderer lineRend;
    //direction of the laser
    Vector3 dir;

    //position of player
    GameObject player;

    float speed;//laser move speed

	// Use this for initialization
	void Awake () {
        lineRend = GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        dir = player.transform.position - transform.position;
        dir = dir.normalized*2;
        lineRend.SetPosition(1, dir);
        speed = 8f;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
}
