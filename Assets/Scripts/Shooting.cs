using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public GameObject bullet;
    public GameObject cannon;
	// Use this for initialization
	void Start () {
        cannon = GameObject.Find("Cannon");
	}
	
	// Update is called once per frame
	void Update () {
        Shoot();
	}

    void Shoot()
    {
        Vector3 bulletPos;
        bulletPos = cannon.transform.position + new Vector3(0.2f, 0, 0);
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, bulletPos, Quaternion.identity);
        }
    }
}
