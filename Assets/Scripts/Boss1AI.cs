using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1AI : MonoBehaviour {
    //boss eye is the place where boss1 shoot
    GameObject bossEye;

    //bullet shoot properity
    float bulletTime;//time between two shot
    float laserChargeTime;//laser charge time
    bool laserMode;

	// Use this for initialization
	void Start () {
        bossEye = GameObject.Find("Eye");
        laserMode = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Shoot()
    {

    }
}
