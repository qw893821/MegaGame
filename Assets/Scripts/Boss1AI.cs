using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1AI : MonoBehaviour {
    //boss eye is the place where boss1 shoot
    public GameObject bossEye;

    //bullet shoot properity
    float bulletTime;//time between two shot
    float shootTimer;//record normal shoot time

    float laserChargeTime;//laser charge time
    float laserTimer;//count laser last time
    bool laserMode;
    //mode change timer relate
    float modeChangeTimer;
    float changeTime;
    //laser color and normal color
    Color colButtle;//eye color when shoot bullet
    Color colLaser;

    //shoot bullet &laser
    public GameObject bullet;
    public GameObject laser;

    //color of boss eye material
    Color eyeCol;

	// Use this for initialization
	void Awake () {
        bossEye = transform.Find("Eye").gameObject;
        laserMode = false;
        bulletTime = 2f;
        shootTimer = 0f;
        laserTimer = 0f;
        modeChangeTimer = 0f;
        laserChargeTime = 2f;
        changeTime = 10f;
        colButtle = new Color(0f, 255f, 0);//eye color is green when shoot buttle
        colLaser = new Color(255f, 0, 0f);//eye color is red when shoot laser

	}
	
	// Update is called once per frame
	void Update () {
        Shoot();
        ModeChange();
    }

    void Shoot()
    {
        if (!laserMode)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= bulletTime)
            {
                Instantiate(bullet);
                shootTimer = 0;
            }
        }
        else if (laserMode)
        {
            laserTimer += Time.deltaTime;
            if (laserTimer >= laserChargeTime)
            {
                Instantiate(laser, bossEye.transform);
                laserMode = false;
                laserTimer = 0f;
                bossEye.GetComponent<Renderer>().material.color = colButtle;
            }
        }
    }

    void ModeChange()
    {
        //eye color change pace
        if (!laserMode)
        {
            modeChangeTimer += Time.deltaTime;
            if (modeChangeTimer >= changeTime)
            {
                bossEye.GetComponent<Renderer>().material.color = colLaser;
                laserMode = true;
                modeChangeTimer = 0f;
            }
        }
        print(laserMode);
    }  
}
