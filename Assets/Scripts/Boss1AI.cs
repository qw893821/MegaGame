using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1AI : MonoBehaviour {
    //boss eye is the place where boss1 shoot
    GameObject bossEye;

    //bullet shoot properity
    float bulletTime;//time between two shot
    float shootTimer;//record normal shoot time
    float laserChargeTime;//laser charge time
    bool laserMode;

    //shoot bullet &laser
    public GameObject bullet;
    public GameObject laser;

	// Use this for initialization
	void Awake () {
        laserMode = false;
        bulletTime = 2f;
        shootTimer = 0f;

	}
	
	// Update is called once per frame
	void Update () {
        Shoot();
	}

    void Shoot()
    {
        
        shootTimer += Time.deltaTime;
        if (!laserMode&&shootTimer>=bulletTime)
        {
            Instantiate(bullet);
            shootTimer = 0;
        }
    }
}
