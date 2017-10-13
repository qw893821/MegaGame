using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion3Movement : MonoBehaviour {
    //movement properity
    float speed;

    //bullet enemy shoot!This type could shoot
    public GameObject bullet;
    //shoot properity
    float reShootTime;
    float reShootTimer;

    //pos to spawn bullet
    Vector3 eyePos;
	// Use this for initialization
	void Awake () {
        speed = 5f;
        reShootTime = 2f;
        reShootTimer = 0f;
        eyePos = transform.Find("BulletPos").gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Shoot();

    }
    void Shoot()
    {
        reShootTimer += Time.deltaTime;
        if (reShootTimer >= reShootTime)
        {
            Instantiate(bullet,eyePos,Quaternion.identity);
            reShootTimer = 0f;
        }
    }
}
