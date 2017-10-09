using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion2Movement : MonoBehaviour {
    //minion 2 rig
    Rigidbody m2Rig;
    //normal speed for idle, blast when player on the same horizontal level
    float speed;
    float bSpeed;
    //moving direction of m2
    Vector3 dir;
    // Use this for initialization
    void Start () {
        m2Rig = GetComponent<Rigidbody>();
        speed = 5f;
        bSpeed = 8f;
        dir = new Vector3(1f, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        M2Movement();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Border")
        {
            dir = -dir;
        }
    }

    void M2Movement()
    {
        Vector3 m2Move;
        m2Move = dir * Time.deltaTime * speed;
        m2Rig.MovePosition(transform.position+m2Move);
    }
}
