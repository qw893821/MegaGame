using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public GameObject bullet;
    public GameObject canon;
	// Use this for initialization
	void Start () {
        canon = GameObject.Find("Canon");
	}
	
	// Update is called once per frame
	void Update () {
        Shoot();
	}

    void Shoot()
    {
        Vector3 bulletPos;
        
        bulletPos = canon.transform.position + new Vector3(1f, 0, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, bulletPos, Quaternion.identity);
        }
    }
}
