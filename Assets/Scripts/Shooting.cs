using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public GameObject[] bullets;
    public GameObject cannon;
    //time to between each shoot
    float time;
    //timer to count time between each shoot
    float timer;
    //timer to count charge time
    float chargeTimer;
    //timer for different stage of charge
    float level1Timer;
    float level2Timer;
    //float normalTimer;
	// Use this for initialization
	void Start () {
        cannon = GameObject.Find("Cannon");
        time = 0.3f;
        timer = 0;
        chargeTimer = 0f;
        //normalTimer = 0.5f;
        level1Timer = 1f;
        level2Timer = 2f;


	}
	
	// Update is called once per frame
	void Update () {
        Shoot();
	}

    void Shoot()
    {
        timer += Time.deltaTime;
        Vector3 bulletPos;
        bulletPos = cannon.transform.position + new Vector3(0.2f, 0, 0);
        if (timer >= time)
        {
            if (Input.GetButton("Fire1"))
            {
                chargeTimer += Time.deltaTime;
                print(chargeTimer);
            }
                if (Input.GetButtonUp("Fire1"))
                {
                    if (chargeTimer <= level1Timer)//time less than level 1 charge time, bullet instantiate normal bullet
                    {
                        Instantiate(bullets[0], bulletPos, Quaternion.identity);
                    }
                    else if (chargeTimer > level1Timer && chargeTimer <= level2Timer)//charge time more than level 1 but less than level 2, mid bullet
                    {
                        Instantiate(bullets[1], bulletPos, Quaternion.identity);
                    }
                    else if (chargeTimer > level2Timer)//charge time more than level 2, large bullet.
                {
                        Instantiate(bullets[2], bulletPos, Quaternion.identity);
                    }
                    chargeTimer = 0f;
                    timer = 0;
                }
        }

    }
}
