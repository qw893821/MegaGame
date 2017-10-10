using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    //get player location
    GameObject player;
    public Vector3 playerPos;

    //enemy bullet related properity
    float speed;

    //get boss eye posititon
    GameObject eye;
    public Vector3 eyePos;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
        eye = GameObject.Find("Eye");
        eyePos = eye.transform.position;
        speed = 2f;
        transform.position = eyePos - new Vector3(0.5f, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        BulletMove();
	}

    void BulletMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        print(speed * Time.deltaTime);
    }
}
