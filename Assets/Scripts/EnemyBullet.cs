using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    //get player location
    GameObject player;
    public Vector3 playerPos;

    //enemy bullet related properity
    float speed;
    Vector3 dir;//bullet move direction

    //get boss eye posititon
    GameObject eye;
    public Vector3 eyePos;

    //enemy bullet have three directions
    GameObject bulletM;
    GameObject bulletL;
    GameObject bulletR;
    

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
        eye = GameObject.Find("BulletPos");
        eyePos = eye.transform.position;
        speed = 2f;
        transform.position = eyePos - new Vector3(0.5f, 0, 0);
        dir = playerPos - transform.position;
        bulletM = transform.Find("BulletM").gameObject;
        bulletL = transform.Find("BulletL").gameObject;
        bulletR = transform.Find("BulletR").gameObject;


    }
	
	// Update is called once per frame
	void Update () {
        BulletMove();
	}

    void BulletMove()
    {
        Vector3 dirL;//bullet left direciton
        Vector3 dirR;//bullet right direction
        dirL = dir.normalized + new Vector3(-0.6f, 0, 0);
        dirR = dir.normalized + new Vector3(0.6f, 0, 0);
        bulletM.transform.position += dir.normalized* speed * Time.deltaTime;
        bulletL.transform.position += dirL.normalized * speed * Time.deltaTime;
        bulletR.transform.position += dirR.normalized * speed * Time.deltaTime;

    }
}
